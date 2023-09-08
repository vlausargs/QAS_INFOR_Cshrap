using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ICreateSpecificNoteFactory
    {
        ICreateSpecificNote Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}