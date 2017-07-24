using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Models;

namespace BllLayer.Interfaces
{
    public interface IAlbumBll
    {
        List<AlbumDto> GetAllAlbums();
        void SaveAlbum(AlbumDto albumDto);
        void UpdateAlbum(AlbumDto albumDto);
    }
}
