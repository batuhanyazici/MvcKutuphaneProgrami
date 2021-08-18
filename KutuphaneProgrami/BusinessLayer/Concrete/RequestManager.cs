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
    public class RequestManager : IRequestService
    {
        IRequestDal _requestdal;

        public RequestManager(IRequestDal requestdal)
        {
            _requestdal = requestdal;
        }

        public void BorrowRequestAdd(BorrowRequest borrowRequest)
        {
            _requestdal.Insert(borrowRequest);
        }

        public void BorrowRequestDelete(BorrowRequest borrowRequest)
        {
            _requestdal.Delete(borrowRequest);
        }

        public void BorrowRequestUpdate(BorrowRequest borrowRequest)
        {
            _requestdal.Update(borrowRequest);
        }

        public BorrowRequest GetByID(int id)
        {
            return _requestdal.GetById(id);
        }

        public List<BorrowRequest> GetList()
        {
            return _requestdal.List();
        }
    }
}
