using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ILowStringFactory
    {
        ILowString Create(ICSIExtensionClassBase cSIExtensionClassBase);
    }
}