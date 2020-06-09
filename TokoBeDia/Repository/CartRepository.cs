using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;

namespace TokoBeDia.Repository
{
    public class CartRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static bool add(int userId, int productId, int qty)
        {
            var cart = CartFactory.createCart(userId, productId, qty);

            db.Carts.Add(cart);
            db.SaveChanges();

            return true;
        }

        public static bool addQty(int userId, int productId, int qty)
        {
            var cart = findByUserIdAndProductId(userId, productId);
            int qtyNew = cart.Quantity + qty;
            cart.Quantity = qtyNew;

            db.SaveChanges();

            return true;
        }

        public static List<Cart> findAll()
        {
            var carts = db.Carts.ToList();

            return carts;
        }

        public static Cart findById(int id)
        {
            var cart = db.Carts.Where(_ => _.Id == id).FirstOrDefault();

            return cart;
        }

        public static List<Cart> findByUserId(int userId)
        {
            var carts = db.Carts.Where(_ => _.UserId == userId).ToList();

            return carts;
        }
    
        public static Cart findByProductId(int productId)
        {
            var cart = db.Carts.Where(_ => _.ProductId == productId).FirstOrDefault();

            return cart;
        }

        public static Cart findByUserIdAndProductId(int userId, int productId)
        {
            var cart = db.Carts.Where(_ => _.UserId == userId && _.ProductId == productId).FirstOrDefault();

            return cart;
        }
        
        public static bool edit(int id, int userId, int productId, int qty)
        {
            var cart = db.Carts.Where(_ => _.Id == id).FirstOrDefault();
            cart.UserId = userId;
            cart.ProductId = productId;
            cart.Quantity = qty;

            db.SaveChanges();

            return true;
        }

        public static bool remove(int id)
        {
            var cart = db.Carts.Where(_ => _.Id == id).FirstOrDefault();

            db.Carts.Remove(cart);
            db.SaveChanges();

            return true;
        }
    }
}