﻿using Castle.DynamicProxy;
using CoreLayer.CrossCuttingConcerns.Caching;
using CoreLayer.Utilities.Interceptors;
using CoreLayer.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace CoreLayer.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
