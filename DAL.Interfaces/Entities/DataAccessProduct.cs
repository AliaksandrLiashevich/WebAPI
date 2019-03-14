namespace DAL.Interfaces.Entities
{
    public class DataAccessProduct
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public DataAccessCategory Category { get; set; }
    }
}
