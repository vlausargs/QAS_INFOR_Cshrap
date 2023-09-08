//PROJECT NAME: MG.MGCore
//CLASS NAME: UndefineProcessVariableFactory.cs

using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IUndefineProcessVariableFactory
    {
        IUndefineProcessVariable Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}