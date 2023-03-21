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
    public class Access
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccessId { get; set; }

        [Required, StringLength(100)]
        public string AccessName { get; set; }

        [Required, DefaultValue(false)]
        public bool Active { get; set; }

        public ICollection<AccessRole>? AccessRole { get; set;}

    }
}
