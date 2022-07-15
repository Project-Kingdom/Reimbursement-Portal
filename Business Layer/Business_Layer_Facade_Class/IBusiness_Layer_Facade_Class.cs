using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Business_Layer_Facade_Class
{
    public interface IBusiness_Layer_Facade_Class
    {
        void CreateUser(User user);
        User GetAnUser(int userId);
        bool Login(User user);
        int GetUserByEmail(string email);
        string GetIsApproverByEmail(string email);
        User GetAllUserDetailByEmail(string email);
        void CreateReimbursement(Reimbursement reim);
        IEnumerable<object> GetReimbursement();
        IEnumerable<object> getReimbursementsforUser(int reimId);
        IEnumerable<object> getAllPendingRequests();
        IEnumerable<object> getAllAcceptedRequests();
        IEnumerable<object> getAllDeclinedRequests();
        void DeleteReimbursement(int id);
        void DeclineReimbursement(int id);
        void ApproveReimbursement(AdminDashboardEntity admin);
        void EditReimbursement(Reimbursement reim);
    }
}
