using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI2_for_Vuex.Models
{
    public class TodoVerificationService : VerificationService<MyTodo>
    {
        private readonly int _minId;
        private readonly int _maxId;
        private readonly int _maxTitle;
        private readonly int _minTitle;
        private readonly int _maxProject;
        private readonly int _minProject;

        public TodoVerificationService()
        {
            _minId = 0;
            _maxId = Int32.MaxValue;
            _maxTitle = 12;
            _minTitle = 3;
            _maxProject = 12;
            _minProject = 5;
        }

        public override bool Verification(MyTodo model)
        {
            this.model = model;
            return checkId() && checkTitle() && checkProject();
        }

        protected virtual bool checkId()
        {
            return checkRange(model.Id, _minId, _maxId);
        }

        protected virtual bool checkTitle()
        {
            var lngth = model.Title.Length;

            return checkRange(lngth, _minTitle, _maxTitle);
        }

        protected virtual bool checkProject()
        {
            var lngth = model.Project.Length;

            return checkRange(lngth, _minProject, _maxProject);
        }
    }
}