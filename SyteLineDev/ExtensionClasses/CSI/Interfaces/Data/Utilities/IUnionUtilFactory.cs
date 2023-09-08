using CSI.Data;

namespace CSI.Data.Utilities
{
    public interface IUnionUtilFactory
    {
        IUnionUtil Create(UnionType unionType = UnionType.UnionAll, string orderBy = null);
    }
}
