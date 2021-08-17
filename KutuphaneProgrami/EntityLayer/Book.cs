using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Book:BaseEntity
    {
        [StringLength(50)]
        public string BookName { get; set; }
        [StringLength(20)]
        public string BookNo { get; set; }
        public int Total { get; set; }
        public DateTime BookAddDate { get; set; }
        public int WriterId { get; set; }
        public int CategoryId { get; set; }
        public bool Status { get; set; }
        public virtual Writer Writer { get; set; }
        public virtual Category Categories { get; set; }
        public virtual Borrow Borrow { get; set; }
        public virtual User User { get; set; }
        public virtual List<Borrow> BorrowBooks { get; set; }
    }
}
