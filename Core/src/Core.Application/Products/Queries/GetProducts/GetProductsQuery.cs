using System;
using MediatR;

namespace Core.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<ProductDto>>;
}

