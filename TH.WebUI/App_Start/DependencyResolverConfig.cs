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

            // 创建一个 ContainerBuilder
            var builder = new ContainerBuilder();

            // 注册组件
            builder.RegisterControllers(Assembly.GetExecutingAssembly());//注册所有的Controller

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(typeof(RepositoryBase<>).Assembly).Where(
                t => t.Name.EndsWith("Repository") && t.IsClass).AsImplementedInterfaces().InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(typeof(IService).Assembly).Where(
                t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerHttpRequest();
            
            // 构建容器并保存它
            var container = builder.Build();

            // 应用到 ASP.NET MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // 参考: https://github.com/autofac/Autofac/wiki/Getting-Started
        }
    }
}