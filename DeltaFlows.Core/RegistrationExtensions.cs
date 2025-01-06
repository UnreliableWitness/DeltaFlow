using DeltaFlows.Core.Delta;
using DeltaFlows.Core.Item;
using DeltaFlows.Core.Sink;
using DeltaFlows.Core.Source;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeltaFlows.Core
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddDeltaFlows(this IServiceCollection services,
            Action<IDeltaFlowBuilder> configurer)
        {
            var builder = new DeltaFlowBuilder(services);
            configurer(builder);

            builder.Build();

            return services;
        }
    }

    public class DeltaFlowBuilder : IDeltaFlowBuilder
    {
        private readonly IFlow _flow = new Flow("default");

        public DeltaFlowBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }

        public IDeltaFlowBuilder AddSink(IItemSink sink)
        {
            if (_flow.Sinks?.Any() != true)
            {
                _flow.Sinks = new List<IItemSink>();
            }

            _flow.Sinks.Add(sink);
            return this;
        }

        public IDeltaFlowBuilder AddSource(string itemType, IItemAnalyzer itemAnalyzer, IDeltaGate deltaGate)
        {
            var itemSource = new ItemSource(itemType, itemAnalyzer, deltaGate);
            _flow.Source = itemSource;

            return this;
        }

        public void Build()
        {
            Services.AddSingleton<IFlow>(_flow);
        }
    }

    public interface IDeltaFlowBuilder
    {
        IDeltaFlowBuilder AddSource(string itemType, IItemAnalyzer itemAnalyzer, IDeltaGate deltaGate);

        IDeltaFlowBuilder AddSink(IItemSink sink);

        void Build();
    }
}
