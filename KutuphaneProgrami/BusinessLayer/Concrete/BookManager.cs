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
    public class BookManager : IBookService
    {
        IBookDal _bookdal;

        public BookManager(IBookDal bookdal)
        {
            _bookdal = bookdal;
        }

        public void BookAdd(Book book)
        {
            _bookdal.Insert(book);
        }

        public void BookDelete(Book book)
        {
            _bookdal.Delete(book);
        }

        public List<Book> BookList()
        {
            return _bookdal.List(x => x.Total > 0);
        }

        public void BookUpdate(Book book)
        {
            _bookdal.Update(book);
        }

        public Book GetByID(int id)
        {
            return _bookdal.GetById(id);
        }

        public List<Book> GetList()
        {
            return _bookdal.List();
        }

        public List<Book> PenaltyAddList()
        {
            return _bookdal.List(x => x.Borrow.ArrivalDate == null && DateTime.Now > x.Borrow.BringDate);
        }

        public List<Book> PenaltyDecreaseList()
        {
            return _bookdal.List(x => x.Borrow.ArrivalDate != null && x.User.Penalty>0);
        }
    }
}
