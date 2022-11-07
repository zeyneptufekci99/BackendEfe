namespace Backend.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public int? BasketId { get; set; }
        public string Email { get; set; } = String.Empty;
        public int? RoleId { get; set; }
        public int GenderId { get; set; }
        public string? RoleDefinition { get; set; } = string.Empty;

    }
}
