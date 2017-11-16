using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI2_for_Vuex.Models
{
    public abstract class VerificationService<T1>
    {
        protected T1 model;

        public abstract bool Verification(T1 model);

        protected bool checkRange(int x, int min, int max)
        {
            return (x >= min) && (x <= max);
        }
    }
}
