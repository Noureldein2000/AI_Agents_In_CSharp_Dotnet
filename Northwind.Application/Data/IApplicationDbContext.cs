using Microsoft.EntityFrameworkCore;

using Northwind.Domain.Orders;
using Northwind.Domain.Products;

namespace Northwind.Application.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; }
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
