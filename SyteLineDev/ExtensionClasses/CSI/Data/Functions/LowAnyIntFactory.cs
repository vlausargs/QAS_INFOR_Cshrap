//PROJECT NAME: Data
//CLASS NAME: LowAnyIntFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
	public class LowAnyIntFactory
	{
		public ILowAnyInt Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _LowAnyInt = new Functions.LowAnyInt(appDB);


			return _LowAnyInt;
		}
	}
}
