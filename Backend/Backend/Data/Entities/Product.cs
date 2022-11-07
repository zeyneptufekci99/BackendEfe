namespace Backend.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }=String.Empty;
        public string ImageUrl { get; set; }=String.Empty;
        public string Summary { get; set; }=String.Empty;
        public float Price { get; set; }
        public int Stok { get; set; }
        public int GenderId { get; set; }
        public Gender? Gender { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }


        public List<Color>? Colors { get; set; } = new List<Color>();

        public List<Size>? Sizes { get; set; } = new List<Size>();

    }
}
