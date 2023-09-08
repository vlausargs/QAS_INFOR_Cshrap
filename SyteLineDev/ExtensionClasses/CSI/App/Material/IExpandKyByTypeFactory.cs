//PROJECT NAME: Material
//CLASS NAME: ExpandKyByTypeFactory.cs

using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Material
{
    public interface IExpandKyByTypeFactory
    {
        IExpandKyByType Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}