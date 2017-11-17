using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebAPI2_for_Vuex
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            WebApiConfig.Configure(app);
        }
    }
}