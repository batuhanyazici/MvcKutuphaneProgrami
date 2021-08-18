using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class BorrowRequest:BaseEntity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime BringDate { get; set; }
        public bool Given { get; set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public virtual Borrow Borrow { get; set; }

    }
}
