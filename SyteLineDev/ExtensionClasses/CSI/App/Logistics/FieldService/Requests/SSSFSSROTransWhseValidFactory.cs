//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransWhseValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransWhseValidFactory
	{
		public ISSSFSSROTransWhseValid Create(IApplicationDB appDB)
		{
			var _SSSFSSROTransWhseValid = new Logistics.FieldService.Requests.SSSFSSROTransWhseValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTransWhseValidExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTransWhseValid>(_SSSFSSROTransWhseValid);
			
			return iSSSFSSROTransWhseValidExt;
		}
	}
}
