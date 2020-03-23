using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Factory
{
    public class ProductTypeFactory
    {
        public static ProductType createProductType(string name, string description)
        {
            return new ProductType()
            {
                Name = name,
                Description = description,
            };
        }
    }
}