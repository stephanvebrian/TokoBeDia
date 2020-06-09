using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Factory
{
    public class CartFactory
    {
        public static Cart createCart(int userId, int productId, int qty)
        {
            return new Cart()
            {
                UserId = userId,
                ProductId = productId,
                Quantity = qty
            };
        }
    }
}