using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IHighCharacterFactory
    {
        IHighCharacter Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}