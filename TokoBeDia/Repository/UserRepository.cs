using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TokoBeDia.Factory;

namespace TokoBeDia.Repository
{
    public class UserRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static bool add(string email, string name, string password, string gender)
        {
            var user = UserFactory.createUser(email, name, password, gender);
            try
            {
                var u = db.Users.Where(_ => _.Email.Equals(email));
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR: ");
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
        }

        public static List<User> findAll()
        {
            var users = db.Users.ToList();
            return users;
        }

        public static User findById(int id)
        {
            var user = db.Users.Where(u => u.Id == id)
                        .Include(_ => _.Status)
                        .Include(_ => _.Role)
                        .FirstOrDefault();

            return user;
        }

        public static User findByEmail(string email)
        {
            var user = db.Users.Where(u => u.Email.Equals(email))
                                .Include(_ => _.Status)
                                .Include(_ => _.Role)
                                .FirstOrDefault();
            //var user = db.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();

            return user;
        }

        public static User findByEmail(string email, string password)
        {
            var user = db.Users.Where(u => ( u.Email.Equals(email) && u.Password.Equals(password) && u.StatusId == 1 ))
                                .Include(_ => _.Status)
                                .Include(_ => _.Role)
                                .FirstOrDefault();

            return user;
        }

        public static bool edit(int id, string name, string email, string gender)
        {
            var u = db.Users.Where(_ => _.Id == id).FirstOrDefault();

            u.Name = name;
            u.Email = email;
            u.Gender = gender;

            db.SaveChanges();

            return true;
        }

        public static bool editPassword(int id, string newPassword)
        {
            var u = db.Users.Where(_ => _.Id == id).FirstOrDefault();

            u.Password = newPassword;

            db.SaveChanges();

            return true;
        }

        public static bool editStatus(int id, int statusId)
        {
            var u = db.Users.Where(_ => _.Id == id).FirstOrDefault();
            u.StatusId = statusId;

            db.SaveChanges();

            return true;
        }


        public static bool delete(int id)
        {
            var u = db.Users.Where(_ => _.Id == id).FirstOrDefault();

            db.Users.Remove(u);
            db.SaveChanges();

            return true;
        }
    }
}