namespace Backend.Data.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public List<Product>? Products { get; set; }
    }
}
