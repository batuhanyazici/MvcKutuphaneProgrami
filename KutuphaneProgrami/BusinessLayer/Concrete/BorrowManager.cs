using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BorrowManager : IBorrowService
    {
        IBorrowDal _borrowdal;

        public BorrowManager(IBorrowDal borrowdal)
        {
            _borrowdal = borrowdal;
        }

        public void BorrowAdd(Borrow borrow)
        {
            _borrowdal.Insert(borrow);
        }

        public void BorrowDelete(Borrow borrow)
        {
            _borrowdal.Delete(borrow);
        }

        public void BorrowUpdate(Borrow borrow)
        {
            _borrowdal.Update(borrow);
        }

        public Borrow GetByID(int id)
        {
            return _borrowdal.GetById(id);
        }

        public List<Borrow> GetList()
        {
            return _borrowdal.List();
        }

        public List<Borrow> GetListById(int id)
        {
            return _borrowdal.List(x => x.Id == id);
        }
    }
}
