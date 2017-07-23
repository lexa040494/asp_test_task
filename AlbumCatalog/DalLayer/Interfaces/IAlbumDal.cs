using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalLayer.GenericRepository.Interfaces;
using Model;

namespace DalLayer.Interfaces
{
    public interface IAlbumDal : IGenericRepository<Album>
    {
    }
}
