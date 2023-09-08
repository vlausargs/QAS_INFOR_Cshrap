//PROJECT NAME: Data
//CLASS NAME: HighAnyIntFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
	public class HighAnyIntFactory
	{
		public IHighAnyInt Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _HighAnyInt = new Functions.HighAnyInt(appDB);


			return _HighAnyInt;
		}
	}
}
