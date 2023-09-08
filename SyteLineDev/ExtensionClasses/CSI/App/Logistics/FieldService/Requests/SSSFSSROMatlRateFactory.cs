//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroMatlRateFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroMatlRateFactory
	{
		public ISSSFSSroMatlRate Create(IApplicationDB appDB)
		{
			var _SSSFSSroMatlRate = new Logistics.FieldService.Requests.SSSFSSroMatlRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroMatlRateExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroMatlRate>(_SSSFSSroMatlRate);
			
			return iSSSFSSroMatlRateExt;
		}
	}
}
