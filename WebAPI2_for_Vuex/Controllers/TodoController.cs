using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI2_for_Vuex.Models;

namespace WebAPI2_for_Vuex.Controllers
{
    public class TodoController : ApiController
    {
        private readonly IRepository<MyTodo> _todoRep;
        
        public TodoController(IRepository<MyTodo> todoRep)
        {
            _todoRep = todoRep;
        }

        // GET: api/Todoes
        public IQueryable<MyTodo> Get()
        {
            return _todoRep.GetAll();
        }

        // upd
        public IHttpActionResult Put(int id, MyTodo myTodo)
        {
            if (!ModelState.IsValid || id != myTodo.Id) return BadRequest(ModelState);

            _todoRep.Upd(myTodo);

            return StatusCode(HttpStatusCode.OK);
        }

        //add
        public MyTodo Post(MyTodo myTodo)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            _todoRep.Create(myTodo);

            return myTodo;
        }

        //del
        public IHttpActionResult Delete(int? id)
        {

            if (id == null) return NotFound();

            try
            {
                _todoRep.DelById((int)id);
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.OK);
        }
    }
}
