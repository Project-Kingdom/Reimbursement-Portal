using Data_Access_Layer.Models;
using Data_Access_Layer.RP_DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Admin_Operation
{
    public class AdminOperation : IAdmin_Operation
    {
        private readonly RP_Context db;

        public AdminOperation(RP_Context context)
        {
            this.db = context;
        }
        public void ApproveReimbursement(AdminDashboardEntity admin)
        {
            Reimbursement r = db.Reimbursement.FirstOrDefault(x => x.ReimbursementId == admin.ReimbursementId);
            r.RequestPhase = "Processed";
            db.AdminDashboardEntity.Add(admin);
            db.SaveChanges();
        }

        public void DeclineReimbursement(int reimId)
        {
            Reimbursement entity = db.Reimbursement.FirstOrDefault(r => r.ReimbursementId == reimId);
            entity.RequestPhase = "Declined";
            db.SaveChanges();
        }

        public IEnumerable<object> getAllAcceptedRequests()
        {
            return (from r in db.Reimbursement

                    join e in db.User
                    on r.UserId equals e.UserId
                    where r.RequestPhase == "Processed"
                    select new
                    {
                        ReimbursementId = r.ReimbursementId,
                        ReimbursementType = r.ReimbursementType,
                        RequestedBy = e.UserEmail,
                        Date = r.Date,
                        RequestedValue = r.RequestedValue,
                        Currency = r.Currency,
                        Receipt = r.Receipt,
                        /*Image = r.Image*/
                    }).ToList();
        }

        public IEnumerable<object> getAllDeclinedRequests()
        {
            return (from r in db.Reimbursement

                    join e in db.User
                    on r.UserId equals e.UserId
                    where r.RequestPhase == "Declined"
                    select new
                    {
                        ReimbursementId = r.ReimbursementId,
                        ReimbursementType = r.ReimbursementType,
                        RequestedBy = e.UserEmail,
                        Date = r.Date,
                        RequestedValue = r.RequestedValue,
                        Currency = r.Currency,
                        Receipt = r.Receipt,
                        /*Image = r.Image*/
                    }).ToList();
            /*IEnumerable<Reimbursement> entityList = db.Reimbursement.Where(t => t.RequestPhase == "Declined").ToList();
            return entityList;*/
        }

        public IEnumerable<object> getAllPendingRequests()
        {
            return (from r in db.Reimbursement

                    join e in db.User
                    on r.UserId equals e.UserId
                    where r.RequestPhase == "To be processed"
                    select new
                    {
                        ReimbursementId = r.ReimbursementId,
                        ReimbursementType = r.ReimbursementType,
                        RequestedBy = e.UserEmail,
                        Date = r.Date,
                        RequestedValue = r.RequestedValue,
                        Currency = r.Currency,
                        Receipt = r.Receipt,
                        /*Image = r.Image*/
                    }).ToList();
        }
        public IEnumerable<object> GetReimbursement()
        {
            return db.Reimbursement.ToList();
            //db.Reimbursement.FirstOrDefault(r => r.ReimbursementId == entity.ReimbursementId);
        }
        /*public Reimbursement GetReimbursement(Reimbursement entity)
        {
            Reimbursement result = db.Reimbursement.ToList()<Reimbursement >;
                //db.Reimbursement.FirstOrDefault(r => r.ReimbursementId == entity.ReimbursementId);
            return result;
        }*/
    }
}
