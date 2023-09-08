//PROJECT NAME: Data
//CLASS NAME: DisplayOurAddressWithPhoneLangFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class DisplayOurAddressWithPhoneLangFactory
    {
        public IDisplayOurAddressWithPhoneLang Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _DisplayOurAddressWithPhoneLang = new Functions.DisplayOurAddressWithPhoneLang(appDB);

            return _DisplayOurAddressWithPhoneLang;
        }
    }
}
