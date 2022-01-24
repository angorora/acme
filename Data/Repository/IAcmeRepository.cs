using System;
using System.Collections.Generic;
using System.Linq;

namespace acme_employees.Data.Repository
{
    public interface IAcmeRepository<T>
    {
        public IQueryable<T> GetAll();
        public T GetOne(int id);
        public T Create(T entity);
        public int Update(T entity);
        public int Remove(int id);
        public bool SaveChanges();
    }
}
