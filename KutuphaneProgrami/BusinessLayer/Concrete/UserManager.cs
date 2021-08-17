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
    public class UserManager : IUserService
    {
        IUserDal _userdal;

        public UserManager(IUserDal userdal)
        {
            _userdal = userdal;
        }

        public User GetByID(int id)
        {
            return _userdal.GetById(id);
        }

        public List<User> GetList()
        {
            return _userdal.List();
        }

        public List<User> GetListById(int id)
        {
            return _userdal.List(x => x.Id == id);
        }

        public User GetUser(string mail, string pass)
        {
            return _userdal.Get(x => x.UserMail == mail && x.OriginalPass == pass);
        }

        public void UserAdd(User user)
        {
            _userdal.Insert(user);
        }

        public void UserDelete(User user)
        {
            _userdal.Delete(user);
        }

        public void UserUpdate(User user)
        {
            _userdal.Update(user);
        }
    }
}
