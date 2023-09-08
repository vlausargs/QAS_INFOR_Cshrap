//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSGetDefWhseFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSGetDefWhseFactory
	{
		public ISSSFSGetDefWhse Create(IApplicationDB appDB)
		{
			var _SSSFSGetDefWhse = new Logistics.FieldService.Requests.SSSFSGetDefWhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSGetDefWhseExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSGetDefWhse>(_SSSFSGetDefWhse);
			
			return iSSSFSGetDefWhseExt;
		}
	}
}
