using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;
using TokoBeDia.Repository;

namespace TokoBeDia.Handler
{
    public class CartHandler
    {
        public static bool add(int userId, int productId, int qty)
        {
            var cart = CartRepository.findByUserIdAndProductId(userId, productId);

            if (cart == null)
            {
                CartRepository.add(userId, productId, qty);
            }else
            {
                CartRepository.addQty(userId, productId, qty);
            }

            return true;
        }
    }
}