namespace Backend.Data.Entities
{
    public class Basket
    {
        public int Id { get; set; }
    
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
