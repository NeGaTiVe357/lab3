using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace lab3.Model
{
    public class ProductCategories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        [JsonIgnore]
        public int IdProduct { get; set;}
        [JsonIgnore]
        [ForeignKey("Category")]
        public int IdCategories { get; set;}
        
        public Product? Product { get; } = null!;
        
        public Category? Category { get; set; } = null!;
    }
}
