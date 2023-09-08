using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IFormatFileSpecFactory
    {
        IFormatFileSpec Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}