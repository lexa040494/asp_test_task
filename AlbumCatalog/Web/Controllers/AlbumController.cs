using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BllLayer.Factory.Interfaces;
using BllLayer.Interfaces;
using ViewModel.Models;
using Web.Controllers.BaseController;

namespace Web.Controllers
{
    [RoutePrefix("api/album")]
    public class AlbumController : BaseApiController
    {
        private readonly IAlbumBll _albumBll;
        private readonly ITrackBll _trackBll;

        public AlbumController(IBllFactory bllFactory)
        {
            if (bllFactory == null)
            {
                throw new ArgumentNullException("factoryBll");
            }
            _albumBll = bllFactory.AlbumBll;
            _trackBll = bllFactory.TrackBll;
        }

        [HttpGet]
        public List<AlbumDto> Get()
        {
            var albumList = _albumBll.GetAllAlbums();
            return albumList;
        }

        [HttpPost]
        public void Post(AlbumDto album)
        {
            _albumBll.SaveAlbum(album);
        }
    }
}