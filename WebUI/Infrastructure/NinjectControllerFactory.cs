using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Ninject;
using System.Web.Mvc;
using DomainModel.Abstract;
using Moq;
using DomainModel.Entities;
using DomainModel.Concrete;


namespace WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
             
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }


        private void AddBindings()
        {
            #region moq
            //            Mock<IJeansRepository> mock = new Mock<IJeansRepository>();
            //            mock.Setup(m => m.Jeans).Returns(new List<Jeans> {
            //new Jeans { Name = "Football", Price = 25 },
            //new Jeans { Name = "Surf board", Price = 179 },
            //new Jeans { Name = "Running shoes", Price = 95 }
            //}.AsQueryable()); 
            #endregion
            ninjectKernel.Bind<IJeansRepository>().To<EFJeansRepository>();
        }
    }
}