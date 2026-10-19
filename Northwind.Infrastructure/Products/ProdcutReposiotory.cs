using Northwind.Application.Data;
using Northwind.Domain.Orders;
using Northwind.Domain.Products;
using System;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.Products
{
    public sealed class ProdcutReposiotory(
        IApplicationDbContext dbContext) : IProdcutReposiotory
    {
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> SearchProductsAsync(string search)
        {
            return await dbContext.Products.Where(p => p.Name.Contains(search)).AsNoTracking().ToListAsync();
        }

        public async Task<bool> IsProductAvalilable(int productId, int qty)
        {
            var product = await GetProductByIdAsync(productId);

            return product is not null && product.StockQty >= qty;
        }
    }
}
