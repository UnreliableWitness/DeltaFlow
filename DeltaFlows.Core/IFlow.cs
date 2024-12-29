using DeltaFlows.Core.Sink;
using DeltaFlows.Core.Source;
using System.Collections.Generic;

namespace DeltaFlows.Core
{
    public interface IFlow
    {
        string Name { get; set; }

        IItemSource Source { get; set; }

        IReadOnlyCollection<IItemSink> Sinks { get; set; }
    }

    public class Flow : IFlow
    {
        public string Name { get; set; }

        public Flow(string name)
        {
            Name = name;
        }

        public IItemSource Source { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IReadOnlyCollection<IItemSink> Sinks { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
