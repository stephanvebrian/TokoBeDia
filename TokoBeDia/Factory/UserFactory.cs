using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Factory
{
    public class UserFactory
    {
        //CRUD
        public static User createUser(string email, string name, string password, string gender)
        {
            /*
             * RoleId = 1 (Admin), 2 (Member), 3 (Guest)
             * StatusId = 1 (Active), 2 (Inactive)
             */
            return new User() {
                Email = email,
                Name = name,
                Password = password,
                RoleId = 2,
                StatusId = 1
            };
        }
    }
}