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
    public class AccessRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccessRoleId { get; set; }

        [Required]
        public int AccessId { get; set; }
        
        [Required]
        public int RoleId { get; set; }

        [Required, DefaultValue(false)]
        public bool Active { get; set; }


        public Access Access { get; set; }

        public Role Role { get; set; }
        

    }
}