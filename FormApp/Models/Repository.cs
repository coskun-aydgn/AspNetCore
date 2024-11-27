namespace FormApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Telefon" });
            _categories.Add(new Category { CategoryId = 2, Name = "Bilgisayar" });

            _products.Add(new Product { ProductId = 1, Name = "IPhone 14", Price = 40000, IsActive = true, ImageUrl = "1.jpg", CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, Name = "IPhone 15", Price = 50000, IsActive = false, ImageUrl = "2.jpg", CategoryId = 1 });
            _products.Add(new Product { ProductId = 3, Name = "IPhone 16", Price = 60000, IsActive = true, ImageUrl = "3.jpg", CategoryId = 1 });
            _products.Add(new Product { ProductId = 4, Name = "IPhone 17", Price = 70000, IsActive = false, ImageUrl = "4.jpg", CategoryId = 1 });

            _products.Add(new Product { ProductId = 5, Name = "Macbook Air", Price = 80000, IsActive = false, ImageUrl = "5.jpg", CategoryId = 2 });
            _products.Add(new Product { ProductId = 6, Name = "Macbook Pro", Price = 90000, IsActive = true, ImageUrl = "6.jpg", CategoryId = 2 });

        }

        public static List<Product> Products
        {
            get { return _products; }
        }
        public static List<Category> Categories
        {
            get { return _categories; }
        }
        public static void CreateProduct(Product product)
        {
            _products.Add(product);
        }
        public static void EditProduct(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
            if (entity != null)
            {
                entity.Name = updatedProduct.Name;
                entity.Price = updatedProduct.Price;
                entity.ImageUrl = updatedProduct.ImageUrl;
                entity.CategoryId = entity.CategoryId;
                entity.IsActive = updatedProduct.IsActive;
            }
        }

    }
}