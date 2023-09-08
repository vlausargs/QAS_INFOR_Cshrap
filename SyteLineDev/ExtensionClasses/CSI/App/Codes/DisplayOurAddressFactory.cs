//PROJECT NAME: Data
//CLASS NAME: DisplayOurAddressFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class DisplayOurAddressFactory
	{
		public IDisplayOurAddress Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _DisplayOurAddress = new DisplayOurAddress(appDB);


			return _DisplayOurAddress;
		}
	}
}
