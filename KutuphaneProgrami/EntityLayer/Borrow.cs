using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Borrow:BaseEntity
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime BringDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public bool IsCome { get; set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
