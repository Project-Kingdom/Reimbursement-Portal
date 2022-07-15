using Data_Access_Layer.Models;
using Data_Access_Layer.RP_DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Reimbursement_Operation
{
    public class ReimbursementOperation : IReimbursement_Operation
    {
        private readonly RP_Context db;

        public ReimbursementOperation(RP_Context context)
        {
            this.db = context;
        }
        public void CreateReimbursement(Reimbursement reim)
        {
            reim.RequestPhase = "To be processed";
            /*if (reim.Receipt == "")
            {
                reim.RecieptAttached = "No";
            }
            else
            {
                reim.RecieptAttached = "Yes";
            }*/


            db.Reimbursement.Add(reim);
            db.SaveChanges();
        }

        public void DeleteReimbursement(int reimId)
        {
            Reimbursement entity = db.Reimbursement.FirstOrDefault(r => r.ReimbursementId == reimId);
            db.Reimbursement.Remove(entity);
            db.SaveChanges();
        }

        public void EditReimbursement(Reimbursement reimbursement)
        {
            Reimbursement entity = db.Reimbursement.FirstOrDefault(r => r.ReimbursementId == reimbursement.ReimbursementId);
            entity.Date = reimbursement.Date;
            /*entity.RecieptAttached = reimbursementEntity.RecieptAttached;*/
            /*entity.Image = reimbursementEntity.Image;*/
            entity.Currency = reimbursement.Currency;
            entity.ReimbursementType = reimbursement.ReimbursementType;
            entity.RequestedValue = reimbursement.RequestedValue;

            db.SaveChanges();
        }

        public IEnumerable<object> getReimbursementsforUser(int reimId)
        {
            return (from r in db.Reimbursement
                    where r.UserId == reimId
                    join q in db.AdminDashboardEntity
                    on r.ReimbursementId equals q.ReimbursementId
                    into dataTable
                    from data in dataTable.DefaultIfEmpty()
                    select new
                    {
                        ReimbursementId = r.ReimbursementId,
                        ReimbursementType = r.ReimbursementType,
                        Date = r.Date,
                        RequestedValue = r.RequestedValue,
                        Currency = r.Currency,
                        RequestPhase = r.RequestPhase,
                        Receipt = r.Receipt,
                        ApprovedValue = data != null ? data.ApprovedValue : 0,
                        UserId = r.UserId
                    }).ToList().OrderByDescending(x => x.Date);
        }
    }
}
