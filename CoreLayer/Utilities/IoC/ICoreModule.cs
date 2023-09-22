using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoreLayer.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
