using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Reimbursement_Operation
{
    public interface IReimbursement_Operation
    {
        void CreateReimbursement(Reimbursement reim);
        IEnumerable<object> getReimbursementsforUser(int reimId);

        /*Reimbursement GetReimbursement(Reimbursement entity);
        IEnumerable<object> getAllPendingRequests();
        IEnumerable<object> getAllAcceptedRequests();
        IEnumerable<object> getAllDeclinedRequests();*/
        void DeleteReimbursement(int reimId);
        /*void DeclineReimbursement(int reimId);
        void ApproveReimbursement(AdminDashboardEntity admin);*/
        void EditReimbursement(Reimbursement reimbursement);
    }
}
