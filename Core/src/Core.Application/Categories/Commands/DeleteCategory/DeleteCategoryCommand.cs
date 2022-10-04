using System;
using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Categories.Commands.DeleteCategory
{
   
        public record DeleteCategoryCommand(int Id) : IRequest;

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
        {
            private readonly IApplicationDbContext _context;
            public DeleteCategoryCommandHandler(IApplicationDbContext applicationDbContext)
            {
                this._context = applicationDbContext;
            }
            public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
            var entity = await _context.Categories.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            if (entity == null)
            {
                throw new Exception("");
            }
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
            }

        }
    
}

