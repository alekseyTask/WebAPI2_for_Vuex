﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI2_for_Vuex.Models
{
    public class TodoRepository : IRepository<MyTodo>
    {
        private readonly EntityModel db;

        public TodoRepository(EntityModel db)
        {
            this.db = db;
        }

        public void Create(MyTodo entity)
        {
            db.Set<MyTodo>().Add(entity);
            Save();
        }

        public void DeleteById(int id)
        {
            db.MyTodos.Remove(this.GetById(id));
            Save();
        }

        public IEnumerable<MyTodo> GetAll()
        {
            return db.MyTodos;
        }

        public MyTodo GetById(int id)
        {
            return db.MyTodos.Find(id);
        }

        public void Update(MyTodo entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}