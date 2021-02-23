using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where  T: class,IEntity,new()//Burada T Generic tipine sen bir referans tipsin, bir IEntitysin ya da onu
                                                                       //iplemente edebilirsin ve nihayetinde sen constuctorın newlenebilsin yani sen asdece db nesneleri ile çalış dedik
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
