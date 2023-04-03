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
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        [Required]
        public int BrandId { get; set; }

        [Required]
        public int PresentationId { get; set; }

        [Required, StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string SKU { get; set; }

        [Required]
        public decimal MinumunStock { get; set; }

        [DefaultValue(false)]
        public bool? IsContainer { get; set; }

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

        public SubCategory? SubCategory { get; set; }  
        public Brand? Brand { get; set; }
        public Presentation? Presentation { get; set; }


    }
}
