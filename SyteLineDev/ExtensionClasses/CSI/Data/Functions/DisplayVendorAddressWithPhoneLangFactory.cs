//PROJECT NAME: Data
//CLASS NAME: DisplayVendorAddressWithPhoneLangFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class DisplayVendorAddressWithPhoneLangFactory
    {
        public IDisplayVendorAddressWithPhoneLang Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _DisplayVendorAddressWithPhoneLang = new Functions.DisplayVendorAddressWithPhoneLang(appDB);

            return _DisplayVendorAddressWithPhoneLang;
        }
    }
}
