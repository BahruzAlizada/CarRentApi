using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoreLayer.Utilities.IoC
{
    public interface ICoreModule
    {
        void Loaad(IServiceCollection services);
    }
}
