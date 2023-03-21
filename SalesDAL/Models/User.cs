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

        [Required, DefaultValue(true)]
        public bool Active { get; set; }

        [Required, StringLength(100)]
        public string? CreatedBy { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public ICollection<UserRole>? UserRol { get; set; }

    }
}
