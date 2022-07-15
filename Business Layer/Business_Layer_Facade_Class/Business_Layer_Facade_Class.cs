using Business_Layer.Admin_Operation;
using Business_Layer.Reimbursement_Operation;
using Business_Layer.User_Operation;
using Data_Access_Layer.Models;
using Data_Access_Layer.RP_DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Business_Layer_Facade_Class
{
    public class BusinessLayerFacadeClass : IBusiness_Layer_Facade_Class
    {
        private readonly UserOperation _user_operation;
        private readonly ReimbursementOperation _reimbursement_operation;
        private readonly AdminOperation _admin_operation;

        public BusinessLayerFacadeClass(UserOperation userop, ReimbursementOperation reimop, AdminOperation adop)
        {
            this._user_operation = userop;
            this._reimbursement_operation = reimop;
            this._admin_operation = adop;
        }
        public void CreateUser(User user)
        {
            _user_operation.CreateUser(user);
        }

        public User GetAnUser(int userId)
        {
            return _user_operation.GetAnUser(userId);
        }

        public bool Login(User user)
        {
            return _user_operation.Login(user);
        }
        public int GetUserByEmail(string email)
        {
            return _user_operation.GetUserByEmail(email);
        }

        public string GetIsApproverByEmail(string email)
        {
            return _user_operation.GetIsApproverByEmail(email);
        }

        public User GetAllUserDetailByEmail(string email)
        {
            return _user_operation.GetAllUserDetailByEmail(email);
        }

        public void CreateReimbursement(Reimbursement reim)
        {
            _reimbursement_operation.CreateReimbursement(reim);
        }
        public IEnumerable<object> getReimbursementsforUser(int reimId)
        {
            return _reimbursement_operation.getReimbursementsforUser(reimId);
        }
        
        public void DeleteReimbursement(int reimId)
        {
            _reimbursement_operation.DeleteReimbursement(reimId);
        }
        public void EditReimbursement(Reimbursement reim)
        {
            _reimbursement_operation.EditReimbursement(reim);
        }
        public IEnumerable<object> GetReimbursement()
        {
            return _admin_operation.GetReimbursement();
        }
        public IEnumerable<object> getAllPendingRequests()
        {
            return _admin_operation.getAllPendingRequests();
        }

        public IEnumerable<object> getAllAcceptedRequests()
        {
            return _admin_operation.getAllAcceptedRequests();
        }

        public IEnumerable<object> getAllDeclinedRequests()
        {
            return _admin_operation.getAllDeclinedRequests();
        }
        public void DeclineReimbursement(int id)
        {
            _admin_operation.DeclineReimbursement(id);
        }

        public void ApproveReimbursement(AdminDashboardEntity admin)
        {
            _admin_operation.ApproveReimbursement(admin);
        }
    }
}
