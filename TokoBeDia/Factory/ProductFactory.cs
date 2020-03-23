using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Factory
{
    public class ProductFactory
    {
        public static Product createProduct(string name, int productTypeId,int price, int stock)
        {
            return new Product()
            {
                Name = name,
                ProductTypeId = productTypeId,
                Price = price,
                Stock = stock
            };
        }
    }
}