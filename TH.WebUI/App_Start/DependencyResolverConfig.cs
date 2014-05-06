﻿using System;
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

            builder.RegisterAssemblyTypes(typeof(IService).Assembly).Where(
                t => t.IsSubclassOf(typeof(IService)) && t.IsClass).AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly).Where(
            //    t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(THRepository<>)).As(typeof(IRepository<>));

            //实现one context per request
            builder.RegisterType<THDbContext>().InstancePerHttpRequest();

            // Build the container and store it for later use.
            var container = builder.Build();

            // use in ASP.NET MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // more: https://github.com/autofac/Autofac/wiki/Getting-Started
        }
    }
}