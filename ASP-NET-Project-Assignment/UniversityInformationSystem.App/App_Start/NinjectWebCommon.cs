using UniversityInformationSystem.App;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace UniversityInformationSystem.App
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using System.Web.Configuration;
    using Data;
    using Data.Contracts;
    using Data.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Services;
    using Services.Contracts;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(DbContext)).To(typeof(UisDataContext));
            kernel.Bind(typeof(IUisDataContext)).To(typeof(UisDataContext));
            kernel.Bind(typeof(IDbRepository<>)).To(typeof(DbRepository<>));
            kernel.Bind(typeof(IRegisterService)).To(typeof(RegisterService));

            // TODO: Maybe try to finish this
            //kernel.Bind(
            //    b =>
            //        b.FromAssembliesMatching("UniversityInformationSystem.Services")
            //            .SelectAllClasses()
            //            .BindSingleInterface());
        }        
    }
}
