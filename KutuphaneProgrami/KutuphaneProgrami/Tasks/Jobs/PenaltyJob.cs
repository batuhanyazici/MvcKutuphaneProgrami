using BusinessLayer.Concrete;
using DataAccesLayer;
using DataAccesLayer.EntityFramework;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KutuphaneProgrami.Tasks.Jobs
{
//    public class PenaltyJob : IJob
//    {
//        BookManager bm = new BookManager(new EfBookDal());
//        UserManager um = new UserManager(new EfUserDal());
//        Context c = new Context();
//        //public Task Execute(IJobExecutionContext context)
//        //{
//        //    try
//        //    {
//        //        PeanltyAdd();
//        //        PeanltyDecrease();
//        //    }
//        //    catch
//        //    {

//        //    }
//        //}
//        //void PeanltyAdd()
//        //{
//        //    var bookvalues = bm.PenaltyAddList();
//        //    foreach (var item in bookvalues)
//        //    {
//        //        item.Borrow.User.Penalty += 1;
//        //        um.UserUpdate(item.User);
//        //    }
//        //}
//        //void PeanltyDecrease()
//        //{
//        //    var bookvalues = bm.PenaltyDecreaseList();
//        //    foreach (var item in bookvalues)
//        //    {
//        //        item.Borrow.User.Penalty -= 1;
//        //        um.UserUpdate(item.User);
//        //    }
//        //}
//    }
}