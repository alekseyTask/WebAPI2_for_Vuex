using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Owin;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;

namespace WebAPI2_for_Vuex
{
    public static class WebApiConfig
    {
        public static void Configure(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            configRoute(config);

            configCors(config);

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var container = initializeInjector(config);

            app.UseWebApi(config);

            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(container))
                {
                    await next();
                }
            });
        }

        private static void configCors(HttpConfiguration config)
        {
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }

        private static void configRoute(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        
        private static Container initializeInjector(HttpConfiguration config)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            container.Register<Controllers.TodoController>(Lifestyle.Scoped);
            container.Register<Models.EntityModel, Models.EntityModel>(Lifestyle.Scoped);
            container.Register<Models.IRepository<Models.MyTodo>, Models.TodoRepository>(Lifestyle.Scoped);
            container.Register<Models.VerificationService<Models.MyTodo>, Models.TodoVerificationService>(Lifestyle.Scoped);
            container.Register<Models.CRUDservice<Models.MyTodo>, Models.CRUDservice<Models.MyTodo>>(Lifestyle.Scoped);

            container.Verify();

            return container;
        }
    }
}
