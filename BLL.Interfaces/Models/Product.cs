﻿namespace BLL.Interfaces.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
