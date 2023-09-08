//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLaborDCCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROLaborDCCheckFactory
	{
		public ISSSFSSROLaborDCCheck Create(IApplicationDB appDB)
		{
			var _SSSFSSROLaborDCCheck = new Logistics.FieldService.Requests.SSSFSSROLaborDCCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROLaborDCCheckExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROLaborDCCheck>(_SSSFSSROLaborDCCheck);
			
			return iSSSFSSROLaborDCCheckExt;
		}
	}
}
