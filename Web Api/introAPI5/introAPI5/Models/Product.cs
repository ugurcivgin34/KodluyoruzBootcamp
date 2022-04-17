using System.ComponentModel.DataAnnotations;

namespace introAPI5.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı boş geçilemez")] //nesneyi bellekte oluştururken ki kural bu anatasyonlar
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? Description { get; set; }
        public double? Discount { get; set; }
        public string? ImageUrl { get; set; }
        
        

    }
}
