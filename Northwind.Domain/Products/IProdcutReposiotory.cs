using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Domain.Products
{
    public interface IProdcutReposiotory
    {
        Task<Product?> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> SearchProductsAsync(string search);
        Task<bool> IsProductAvalilable(int productId, int qty);
    }
}
