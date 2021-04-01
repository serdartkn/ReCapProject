
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {//Bir managerin ınterface yoksa (addmemorycache) örneğinde oldugu tekli enjekte yapabiliriz.
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            //Burası .netten geliyor. //MemoryCacheManager'de bulunan IMemoryCache _memoryCache;' in Karşılığı aşağıdakidir.
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
