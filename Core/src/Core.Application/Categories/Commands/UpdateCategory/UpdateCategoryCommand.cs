using System;
using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using MediatR;

namespace Core.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

    }
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCategoryCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }
        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.FindAsync(new object[] {request.Id}, cancellationToken);
            if (entity ==null)
            {
                throw new Exception(""); //todo not found exception sinifi hazirlanacak
            }
            entity.CategoryName = request.CategoryName;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

    }
}

