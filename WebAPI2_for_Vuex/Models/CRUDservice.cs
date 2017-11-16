using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI2_for_Vuex.Models
{
    public class CRUDservice<T1> where T1: class
    {
        private readonly IRepository<T1> _repository;
        private readonly VerificationService<T1> _verificationService;

        public CRUDservice(IRepository<T1> repository, VerificationService<T1> verificationService)
        {
            _repository = repository;
            _verificationService = verificationService;
        }

        public IQueryable<T1> GetItems()
        {
            return _repository.GetAll();
        }

        public void AddItem(T1 item)
        {
            if (_verificationService.Verification(item))
            {
                _repository.Create(item);
            }
            else
            {
                throw new Exception();
            }
        }

        public void UpdateItem(T1 item)
        {
            if (_verificationService.Verification(item))
            {
                _repository.Update(item);
            }
            else
            {
                throw new Exception();
            }
        }

        public void DeleteItem(int id)
        {
            _repository.DeleteById(id);
        }
    }
}