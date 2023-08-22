using CoreLayer.CrossCuttingConcerns.Caching;
using CoreLayer.CrossCuttingConcerns.Caching.Microsoft;
using CoreLayer.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace CoreLayer.DependencyResolvers
{
    public class CoreModule : ICoreModule // Bütün proyektlərdə istifadə olunabiləcək Injectionları burda yazırıq.
    {
        public void Loaad(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
