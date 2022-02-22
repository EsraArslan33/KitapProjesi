using Kitap_DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap_DAL.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T :  class , new()
    {
        private Context c;
        public GenericRepository(Context _c)
        {
            c = _c;
        }
        public DbSet<T> Set()
        {
            return c.Set<T>();
        }
        public void Delete(T entity)
        {
            Set().Remove(entity);
            
        }
        public List<T> List()
        {
            return Set().ToList();
        }
        public IQueryable<T> GenericList()
        {
            return Set().AsQueryable();
        }
        public void Insert(T entity)
        {
            Set().Add(entity);
        }
        public void Save()
        {
            c.SaveChanges();
        }
        public T Find(string id)
        {
            return Set().Find(id);
        }
        
        public T Find(int id)
        {
            return Set().Find(id);
        }
    }
}
