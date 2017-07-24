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

        public void UpdateAlbum(AlbumDto albumDto)
        {
            var album = Mapper.Map<AlbumDto, Album>(albumDto);
            var albumFromDb = _dalFactory.AlbumDal.GetById(album.Id);

            var listForAdd = album.Track.Where(p => albumFromDb.Track.All(l => p.Id != l.Id)).ToList();

            var listForDelete = albumFromDb.Track.Where(p => album.Track.All(l => p.Id != l.Id)).ToList();

            var listForUpdate = album.Track.Where(p => albumFromDb.Track.Any(l => p.Id == l.Id)).ToList();

            listForAdd.ForEach(x=>_dalFactory.TrackDal.AddWithReturn(x));
            listForDelete.ForEach(x => _dalFactory.TrackDal.Delete(x));
            listForUpdate.ForEach(x => _dalFactory.TrackDal.UpdateVoid(x, x.Id));

            _dalFactory.AlbumDal.UpdateVoid(album,album.Id);
        }
    }
}
