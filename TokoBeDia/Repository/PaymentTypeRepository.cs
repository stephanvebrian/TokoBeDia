using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;

namespace TokoBeDia.Repository
{
    public class PaymentTypeRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static void add(string type)
        {
            var paymentType = PaymentTypeFactory.createPaymentType(type);

            db.PaymentTypes.Add(paymentType);
            db.SaveChanges();
        }

        public static List<PaymentType> findAll()
        {
            return db.PaymentTypes.ToList();
        }

        public static PaymentType findById(int id)
        {
            var paymentType = db.PaymentTypes.Where(_ => _.Id == id).FirstOrDefault();

            return paymentType;
        }

        public static PaymentType findByType(string type)
        {
            var paymentType = db.PaymentTypes.Where(_ => _.Type.Equals(type)).FirstOrDefault();

            return paymentType;
        }
        
        public static void edit(int id, string type)
        {
            var paymentType = db.PaymentTypes.Where(_ => _.Id == id).FirstOrDefault();

            paymentType.Type = type;

            db.SaveChanges();
        }

        public static void remove(int id)
        {
            var paymentType = db.PaymentTypes.Where(_ => _.Id == id).FirstOrDefault();

            db.PaymentTypes.Remove(paymentType);
            db.SaveChanges();
        }
    }
}