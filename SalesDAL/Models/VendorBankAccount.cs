﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDAL.Models
{
    public class VendorBankAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorBankAccountId { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public int BankAccoutId { get; set; }

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

        public Vendor? Vendor { get; set; }
        public BankAccount? BankAccount { get; set; }
    }
}
