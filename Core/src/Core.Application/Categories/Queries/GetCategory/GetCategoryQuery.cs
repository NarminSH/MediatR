using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.Categories.Queries.GetCategories;
using Core.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Categories.Queries.GetCategory
{
    public record GetCategoryQuery : IRequest<IEnumerable<CategoryDto>>
    {
        public int Id { get; set; }
    };

    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IEnumerable<CategoryDto>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {

            var category = await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .Where(x => x.Id == request.Id).ToListAsync(cancellationToken);

            if (category == null)
            {
                throw new Exception(""); //todo custom exception
            }

            return category;
        }
    }
}

