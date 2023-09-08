//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROValidCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROValidCustFactory
	{
		public ISSSFSSROValidCust Create(IApplicationDB appDB)
		{
			var _SSSFSSROValidCust = new Logistics.FieldService.Requests.SSSFSSROValidCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROValidCustExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROValidCust>(_SSSFSSROValidCust);
			
			return iSSSFSSROValidCustExt;
		}
	}
}
