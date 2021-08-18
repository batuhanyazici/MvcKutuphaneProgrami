using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBorrowService
    {
        List<Borrow> GetList();
        List<Borrow> GetListById(int id);
        void BorrowAdd(Borrow borrow);
        Borrow GetByID(int id);
        void BorrowDelete(Borrow borrow);
        void BorrowUpdate(Borrow borrow);
    }
}
