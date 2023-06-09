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
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } = 0;

        [StringLength(100)]
        public string Username { get; set; }

        [Required, StringLength(100)]
        public string FisrtName { get; set; }
        
        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(500)]
        public string Password { get; set; }

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

        public ICollection<UserRole>? UserRol { get; set; }

    }
}
