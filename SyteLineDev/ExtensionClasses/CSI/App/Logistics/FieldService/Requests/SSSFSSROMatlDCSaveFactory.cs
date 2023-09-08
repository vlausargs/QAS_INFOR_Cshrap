//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROMatlDCSaveFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROMatlDCSaveFactory
	{
		public ISSSFSSROMatlDCSave Create(IApplicationDB appDB)
		{
			var _SSSFSSROMatlDCSave = new Logistics.FieldService.Requests.SSSFSSROMatlDCSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROMatlDCSaveExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROMatlDCSave>(_SSSFSSROMatlDCSave);
			
			return iSSSFSSROMatlDCSaveExt;
		}
	}
}
