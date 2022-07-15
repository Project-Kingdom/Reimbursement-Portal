using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }

        [StringLength(20)]
        public string UserPanNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string UserBank { get; set; }

        [Required]
        public string UserBAN { get; set; }

        [Required]
        [StringLength(20)]
        public string Approver { get; set; }
    }
}
