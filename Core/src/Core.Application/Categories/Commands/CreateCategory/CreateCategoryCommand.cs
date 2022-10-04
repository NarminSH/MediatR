using System;
using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using MediatR;

namespace Core.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateCategoryCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Category
            {
                CategoryName = request.CategoryName,
                Description = request.Description
            };
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            throw default;
        }

    }

}

