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

            builder.RegisterType<BanManager>().As<IBanService>().SingleInstance();
            builder.RegisterType<EFBanDal>().As<IBanDal>().SingleInstance();

            builder.RegisterType<CarEngineTypeManager>().As<ICarEngineTypeService>().SingleInstance();
            builder.RegisterType<EFCarEngineTypeDal>().As<ICarEngineTypeDal>().SingleInstance();

            builder.RegisterType<CarNumberSeatManager>().As<ICarNumberSeatService>().SingleInstance();
            builder.RegisterType<EFCarNumberSeatDal>().As<ICarNumberSeatDal>().SingleInstance();

            builder.RegisterType<CarColorManager>().As<ICarColorService>().SingleInstance();
            builder.RegisterType<EFCarColorDal>().As<ICarColorDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EFCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<NewsletterManager>().As<INewsletterService>().SingleInstance();
            builder.RegisterType<EFNewsletterDal>().As<INewsletterDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EFCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EFCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EFCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<FaqManager>().As<IFaqService>().SingleInstance();
            builder.RegisterType<EFFaqDal>().As<IFaqDal>().SingleInstance();
        }
    }
}
