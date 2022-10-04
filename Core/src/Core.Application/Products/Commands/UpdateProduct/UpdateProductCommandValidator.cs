using System;
using Core.Application.Common.Interfaces;
using Core.Application.Products.Commands.CreateProduct;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandValidator(IApplicationDbContext applicationDbContext)
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

