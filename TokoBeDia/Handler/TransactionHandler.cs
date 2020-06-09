using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokoBeDia.Repository;
using TokoBeDia.Models;

namespace TokoBeDia.Handler
{
    
    public class TransactionHandler
    {
        public static List<TransactionModel> findAll()
        {
            var transactionModel = new List<TransactionModel>();

            var headerTransaction = HeaderTransactionRepository.findAll();

            foreach (var itemHeader in headerTransaction)
            {
                var detailTransaction = DetailTransactionRepository.findAllByTransactionId(itemHeader.Id);
                foreach (var itemDetail in detailTransaction)
                {
                    var paymentType = PaymentTypeRepository.findById(itemHeader.PaymentTypeId ?? 1);
                    var product = ProductRepository.findById(itemDetail.ProductId);
                    var qty = itemDetail.Quantity ?? 0;
                    int price = int.Parse(product.Price.ToString()) * qty;

                    transactionModel.Add(new TransactionModel()
                    {
                        Id = itemHeader.Id,
                        User = UserRepository.findById(itemHeader.UserId),
                        Date = itemHeader.Date ?? DateTime.Now,
                        PaymentType = paymentType,
                        PaymentTypeName = paymentType.Type,
                        Product = product,
                        ProductName = product.Name,
                        Quantity = qty,
                        Price = price
                    });
                }
            }

            return transactionModel;
        }

        public static List<TransactionModel> findByUserId(int userId)
        {
            var transactionModel = new List<TransactionModel>();

            var headerTransaction = HeaderTransactionRepository.findAllByUserId(userId);

            foreach (var itemHeader in headerTransaction)
            {
                var user = UserRepository.findById(itemHeader.UserId);
                var detailTransaction = DetailTransactionRepository.findAllByTransactionId(itemHeader.Id);
                foreach (var itemDetail in detailTransaction)
                {
                    var paymentType = PaymentTypeRepository.findById(itemHeader.PaymentTypeId ?? 1);
                    var product = ProductRepository.findById(itemDetail.ProductId);
                    var qty = itemDetail.Quantity ?? 0;
                    int price = int.Parse(product.Price.ToString()) * qty;

                    transactionModel.Add(new TransactionModel()
                    {
                        Id = itemHeader.Id,
                        User = user,
                        Date = itemHeader.Date ?? DateTime.Now,
                        PaymentType = paymentType,
                        PaymentTypeName = paymentType.Type,
                        Product = product,
                        ProductName = product.Name,
                        Quantity = qty,
                        Price = price
                    });
                }

            }

            return transactionModel;
        }

        public static object getTotalTransactionAdmin()
        {
            var transactions = findAll();
            int totalQty = 0;
            int totalPrice = 0;

            foreach (var item in transactions)
            {
                totalQty += item.Quantity;
                totalPrice += item.Price;
            }

            return new { TotalQuantity = totalQty, TotalPrice = totalPrice };
        }

        public static object getTotalTransactionMember(int userId)
        {
            var transactions = findByUserId(userId);
            int totalQty = 0;
            int totalPrice = 0;

            foreach (var item in transactions)
            {
                totalQty += item.Quantity;
                totalPrice += item.Price;
            }

            return new { TotalQuantity = totalQty, TotalPrice = totalPrice };
        }

    }
}