using Microsoft.Extensions.DependencyInjection;
using System;

namespace Pyrite.Content.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPyriteContentHttpInterface(this IServiceCollection services)
        {
            services.AddTransient<IHttpMethodStrategyFactory, HttpMethodStrategyFactory>();
        }
    }
}