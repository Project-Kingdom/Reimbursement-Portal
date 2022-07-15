using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Admin_Operation
{
    public interface IAdmin_Operation
    {
        IEnumerable<object> GetReimbursement();
        IEnumerable<object> getAllPendingRequests();
        IEnumerable<object> getAllAcceptedRequests();
        IEnumerable<object> getAllDeclinedRequests();
        void DeclineReimbursement(int reimId);
        void ApproveReimbursement(AdminDashboardEntity admin);
    }
}
