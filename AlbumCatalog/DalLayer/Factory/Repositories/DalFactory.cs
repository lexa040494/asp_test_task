using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalLayer.Factory.Interfaces;
using DalLayer.Interfaces;
using DalLayer.Repositories;
using Model;

namespace DalLayer.Factory.Repositories
{
    public class DalFactory : IDalFactory
    {
        private AlbumCatalogDbEntities _dbContext;
        private readonly IDbFactory _dbFactory;
        public DalFactory(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public AlbumCatalogDbEntities DbContext
        {
            get { return _dbContext ?? (_dbContext = _dbFactory.Init()); }
        }

        public void Dispose()
        {
            _dbContext.Dispose();

            GC.SuppressFinalize(this);
        }

        private IAlbumDal _albumDal;

        public IAlbumDal AlbumDal
        {
            get { return _albumDal ?? (_albumDal = new AlbumDal(_dbFactory)); }
        }

        private ITrackDal _trackDal;

        public ITrackDal TrackDal
        {
            get { return _trackDal ?? (_trackDal = new TrackDal(_dbFactory)); }
        }
    }
}
