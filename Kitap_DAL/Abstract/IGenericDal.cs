using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap_DAL.Abstract
{
   public interface IGenericDal<T> where T:class,new()
    {
        DbSet<T> Set();
        T Find(int id);
        T Find(string id);
        void Insert(T entity);
        void Delete(T entity);
        void Save();
        List<T> List();
        IQueryable<T> GenericList();

       
      
    }
}
