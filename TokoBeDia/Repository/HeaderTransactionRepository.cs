using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Repository
{
    public class HeaderTransactionRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static List<HeaderTransaction> findAll()
        {
            var headerTr = db.HeaderTransactions.ToList();

            return headerTr;
        }

        public static List<HeaderTransaction> findAllByUserId(int userId)
        {
            var headerTr = db.HeaderTransactions.Where(_ => _.UserId == userId).ToList();

            return headerTr;
        }
    }
}