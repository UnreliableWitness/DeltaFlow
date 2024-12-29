using DeltaFlows.Core.Delta;
using DeltaFlows.Core.Item;

namespace DeltaFlows.Core.Source
{
    public interface IItemSource
    {
        string ItemType { get; set; }

        IDeltaGate DeltaGate { get; set; }

        IItemAnalyzer ItemAnalyzer { get; set; }
    }
}
