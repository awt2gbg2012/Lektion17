using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AWT2Demo.Domain.Entities.Abstract;
using System.Data.Entity;

namespace AWT2Demo.Domain.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        DbContext Model { get; }

        IQueryable<T> FindAll(Func<T, bool> filter = null);
        T FindByID(int id);
        void Save(T entity);
        void Delete(T entity);

        void Commit();
    }
}