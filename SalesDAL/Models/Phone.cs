using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SalesDAL.Models
{
    public class Phone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PhoneId { get; set; }

        [Required, MaxLength(100)]
        public string PhoneNumber { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }

        [DefaultValue(true)]
        public bool? Active { get; set; } = true;

        #region Modify Control
        [StringLength(100)]
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        #endregion
    }
}
