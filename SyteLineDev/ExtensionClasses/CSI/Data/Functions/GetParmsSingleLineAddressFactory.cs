//PROJECT NAME: Reporting
//CLASS NAME: GetParmsSingleLineAddressFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
	public class GetParmsSingleLineAddressFactory
	{
		public IGetParmsSingleLineAddress Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _GetParmsSingleLineAddress = new GetParmsSingleLineAddress(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetParmsSingleLineAddressExt = timerfactory.Create<IGetParmsSingleLineAddress>(_GetParmsSingleLineAddress);
			
			return iGetParmsSingleLineAddressExt;
		}
	}
}
