using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalLayer.GenericRepository.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        T AddWithReturn(T entity, bool isSave = true);

        void UpdateVoid(T entity, decimal key);

        void Delete(T entity);

        void SaveChanges();
    }
}
