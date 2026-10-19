using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Domain.Products
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int StockQty { get; private set; }
    }
}
