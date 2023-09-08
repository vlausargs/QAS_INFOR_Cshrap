//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROOperUpdateStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROOperUpdateStatusFactory
	{
		public ISSSFSSROOperUpdateStatus Create(IApplicationDB appDB)
		{
			var _SSSFSSROOperUpdateStatus = new Logistics.FieldService.Requests.SSSFSSROOperUpdateStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROOperUpdateStatusExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROOperUpdateStatus>(_SSSFSSROOperUpdateStatus);
			
			return iSSSFSSROOperUpdateStatusExt;
		}
	}
}
