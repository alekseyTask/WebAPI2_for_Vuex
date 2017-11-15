using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI2_for_Vuex.Models
{
    public interface IRepository<T1> where T1: class
    {
        void Create(T1 entity);

        T1 GetById(int id);

        IQueryable<T1> GetAll();

        void Update(T1 entity);

        void DeleteById(int id);

        void Save();
    }
}
