//PROJECT NAME: Adapters
//CLASS NAME: GetCodeFactory.cs

using CSI.Data.SQL;
using CSI.MG;

namespace CSI.Adapters
{
    public interface IGetCodeFactory
    {
        IGetCode Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}