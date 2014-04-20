using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using TH.Services;
using TH.Repositories;
using TH.Repositories.Entities;

namespace TH.WebUI
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterType<IJobService, JobService>();
        container.RegisterType<IRepository<Job>, THRepository<Job>>();
    }
  }
}