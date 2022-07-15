using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.User_Operation
{
    public interface IUser_Operation
    {
        int GetUserByEmail(string email);
        User GetAllUserDetailByEmail(string email);
        string GetIsApproverByEmail(string email);
        User GetAnUser(int userId);
        bool Login(User user);
        void CreateUser(User user);
    }
}
