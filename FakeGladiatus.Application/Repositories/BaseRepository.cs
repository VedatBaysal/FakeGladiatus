using FakeGladiatus.Application.Entities.DbEntities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeGladiatus.Application.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class,IDbEntity
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private  DbSet<T> Table => _dbContext.Set<T>();
        public bool Add(T entity)
        {
            Table.Add(entity);
           return _dbContext.SaveChanges() > 0;
        }

        public int AddRange(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public T GetById(int id)
        {
           return Table.Find(id);
        }

        public bool Update(T entity)
        {
            _dbContext.Entry(entity).State= EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
    }
}
