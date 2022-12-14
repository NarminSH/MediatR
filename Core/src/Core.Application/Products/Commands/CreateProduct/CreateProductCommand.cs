using System;
using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using MediatR;

namespace Core.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int CategoryId { get; set; }

    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitsInStock = request.UnitsInStock,
                CategoryId = request.CategoryId
            };
            _context.Products.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

    }

}

