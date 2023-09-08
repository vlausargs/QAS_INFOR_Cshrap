using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IDefinedValueBySessionIdFactory
    {
        IDefinedValueBySessionId Create(ICSIExtensionClassBase cSIExtensionClassBase);
    }
}