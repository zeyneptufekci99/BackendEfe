namespace Backend.Data.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<User>? Users { get; set; }

        public List<Product>? Products { get; set; }
    }
}
