using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;

namespace TokoBeDia.Repository
{
    public class ProductTypeRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static void add(string name, string description)
        {
            var productType = ProductTypeFactory.createProductType(name, description);

            db.ProductTypes.Add(productType);
            db.SaveChanges();
        }

        public static List<ProductType> findAll()
        {
            return db.ProductTypes.ToList();
        }

        public static ProductType findById(int id)
        {
            var pt = db.ProductTypes.Where(_ => _.Id == id).FirstOrDefault();

            return pt;
        }

        public static ProductType findByName(string name)
        {
            var productType = db.ProductTypes.Where(_ => _.Name.Equals(name)).FirstOrDefault();

            return productType;
        }

        public static void edit(int id, string name, string description)
        {
            var pt = db.ProductTypes.Where(_ => _.Id == id).FirstOrDefault();

            pt.Name = name;
            pt.Description = description;

            db.SaveChanges();
        }

        public static void remove(int id)
        {
            var pt = db.ProductTypes.Where(_ => _.Id == id).FirstOrDefault();

            db.ProductTypes.Remove(pt);
            db.SaveChanges();
        }
    }
}