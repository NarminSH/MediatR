using System;
using Core.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCategoryCommandValidator(IApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;

            RuleFor(v => v.CategoryName).NotEmpty().WithMessage("Category name is required").
                MaximumLength(200).WithMessage("category name must not exceed 200 characters").
                MustAsync(BeUniqueName).WithMessage("The specified Category name already exists"); ;
        }
        public async Task<bool> BeUniqueName(UpdateCategoryCommand model, string categoryName, CancellationToken cancellationToken)
        {
            return await _context.Categories.Where(x => x.Id != model.Id).
                AllAsync(x => x.CategoryName != categoryName, cancellationToken);
        }
    }
}

