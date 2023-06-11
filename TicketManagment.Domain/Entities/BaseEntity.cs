using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagment.Domain.Entities
{
    public partial class BaseEntity
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [Column("UpdatedDateTime")]
        public DateTime? UpdatedDateTime { get; set; }
    }
}
