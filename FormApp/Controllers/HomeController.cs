using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormApp.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {

    }

    public IActionResult Index(string seachString, string category)
    {
        var products = Repository.Products;
        if (!String.IsNullOrEmpty(seachString))
        {
            ViewBag.SeachString = seachString;
            products = products.Where(p => p.Name.ToLower().Contains(seachString)).ToList();
        }
        if (!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();

        }
        //ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category);

        var model = new ProductViewModel
        {
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Product product, IFormFile imageUrl) //gelecek inputlari tektek de yazabiliriz "string name, ..." gibi
    //ayrica ([Bind("name","Price")]Product product) seklinde yazarak istedigimiz inputlari kullanabiliriz
    {
        var extension = "";


        if (imageUrl != null)
        {
            var allowedExtension = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            extension = Path.GetExtension(imageUrl.FileName);
            //yuklenen resim isminin sonundaki uzantiyi alir ornegin abc.jpeg ise ".jpeg" i alir
            if (!allowedExtension.Contains(extension))
            {
                ModelState.AddModelError("", "Gecerli bir resim seciniz");
                //buradaki ilk deger hatanin nereye yazilmasini istedigin alani belirler. bos ise All kismina yazar. ama Istersen ImgaUrl yazarsan oradaki yere yazar
            }
        }
        if (ModelState.IsValid)
        {
            if (imageUrl != null)
            {
                var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                //bu da resim icin random bir isim olsuturur ve extension ile birlersirir
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                //yuklenen resmin upload yapilacagi yerin gosterilmesini sagliyor path
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageUrl.CopyToAsync(stream);
                    //burasi resmi istedigimiz klasore kaydediyor
                }
                product.ImageUrl = randomFileName; //
                product.ProductId = Repository.Products.Count + 1;
                Repository.CreateProduct(product);

                return RedirectToAction("Index");
            }

        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");

        return View(product); //girilen degerler kaybolmasin diye bu degerleri geri gonderiyor

    }
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var product = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(product);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product model, IFormFile? imageFile, string ExistingImageUrl)
    {
        if (id != model.ProductId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            if (imageFile != null)
            {
                // Yeni resim yüklenmişse
                var extension = Path.GetExtension(imageFile.FileName); // Örn: .jpg
                var randomFileName = $"{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                model.ImageUrl = randomFileName; // Yeni resim dosya adını ata
            }
            else
            {
                // Yeni resim yüklenmemişse mevcut resmi kullan
                model.ImageUrl = ExistingImageUrl;
            }

            // Ürünü güncelle
            Repository.EditProduct(model);
            return RedirectToAction("Index");
        }

        // Model valid değilse tekrar formu doldur
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var product = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
        {
            return NotFound();
        }
        /* Repository.DeleteProduct(product);
        return RedirectToAction("Index"); */
        return View("DeleteConfirm", product);
    }
    [HttpPost]
    public IActionResult Delete(int id, int ProductId)
    {
        if (id != ProductId)
        {
            return NotFound();
        }
        var product = Repository.Products.FirstOrDefault(p => p.ProductId == ProductId);
        if (product == null)
        {
            return NotFound();
        }
        Repository.DeleteProduct(product);
        return RedirectToAction("Index");
    }
    public IActionResult EditProducts(List<Product> Products)
    {
        foreach (var product in Products)
        {
            Repository.EditIsActive(product);
        }
        return RedirectToAction("Index");
    }

}
