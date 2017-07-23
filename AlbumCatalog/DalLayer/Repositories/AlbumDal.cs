using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalLayer.Factory.Interfaces;
using DalLayer.Interfaces;
using Model;
using DalLayer.GenericRepository.Repositories;

namespace DalLayer.Repositories
{
    public class AlbumDal : GenericRepository<Album>, IAlbumDal
    {
        public AlbumDal(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
