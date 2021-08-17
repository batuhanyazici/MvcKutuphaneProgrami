using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class User:BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserSurname { get; set; }
        public string UserIdNumber { get; set; }
        [Required]
        public string UserPhone { get; set; }
        [Required]
        public DateTime SignDate { get; set; }
        [Required]
        public string UserMail { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public int Penalty { get; set; }
        [Required]
        public string Role { get; set; }
        public bool UserStatus { get; set; }
        public string OriginalPass { get; set; }
        public virtual List<Borrow> BorrowBooks { get; set; }

    }
}
