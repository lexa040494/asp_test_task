using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BllLayer.Interfaces;

namespace BllLayer.Factory.Interfaces
{
    public interface IBllFactory
    {
        IAlbumBll AlbumBll { get; }
        ITrackBll TrackBll { get; }
    }
}
