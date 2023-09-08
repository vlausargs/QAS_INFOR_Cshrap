//PROJECT NAME: Data
//CLASS NAME: LeftPadFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
	public class LeftPadFactory
	{
		public ILeftPad Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _LeftPad = new Functions.LeftPad(appDB);


			return _LeftPad;
		}
	}
}
