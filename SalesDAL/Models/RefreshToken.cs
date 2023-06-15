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
    public class RefreshToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RefreshTokenId { get; set; }

        [Required]
        public int UserdId { get; set; }

        [Required]
        public DateTime Expiration { get; set; }

        [Required]
        public string Token { get; set; }

        [DefaultValue(false)]
        public bool? Active { get; set; } = true;

        public User? User { get; set; }

    }
}
