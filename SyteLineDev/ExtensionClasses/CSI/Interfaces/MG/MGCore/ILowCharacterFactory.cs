using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ILowCharacterFactory
    {
        ILowCharacter Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}