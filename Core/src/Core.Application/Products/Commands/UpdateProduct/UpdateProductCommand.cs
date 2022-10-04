using System;
using Core.Application.Common.Interfaces;
using MediatR;

namespace Core.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int CategoryId { get; set; }

    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new Exception(""); //todo not found exception sinifi hazirlanacak
            }
            entity.ProductName = request.ProductName;
            entity.UnitPrice = request.UnitPrice;
            entity.UnitsInStock = request.UnitsInStock;
            entity.CategoryId = request.CategoryId;

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

    }
}

