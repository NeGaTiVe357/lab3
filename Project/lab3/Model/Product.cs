using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [property: Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? NameImg { get; set; }
        [property: Required]
        public double Price { get; set; }
        [property: Required]
        public int Quantity { get; set; }
        public ICollection<ProductCategories>? ProductCategories { get; } = new List<ProductCategories>();
    }
}
