using FakeGladiatus.Application.Entities.DbEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeGladiatus.Application.Repositories
{
    public interface IRepository<T> where T :IDbEntity
    {
        bool Add(T entity);
        int AddRange(IEnumerable<T> entities);
        bool Delete(T entity);
        bool Update(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
