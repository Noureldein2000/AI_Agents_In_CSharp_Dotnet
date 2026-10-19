using Microsoft.EntityFrameworkCore;

using Northwind.Application.Data;
using Northwind.Domain.Orders;
using Northwind.Domain.Products;

namespace Northwind.Infrastructure.Data
{
    public sealed class NorthwindDbContext(
    DbContextOptions<NorthwindDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(
                this.GetType().Assembly);
    }
}
