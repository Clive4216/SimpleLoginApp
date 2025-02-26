using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();

    }
}