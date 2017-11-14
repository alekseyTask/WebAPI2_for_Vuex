using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI2_for_Vuex.Models
{
    interface IRepository<T1>
    {
        void Create(T1 entity);

        T1 GetById(int id);

        void Upd(T1 entity);

        void DelById(int id);

        void Save();
    }
}
