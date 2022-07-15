using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.RP_DbContext
{
    public class RP_Context : DbContext
    {
        public RP_Context(DbContextOptions<RP_Context> options) : base(options)
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<Reimbursement> Reimbursement { get; set; }
        public DbSet<AdminDashboardEntity> AdminDashboardEntity { get; set; }

    }
}
