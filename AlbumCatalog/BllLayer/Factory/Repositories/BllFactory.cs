using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BllLayer.Factory.Interfaces;
using BllLayer.Interfaces;
using BllLayer.Repositories;
using DalLayer.Factory.Interfaces;

namespace BllLayer.Factory.Repositories
{
    public class BllFactory : IBllFactory
    {
        private readonly IDalFactory _dalFactory;

        public BllFactory(IDalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        private IAlbumBll _albumBll;

        public IAlbumBll AlbumBll
        {
            get { return _albumBll ?? (_albumBll = new AlbumBll()); }
        }

        private ITrackBll _trackBll;

        public ITrackBll TrackBll
        {
            get { return _trackBll ?? (_trackBll = new TrackBll()); }
        }
    }
}
