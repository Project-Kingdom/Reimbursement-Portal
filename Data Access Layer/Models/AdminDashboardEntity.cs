using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class AdminDashboardEntity
    {
        [Key]
        public int UserId { get; set; }

        public string ApprovedBy { get; set; }

        public int ApprovedValue { get; set; }

        public string Description { get; set; }

        public int ReimbursementId { get; set; }
        public virtual Reimbursement Reimbursement { get; set; }
    }
}
