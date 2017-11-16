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
        //private readonly IRepository<MyTodo> _todoRep;
        private readonly CRUDservice<MyTodo> _service;

        public TodoController(CRUDservice<MyTodo> service)
        {
            _service = service;
        }

        // GET: api/Todoes
        public IQueryable<MyTodo> Get()
        {
            return _service.GetItems();
        }

        // upd
        public IHttpActionResult Put(int id, MyTodo myTodo)
        {
            if (!ModelState.IsValid || id != myTodo.Id) return BadRequest(ModelState);

            _service.UpdateItem(myTodo);

            return StatusCode(HttpStatusCode.OK);
        }

        //add
        public MyTodo Post(MyTodo myTodo)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            _service.AddItem(myTodo);

            return myTodo;
        }

        //del
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _service.DeleteItem(id);
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.OK);
        }
    }
}
