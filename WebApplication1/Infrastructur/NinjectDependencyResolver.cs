using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using WebApplication1.Models;
using WebApplication1.Models.Entities;


namespace WebApplication1.Infrastructur
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver (IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService (Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable <object> GetServices (Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings ()
        {
            kernel.Bind<IEmailProcessor>().To<EmailSender>();
        }
    }
}