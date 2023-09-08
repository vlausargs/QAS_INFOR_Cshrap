//PROJECT NAME: Data
//CLASS NAME: MultiLineAddressFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class MultiLineAddressFactory
	{
		public IMultiLineAddress Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _MultiLineAddress = new MultiLineAddress(appDB);


			return _MultiLineAddress;
		}
	}
}
