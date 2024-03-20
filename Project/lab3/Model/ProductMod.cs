namespace lab3.Model
{
    public class ProductMod
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; } = null;
        public string? NameImg { get; set; } = null;
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public List<int>? category { get; set; } = new List<int>();
    }
}
