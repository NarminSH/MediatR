using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.Categories.Queries.GetCategories;
using Core.Application.Common.Interfaces;
using Core.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Products.Queries.GetProduct
{
    public record GetProductQuery : IRequest<IEnumerable<ProductDto>>
    {
        public int Id { get; set; }
    };

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<ProductDto>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var category = await _context.Products
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .Where(x => x.Id == request.Id).ToListAsync(cancellationToken);

            if (category == null)
            {
                throw new Exception(""); //todo custom exception
            }

            return category;
        }
    }
}

