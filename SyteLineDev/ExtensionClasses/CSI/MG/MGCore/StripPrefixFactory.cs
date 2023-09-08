//PROJECT NAME: MG.MGCore
//CLASS NAME: StripPrefixFactory.cs

namespace CSI.MG.MGCore
{
    public class StripPrefixFactory
    {
        public IStripPrefix Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _StripPrefix = new StripPrefix(appDB);

            return _StripPrefix;
        }
    }
}
