using System.ComponentModel.DataAnnotations;

namespace FormApp.Models
{
    //ayrica [Bind("name","Price")] seklinde yazarak istedigimiz inputlari kullanabiliriz
    public class Product
    {
        [Display(Name = "Urun Id")]
        //[BindNever] buradaki bilginin bind edilmesini saglar
        public int ProductId { get; set; }
        [Display(Name = "Urun Adi")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0, 100000)] //max ve min degerler icin
        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }

        [Display(Name = "Resim")]
        public string? ImageUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
    }
}