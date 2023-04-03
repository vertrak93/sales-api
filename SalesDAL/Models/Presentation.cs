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
    public class Presentation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PresentationId { get; set; }

        [Required, StringLength(100)]
        public string PresentationName { get;set; }

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

        public ICollection<Product>? Product { get; set;}
    }
}
