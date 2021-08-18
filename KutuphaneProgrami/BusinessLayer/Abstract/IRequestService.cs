using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRequestService
    {
        List<BorrowRequest> GetList();
        void BorrowRequestAdd(BorrowRequest borrowRequest);
        BorrowRequest GetByID(int id);
        void BorrowRequestDelete(BorrowRequest borrowRequest);
        void BorrowRequestUpdate(BorrowRequest borrowRequest);
    }
}
