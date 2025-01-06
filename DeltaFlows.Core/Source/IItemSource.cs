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

    public class ItemSource : IItemSource
    {
        public string ItemType { get; set; }

        public IDeltaGate DeltaGate { get; set; }

        public IItemAnalyzer ItemAnalyzer { get; set; }

        public ItemSource(string itemType, IItemAnalyzer itemAnalyzer, IDeltaGate deltaGate)
        {
            ItemType = itemType;
            ItemAnalyzer = itemAnalyzer;
            DeltaGate = deltaGate;
        }
    }
}
