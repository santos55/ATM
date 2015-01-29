using Atm.DataHelpers;
using Atm.Infrastructure;
using Atm.Infrastructure.Repositories;
using Atm.Services;
using Atm.Web.IoC;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Atm.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           
            Database.SetInitializer(new AtmContextInitializer());
            IUnityContainer container = GetUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
        private IUnityContainer GetUnityContainer()
        {
            //Create UnityContainer          
            IUnityContainer container = new UnityContainer()

            .RegisterType<IDatabaseFactory, DatabaseFactory>(new HttpContextLifetimeManager<IDatabaseFactory>())
            .RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>())
            .RegisterType<ICardRepository, CardRepository>(new HttpContextLifetimeManager<ICardRepository>())
            .RegisterType<IUserRepository, UserRepository>(new HttpContextLifetimeManager<IUserRepository>())
            .RegisterType<IAccountRepository, AccountRepository>(new HttpContextLifetimeManager<IAccountRepository>())
            .RegisterType<IOperationRepository, OperationRepository>(new HttpContextLifetimeManager<IOperationRepository>())
            .RegisterType<IOperationService, OperationService>(new HttpContextLifetimeManager<IOperationService>())
            .RegisterType<ILoginService, LoginService>(new HttpContextLifetimeManager<ILoginService>());
            return container;
        }
    }
}
