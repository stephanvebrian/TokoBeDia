using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Repository
{
    public class RoleRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static List<Role> findAll()
        {
            var roles = db.Roles.ToList();
            return roles;
        }

    }
}