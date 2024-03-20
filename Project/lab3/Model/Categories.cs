using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Model
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        [property: Required]
        public string Name { get; set; }
        public ICollection<ProductCategories>? ProductCategories { get; } = new List<ProductCategories>();
    }
}
