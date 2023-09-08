//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSContLineDefaultsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContLineDefaultsFactory
	{
		public ISSSFSContLineDefaults Create(IApplicationDB appDB)
		{
			var _SSSFSContLineDefaults = new Logistics.FieldService.SSSFSContLineDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSContLineDefaultsExt = timerfactory.Create<Logistics.FieldService.ISSSFSContLineDefaults>(_SSSFSContLineDefaults);
			
			return iSSSFSContLineDefaultsExt;
		}
	}
}
