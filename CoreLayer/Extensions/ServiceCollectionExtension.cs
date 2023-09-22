using CoreLayer.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace CoreLayer.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection services, ICoreModule[] modules) //Service bağlılıqlarını əlavə edirik
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services); //Bütün Modulları əlavə edib və bir araya toplamaq üçün
        }
    }
}
