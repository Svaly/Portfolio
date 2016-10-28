using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Portfolio.Domain.Abstract;
using Portfolio.Domain.Concrete;

namespace Portfolio.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {

            kernel.Bind<IProjectRepository>().To<EFProjectRepository>();

            kernel.Bind<IImageRepository>().To<EFImageRepository>();

            kernel.Bind<IProfileInfoRepository>().To<EFProfileInfoRepository>();

        }

    }
}