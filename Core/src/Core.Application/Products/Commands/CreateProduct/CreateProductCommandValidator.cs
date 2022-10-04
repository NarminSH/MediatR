using System;
using Core.Application.Categories.Commands.CreateCategory;
using Core.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandValidator(IApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;

            RuleFor(v => v.ProductName).NotEmpty().WithMessage("Product name is required").
                MaximumLength(200).WithMessage("Product name must not exceed 200 characters").
                MustAsync(BeUniqueName).WithMessage("The specified Product name already exists");
        }
        public async Task<bool> BeUniqueName(string productName, CancellationToken cancellationToken)
        {
            return await _context.Products.AllAsync(x => x.ProductName != productName, cancellationToken);
        }

    }
}

