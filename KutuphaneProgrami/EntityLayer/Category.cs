using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Category:BaseEntity
    {
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(50)]
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
