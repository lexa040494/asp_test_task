using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalLayer.Factory.Interfaces;
using DalLayer.GenericRepository.Interfaces;
using Model;

namespace DalLayer.GenericRepository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private AlbumCatalogDbEntities _dataContext;
        private readonly IDbSet<T> _dbSet;
        private bool disposed = false;

        ~GenericRepository()
        {
            Dispose(false);
        }

        protected IDbFactory DbFactory { get; private set; }

        protected AlbumCatalogDbEntities DbEntities
        {
            get { return _dataContext ?? (_dataContext = DbFactory.Init()); }
        }

        protected GenericRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbEntities.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T AddWithReturn(T entity, bool isSave = true)
        {
            DetachEntities();

            _dbSet.Add(entity); // eq  Db.Set<T>().Attach(entity); 
            _dataContext.Entry(entity).State = EntityState.Added;
            if (isSave)
                _dataContext.SaveChanges();
            return entity;
        }

        public void UpdateVoid(T entity, decimal key)
        {
            T existing = _dataContext.Set<T>().Find(key);
            if (existing != null)
            {
                _dataContext.Entry(existing).CurrentValues.SetValues(entity);
                _dataContext.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            try
            {
                DetachEntities();

                _dataContext.Entry(entity).State = EntityState.Deleted;
                _dataContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }

                disposed = true;
            }
        }

        private void DetachEntities()
        {
            IEnumerable<DbEntityEntry> objectStateEntries =
                _dataContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Unchanged);
            foreach (DbEntityEntry objectStateEntry in objectStateEntries)
            {
                objectStateEntry.State = EntityState.Detached;
            }
        }
    }
}
