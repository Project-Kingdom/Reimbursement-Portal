using Data_Access_Layer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Data_Access_Layer.Models
{
    public class Reimbursement
    {
        [Key]
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public int ReimbursementId { get; set; }

        [Required(ErrorMessage = "Please Enter Event Date")]
        /*[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]*/
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ReimbursementType { get; set; }

        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "decimal(20, 2)")]
        public decimal RequestedValue { get; set; }
        
        [Required(ErrorMessage = "Required")]
        public string Currency { get; set; }

        /*[Required]*/
        [StringLength(50)]
        public string RequestPhase { get; set; }

        public string Receipt { get; set; }

        public int UserId { get; set; }
       /* public virtual User User { get; set; }*/

    }
}
