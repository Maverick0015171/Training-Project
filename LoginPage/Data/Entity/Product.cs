using System.ComponentModel.DataAnnotations;

namespace LoginPage.Data.Entity
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        public string PName { get; set; }

        [Required]
        public decimal PPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Discription { get; set; }

        public int isActive { get; set; } = 1;
    }
}
