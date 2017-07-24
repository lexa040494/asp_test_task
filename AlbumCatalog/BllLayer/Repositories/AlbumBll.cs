using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BllLayer.Interfaces;
using DalLayer.Factory.Interfaces;
using Model;
using ViewModel.Models;

namespace BllLayer.Repositories
{
    public class AlbumBll : IAlbumBll
    {
         private readonly IDalFactory _dalFactory;

         public AlbumBll(IDalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }

        public List<AlbumDto> GetAllAlbums()
        {
            return Mapper.Map<List<Album>, List<AlbumDto>>(_dalFactory.AlbumDal.GetAll().ToList());
        }

        public void SaveAlbum(AlbumDto albumDto)
        {
            var album = Mapper.Map<AlbumDto, Album>(albumDto);
            _dalFactory.AlbumDal.AddWithReturn(album);
        }
    }
}
