﻿using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfRequestDal : GenericRepository<BorrowRequest>, IRequestDal
    {
    }
}