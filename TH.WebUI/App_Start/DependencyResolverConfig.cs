using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using TH.Repositories;
using TH.Repositories.Entities;
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
            builder.RegisterControllers(typeof(MvcApplication).Assembly);//注册所有的Controller

            builder.RegisterAssemblyTypes(typeof(ServiceBase).Assembly).Where(
                t => t.Name.EndsWith("Service")).AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly).Where(
            //    t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(THRepository<>)).As(typeof(IRepository<>));// .WithParameter(new NamedParameter("context", new THDbContext()));可替换为：
            builder.Register(c => new THDbContext());

            // Build the container and store it for later use.
            var container = builder.Build();

            // use in ASP.NET MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // more: https://github.com/autofac/Autofac/wiki/Getting-Started
        }
    }
}