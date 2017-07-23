using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalLayer.Factory.Interfaces;
using Model;

namespace DalLayer.Factory.Repositories
{
    public class DbFactory : Disposable, IDbFactory
    {
        AlbumCatalogDbEntities _dbContext;

        public AlbumCatalogDbEntities Init()
        {
            AlbumCatalogDbEntities contex;
            try
            {
                contex = _dbContext ?? (_dbContext = new AlbumCatalogDbEntities());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return contex;
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }

    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }
}
