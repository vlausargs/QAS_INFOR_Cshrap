//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTypeDefaultsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTypeDefaultsFactory
	{
		public ISSSFSSROTypeDefaults Create(IApplicationDB appDB)
		{
			var _SSSFSSROTypeDefaults = new Logistics.FieldService.Requests.SSSFSSROTypeDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROTypeDefaultsExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROTypeDefaults>(_SSSFSSROTypeDefaults);
			
			return iSSSFSSROTypeDefaultsExt;
		}
	}
}
