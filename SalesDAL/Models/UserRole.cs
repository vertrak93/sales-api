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
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRolId { get; set; }

        [Required]
        public int RoleId { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [Required, DefaultValue(false)]
        public bool? Active { get; set; }

        #region Modify Control
        [Required, StringLength(100)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        #endregion

        public User User { get; set; }
        public Role Role { get; set; }

    }
}
