using System;
using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(int Id) : IRequest;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteProductCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception(""); //todo add exception
            }
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}

