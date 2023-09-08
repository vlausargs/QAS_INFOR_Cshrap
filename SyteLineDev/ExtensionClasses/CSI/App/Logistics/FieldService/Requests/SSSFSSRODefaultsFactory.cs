//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSRODefaultsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSRODefaultsFactory
	{
		public ISSSFSSRODefaults Create(IApplicationDB appDB)
		{
			var _SSSFSSRODefaults = new Logistics.FieldService.Requests.SSSFSSRODefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSRODefaultsExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSRODefaults>(_SSSFSSRODefaults);
			
			return iSSSFSSRODefaultsExt;
		}
	}
}
