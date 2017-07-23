using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalLayer.Interfaces;

namespace DalLayer.Factory.Interfaces
{
    public interface IDalFactory
    {
        IAlbumDal AlbumDal { get; }
        ITrackDal TrackDal { get; }
    }
}
