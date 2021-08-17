using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        T Insert(T p);
        T Delete(T p);
        T Update(T p);

        List<T> List(Expression<Func<T, bool>> filter);
    }
}
