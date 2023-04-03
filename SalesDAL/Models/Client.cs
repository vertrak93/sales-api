using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.Conventions;
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
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [Required, StringLength(50)]
        public string ClientFirstName { get; set; }

        [Required, StringLength(50)]
        public string ClientLastName { get; set; }

        [Required, StringLength(100)]
        public string ClientFullName { get; set; }

        [Required, StringLength(50)]
        public string ClientNIT { get; set; }

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
    }
}
