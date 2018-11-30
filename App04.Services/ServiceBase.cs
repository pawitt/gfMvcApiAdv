using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace App04.Services
{
    public abstract class ServiceBase<T, TDbContext>
      : IService<T>
      where T : class
      where TDbContext : DbContext
    {
        private readonly TDbContext db;

        public ServiceBase(TDbContext db)
          => this.db = db;

        public virtual IQueryable<T> Query(Func<T, bool> predicate)
          => db.Set<T>().Where(predicate).AsQueryable();

        public virtual IQueryable<T> All
          => Query(x => true);

        public virtual T Find(params object[] keys)
          => db.Set<T>().Find(keys);

        public virtual T Add(T item) => db.Set<T>().Add(item).Entity;
        public virtual T Remove(T item) => db.Set<T>().Remove(item).Entity;
        public virtual T Update(T item) => db.Set<T>().Update(item).Entity;
    }
}