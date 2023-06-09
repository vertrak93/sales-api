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
    public class SubCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubCategoryId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required, StringLength(100)]
        public string NameSubCatagory { get; set; }

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

        public Category? Category { get; set; }

        public ICollection<Product>? Product { get; set; }
    }
}
