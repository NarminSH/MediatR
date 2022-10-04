using System;
using Core.Application.Common.Interfaces;
using Core.Domain.Entity;
using MediatR;

namespace Core.Application.Categories.Queries.GetCategories
{

    public record GetCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;
   
}

