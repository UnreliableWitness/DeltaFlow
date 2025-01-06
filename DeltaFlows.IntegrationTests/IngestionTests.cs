using DeltaFlows.Core;
using DeltaFlows.Core.Sink;
using DeltaFlows.Csv;
using DeltaFlows.IntegrationTests.Delta;
using Microsoft.Extensions.DependencyInjection;

namespace DeltaFlows.IntegrationTests
{
    [TestClass]
    public class IngestionTests
    {
        private IFlow _flow;

        [TestInitialize]
        public void Setup()
        {
            var services = new ServiceCollection();
            var builder = new DeltaFlowBuilder(services);

            builder
                .AddSource("product", new CsvItemAnalyzer(), new InMemoryDeltaGate())
                .AddSink(new ItemSink())
                .AddSink(new ItemSink())
                .Build();

            var provider = services.BuildServiceProvider();
            _flow = provider.GetRequiredService<IFlow>();
        }

        [TestMethod]
        public void CanIngestBatch()
        {
            Assert.IsNotNull(_flow);
        }
    }
}