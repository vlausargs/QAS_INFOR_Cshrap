//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROSSDDefaultsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROSSDDefaultsFactory
	{
		public ISSSFSSROSSDDefaults Create(IApplicationDB appDB)
		{
			var _SSSFSSROSSDDefaults = new Logistics.FieldService.Requests.SSSFSSROSSDDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROSSDDefaultsExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROSSDDefaults>(_SSSFSSROSSDDefaults);
			
			return iSSSFSSROSSDDefaultsExt;
		}
	}
}
