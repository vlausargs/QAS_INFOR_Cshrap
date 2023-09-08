//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConsoleCreateValidCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSConsoleCreateValidCustFactory
	{
		public ISSSFSConsoleCreateValidCust Create(IApplicationDB appDB)
		{
			var _SSSFSConsoleCreateValidCust = new Logistics.FieldService.CallCenter.SSSFSConsoleCreateValidCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConsoleCreateValidCustExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSConsoleCreateValidCust>(_SSSFSConsoleCreateValidCust);
			
			return iSSSFSConsoleCreateValidCustExt;
		}
	}
}
