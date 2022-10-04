using System;
using Core.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateCategoryCommandValidator(IApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;

            RuleFor(v => v.CategoryName).NotEmpty().WithMessage("Category name is required").
                MaximumLength(200).WithMessage("category name must not exceed 200 characters").
                MustAsync(BeUniqueName).WithMessage("The specified Category name already exists");
        }
        public async Task<bool> BeUniqueName(string categoryName, CancellationToken cancellationToken)
        {
            return await _context.Categories.AllAsync(x => x.CategoryName != categoryName, cancellationToken);
        }
       
    }
}

