namespace BLL.Interfaces.Models
{
    public class CreateProduct
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
