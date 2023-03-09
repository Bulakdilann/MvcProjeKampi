﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context _db = new Context();
        DbSet<Category> _object;
        public void Delete(Category p)
        {
            _object.Remove(p);
            _db.SaveChanges();

        }

        public void Insert(Category p)
        {
            _object.Add(p);
            _db.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> Filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            _db.SaveChanges();
        }
    }
}