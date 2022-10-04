using System;
using Core.Domain.Entity;

namespace Core.Application.Products.Queries.GetProducts
{
    public class ProductDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int CategoryId { get; set; }
    }
}

