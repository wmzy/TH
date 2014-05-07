using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using TH.Repositories;
using TH.Repositories.Infrastructure;
using TH.Services;
using System.Web.Mvc;

namespace TH.WebUI
{
    public class DependencyResolverConfig
    {
        public static void SetResolver()
        {
            //Autofac初始化过程

            // Create a ContainerBuilder
            var builder = new ContainerBuilder();

            // Register components.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());//注册所有的Controller

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(typeof(IService).Assembly).Where(
                t => t.IsSubclassOf(typeof(IService)) && t.IsClass).AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterGeneric(typeof(THRepository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();
            
            // Build the container and store it for later use.
            var container = builder.Build();

            // use in ASP.NET MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // more: https://github.com/autofac/Autofac/wiki/Getting-Started
        }
    }
}