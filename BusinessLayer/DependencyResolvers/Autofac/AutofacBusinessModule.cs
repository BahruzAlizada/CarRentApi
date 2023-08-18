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

            builder.RegisterType<CarYearManager>().As<ICarYearService>().SingleInstance();
            builder.RegisterType<EFCarYearDal>().As<ICarYearDal>().SingleInstance();

            builder.RegisterType<CarCountryMarketManager>().As<ICarCountryMarketService>().SingleInstance();
            builder.RegisterType<EFCarCountryMarketDal>().As<ICarCountryMarketDal>().SingleInstance();

            builder.RegisterType<CarGearBoxManager>().As<ICarGearBoxService>().SingleInstance();
            builder.RegisterType<EFCarGearBoxDal>().As<ICarGearBoxDal>().SingleInstance();
        }
    }
}
