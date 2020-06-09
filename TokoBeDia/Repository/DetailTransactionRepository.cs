using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Repository
{
    public class DetailTransactionRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static List<DetailTransaction> findAll()
        {
            var detailTr = db.DetailTransactions.ToList();

            return detailTr;
        }

        public static List<DetailTransaction> findAllByTransactionId(int transactionId)
        {
            var detailTr = db.DetailTransactions.Where(_ => _.TransactionId == transactionId).ToList();

            return detailTr;
        }

    }
}