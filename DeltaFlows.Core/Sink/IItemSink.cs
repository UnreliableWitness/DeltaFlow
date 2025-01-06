using DeltaFlows.Core.Delta;

namespace DeltaFlows.Core.Sink
{
    public interface IItemSink
    {
        string ItemType { get; set; }

        IDeltaGate DeltaGate { get; set; }
    }

    public class ItemSink : IItemSink
    {
        public string ItemType { get; set; }

        public IDeltaGate DeltaGate { get; set; }
    }
}
