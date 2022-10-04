using System;
using System.Collections.Generic;
using Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
    
}

