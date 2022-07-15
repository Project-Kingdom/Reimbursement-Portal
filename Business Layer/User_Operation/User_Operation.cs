using Data_Access_Layer.Models;
using Data_Access_Layer.RP_DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.User_Operation
{
    public class UserOperation : IUser_Operation
    {
        private readonly RP_Context db;

        /*public object Id { get; }*/

        public UserOperation(RP_Context context)
        {
            this.db = context;
        }

        //Get all Users
        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> entityList = db.User;
            return db.User;
        }

        //Create an User
        public void CreateUser(User user)
        {
            if (user.UserEmail == "admin@gmail.com")
            {
                user.Approver = "Yes";
            }
            else
            {
                user.Approver = "No";
            }
            db.User.Add(user);
            db.SaveChanges();
        }
        //Get all User details through Email 
        public User GetAllUserDetailByEmail(string email)
        {
            User user = db.User.FirstOrDefault(e => e.UserEmail == email);
            return user;
        }
        //Get all User details through Id 
        public User GetAnUser(int userId)
        {
            User user = db.User.FirstOrDefault(e => e.UserId == userId);
            return user;
        }

        public string GetIsApproverByEmail(string email)
        {
            User user = db.User.FirstOrDefault(e => e.UserEmail == email);
            return user.Approver;
        }

        public int GetUserByEmail(string email)
        {
            User user = db.User.FirstOrDefault(e => e.UserEmail == email);
            return user.UserId;
        }

        //Login into Portal
        public bool Login(User user)
        {
            User valid = db.User.FirstOrDefault(e => e.UserEmail == user.UserEmail && e.UserPassword == user.UserPassword);
            if (valid != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
