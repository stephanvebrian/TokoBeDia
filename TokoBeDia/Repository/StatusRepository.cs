using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Repository
{
    public class StatusRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static List<Status> findAll()
        {
            var status = db.Status.ToList();
            return status;
        }
    }
}