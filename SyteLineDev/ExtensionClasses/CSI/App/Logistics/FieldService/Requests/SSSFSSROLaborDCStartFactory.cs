//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLaborDCStartFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROLaborDCStartFactory
	{
		public ISSSFSSROLaborDCStart Create(IApplicationDB appDB)
		{
			var _SSSFSSROLaborDCStart = new Logistics.FieldService.Requests.SSSFSSROLaborDCStart(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROLaborDCStartExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROLaborDCStart>(_SSSFSSROLaborDCStart);
			
			return iSSSFSSROLaborDCStartExt;
		}
	}
}
