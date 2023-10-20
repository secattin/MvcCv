using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    
    public class GenericRepository<T> where T : class,new()
    {
        DbCVEntities2 db = new DbCVEntities2();
        public List<T> list()
        {
            return db.Set<T>().ToList();    
        }

        public void TAdd(T P)
        {
            db.Set<T>().Add(P); 
            db.SaveChanges();
        }
        public void TDelete(T P)
        {
            db.Set<T>().Remove(P);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T P)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> Where)
        {
            return db.Set<T>().FirstOrDefault(Where);
        }
    }
}