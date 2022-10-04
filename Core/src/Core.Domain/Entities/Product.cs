using System;
using Core.Domain.Common;

namespace Core.Domain.Entity
{
    public class Product: BaseAuditableEntity
    {
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}

