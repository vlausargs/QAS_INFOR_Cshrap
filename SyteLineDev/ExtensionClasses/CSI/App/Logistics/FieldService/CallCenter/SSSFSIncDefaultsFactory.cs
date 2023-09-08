//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncDefaultsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSIncDefaultsFactory
	{
		public ISSSFSIncDefaults Create(IApplicationDB appDB)
		{
			var _SSSFSIncDefaults = new Logistics.FieldService.CallCenter.SSSFSIncDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSIncDefaultsExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSIncDefaults>(_SSSFSIncDefaults);
			
			return iSSSFSIncDefaultsExt;
		}
	}
}
