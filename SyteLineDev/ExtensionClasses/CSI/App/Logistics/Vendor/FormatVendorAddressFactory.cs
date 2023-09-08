//PROJECT NAME: Data
//CLASS NAME: FormatVendorAddressFactory.cs

using CSI.MG;
using CSI.Data.SQL;


namespace CSI.Logistics.Vendor
{
	public class FormatVendorAddressFactory
	{
		public IFormatVendorAddress Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _FormatVendorAddress = new FormatVendorAddress(appDB);

			return _FormatVendorAddress;
		}
	}
}
