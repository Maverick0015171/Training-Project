using System.ComponentModel.DataAnnotations;

namespace LoginPage.Pages.ProductModelClass
{
    public class ProductModel
    {
        [Required]
        public int PId { get; set; }

        [Required]
        public string PName { get; set; }

        [Required]
        public decimal PPrice { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public string Discription { get; set; }
        
        [Required]
        public int isActive { get; set; } = 1;

        [Required]
        public IFormFile ImageFile { get; set; }


    }
}
