using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI2_for_Vuex.Models
{
    public class TodoRepository : IRepository<MyTodo>
    {
        private readonly EntityModel db;

        public TodoRepository()
            : this(new EntityModel())
        { }

        public TodoRepository(EntityModel db)
        {
            this.db = db;
        }

        public void Create(MyTodo entity)
        {
            db.Set<MyTodo>().Add(entity);
        }

        public void DelById(int id)
        {
            throw new NotImplementedException();
        }

        public MyTodo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Upd(MyTodo entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}