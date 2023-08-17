using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;


namespace BusinessLayer.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SubCategoryManager>().As<ISubCategoryService>().SingleInstance();
            builder.RegisterType<EFSubcategoryDal>().As<ISubCategoryDal>().SingleInstance();
        }
    }
}
