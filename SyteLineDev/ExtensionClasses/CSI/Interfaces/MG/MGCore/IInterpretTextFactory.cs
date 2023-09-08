using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IInterpretTextFactory
    {
        IInterpretText Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}