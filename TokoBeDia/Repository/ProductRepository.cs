using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;

namespace TokoBeDia.Repository
{
    public class ProductRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static bool add(string name , int productTypeId, int price, int stock)
        {
            var p = ProductFactory.createProduct(name, productTypeId, price, stock);

            db.Products.Add(p);
            db.SaveChanges();
            
            return true;
        }

        public static bool reduceStock(int id, int reduceQty)
        {
            var product = db.Products.Where(_ => _.Id == id).FirstOrDefault();
            var stock = product.Stock - reduceQty;

            product.Stock = stock;

            db.SaveChanges();
            return true;
        }

        public static bool addStock(int id, int addQty)
        {
            var product = db.Products.Where(_ => _.Id == id).FirstOrDefault();
            var stock = product.Stock + addQty;

            product.Stock = stock;

            db.SaveChanges();
            return true;
        }

        public static List<Product> findTopFive()
        {
            var products = db.Products.ToList();

            var newProducts = new List<Product>();
            var countItem = products.Count;

            if (countItem > 5)
            {
                var rand = new Random();
                for (int a = 0; a < 5; a++)
                {
                    var randomNum = rand.Next(0, countItem);
                    newProducts.Add(products[randomNum]);
                }

                return newProducts;
            }

            return products;
        }

        public static List<Product> findAll()
        {
            var p = db.Products.ToList();

            return p;
        }

        public static Product findById(int id)
        {
            var p = db.Products.Where(_ => _.Id == id).FirstOrDefault();

            return p;
        }

        public static bool edit(int id, string name, int stock, int price)
        {
            var p = db.Products.Where(_ => _.Id == id).FirstOrDefault();
            p.Name = name;
            p.Stock = stock;
            p.Price = price;

            db.SaveChanges();

            return true;
        }

        public static bool delete(int id)
        {
            var p = db.Products.Where(_ => _.Id == id).FirstOrDefault();

            db.Products.Remove(p);
            db.SaveChanges();

            return true;
        }
    }
}