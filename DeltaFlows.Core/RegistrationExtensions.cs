using Microsoft.Extensions.DependencyInjection;
using System;

namespace DeltaFlows.Core
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddDeltaFlows(this IServiceCollection services,
            Action<IDeltaFlowsBuilder> configurer)
        {
            //services.AddSingleton<IHasher, MD5Hasher>();

            var builder = new DeltaFlowsBuilder(services);
            configurer(builder);
            // builder.Build();

            return services;
        }
    }

    internal class DeltaFlowsBuilder : IDeltaFlowsBuilder
    {
        public DeltaFlowsBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }

        public void Add(string name)
        {
            Services.AddSingleton<IFlow, Flow>(sp => new Flow(name));
        }
    }

    public interface IDeltaFlowsBuilder
    {
        void Add(string name);
    }
}
