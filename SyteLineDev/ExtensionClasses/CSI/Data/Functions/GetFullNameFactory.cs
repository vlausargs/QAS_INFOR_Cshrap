//PROJECT NAME: Data
//CLASS NAME: GetFullNameFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
	public class GetFullNameFactory
	{
		public IGetFullName Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _GetFullName = new Functions.GetFullName(appDB);

			return _GetFullName;
		}
	}
}
