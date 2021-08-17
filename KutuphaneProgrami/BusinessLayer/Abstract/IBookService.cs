using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBookService
    {
        List<Book> GetList();
        void BookAdd(Book book);
        Book GetByID(int id);
        void BookDelete(Book book);
        void BookUpdate(Book book);
        List<Book> BookList();
        List<Book> PenaltyAddList();
        List<Book> PenaltyDecreaseList();
    }
}
