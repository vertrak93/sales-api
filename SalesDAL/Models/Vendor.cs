using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDAL.Models
{
    public class Vendor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorId { get; set; }

        [Required, MaxLength(50)]
        public string VendorName { get; set; }

        [Required, MaxLength(50)]
        public string TIN { get; set; } //Taxpayer Identification Number

        [DefaultValue(true)]
        public bool? Active { get; set; }

        #region Modify Control
        [StringLength(100)]
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        #endregion

        public ICollection<VendorBankAccount>? VendorBankAccount { get; set; }
        public ICollection<VendorPhone>? VendorPhone { get; set; }
        public ICollection<VendorAddress>? VendorAddress { get; set; }
    }
}
