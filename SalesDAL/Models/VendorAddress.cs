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
    public class VendorAddress
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorAddressId { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public int AddressID { get; set; }

        #region Modify Control

        [DefaultValue(true)]
        public bool? Active { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(100)]
        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        #endregion

        public Vendor? Vendor { get; set; }
        public Address? Address { get; set; }

    }
}
