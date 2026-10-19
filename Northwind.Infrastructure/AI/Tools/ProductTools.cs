using ModelContextProtocol.Server;
using Northwind.Domain.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Northwind.Infrastructure.AI.Tools
{
    [McpServerToolType]
    public sealed class ProductTools(IProdcutReposiotory prodcutReposiotory)
    {
        [McpServerTool]
        [Description("Get a product by its ID.")]
        public async Task<Product?> GetProductByIdAsync(
            [Description("The Id of the product to retrieve.")]
        int id)
        {
            return await prodcutReposiotory.GetProductByIdAsync(id);
        }

        [McpServerTool]
        [Description("Search all products by name.")]
        public async Task<IEnumerable<Product>> SearchProductsAsync(
            [Description("The name of the products to search for.")]
        string name)
        {
            return await prodcutReposiotory.SearchProductsAsync(name);
        }

        [McpServerTool]
        [Description("Check if a product is available in the specified quantity.")]
        public async Task<bool> IsProductAvailableAsync(
            [Description("The Id of the product to check.")]
        int productId,
            [Description("The quantity to check for availability.")]
        int qty)
        {
            return await prodcutReposiotory.IsProductAvalilable(productId, qty);
        }
    }
}
