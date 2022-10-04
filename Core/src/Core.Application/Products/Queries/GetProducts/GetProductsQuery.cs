using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.Categories.Queries.GetCategories;
using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<ProductDto>>;
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.AsNoTracking()
                 .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                 .OrderBy(x => x.ProductName)
                 .ToListAsync(cancellationToken);

            return products;
        }
    }
}

