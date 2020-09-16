using DeathValley.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeathValley
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly DbContext databaseContext;
        protected readonly DbSet<T> currentSet;

        public Repository(DbContext context)
        {
            databaseContext = context;
            currentSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            if (entity is null)
            {
                return;
            }

            currentSet.Add(entity);
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                return;
            }

            var entity = GetById(id);

            if (entity is null)
            {
                return;
            }

            currentSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return currentSet.AsNoTracking();
        }

        public T GetById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var entity = currentSet.Find(id);

            return entity;
        }

        public void Update(T entity)
        {
            databaseContext.Entry(entity).State = EntityState.Modified;
        }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    databaseContext.Dispose();
                }

                disposedValue = true;
            }
        }

        ~Repository()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            databaseContext.SaveChanges();
        }
    }
}
