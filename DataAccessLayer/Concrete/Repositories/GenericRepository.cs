using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context _db = new Context();
        DbSet<T> _object;

        // Ctor-objeye değer atamak için kullanıcam.
        public GenericRepository()
        {
            _object = _db.Set<T>();
            // database'e baglı olarak gönderilen T değeri
        }
        public void Delete(T p)
        {
            _object.Remove(p);
            _db.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
            //tek değer döndürecek
        }

        public void Insert(T p)
        {
            _object.Add(p);
            _db.SaveChanges();
        }

        public List<T> List()
        {
           return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> Filter)
        {
            return _object.Where(Filter).ToList();
        }

        public void Update(T p)
        {
            _db.SaveChanges();
        }
    }
}
