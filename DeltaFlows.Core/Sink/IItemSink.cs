using DeltaFlows.Core.Delta;

namespace DeltaFlows.Core.Sink
{
    public interface IItemSink
    {
        string ItemType { get; set; }

        IDeltaGate DeltaGate { get; set; }
    }
}
