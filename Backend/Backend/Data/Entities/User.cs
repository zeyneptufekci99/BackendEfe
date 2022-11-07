namespace Backend.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public int BasketId { get; set; }
        public Basket? Basket { get; set; }

    }
}
