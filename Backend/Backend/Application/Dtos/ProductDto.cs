namespace Backend.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public string Summary { get; set; } = String.Empty;
        public float Price { get; set; }
        public int Stok { get; set; }

        public int GenderId { get; set; }

        public int ProductTypeId { get; set; }


    }
}
