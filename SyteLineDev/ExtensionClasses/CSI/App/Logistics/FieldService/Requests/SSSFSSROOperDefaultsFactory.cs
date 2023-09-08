//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROOperDefaultsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROOperDefaultsFactory
	{
		public ISSSFSSROOperDefaults Create(IApplicationDB appDB)
		{
			var _SSSFSSROOperDefaults = new Logistics.FieldService.Requests.SSSFSSROOperDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROOperDefaultsExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROOperDefaults>(_SSSFSSROOperDefaults);
			
			return iSSSFSSROOperDefaultsExt;
		}
	}
}
