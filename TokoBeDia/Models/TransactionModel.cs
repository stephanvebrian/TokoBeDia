using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public User User { get; set; }
        public PaymentType PaymentType { get; set; }
        public string PaymentTypeName { get; set; }
        public DateTime Date { get; set; }
        //public List<ProductTransaction> Products { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

    //public class ProductTransaction
    //{
    //    public Product Product { get; set; }
    //    public int Quantity { get; set; }
    //}
}