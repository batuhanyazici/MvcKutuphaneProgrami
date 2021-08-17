﻿using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        List<User> GetListById(int id);
        void UserAdd(User user);
        User GetByID(int id);
        void UserDelete(User user);
        void UserUpdate(User user);
        User GetUser(string mail, string pass);
    }
}
