//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroTransPostMiscFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroTransPostMiscFactory
	{
		public ISSSFSSroTransPostMisc Create(IApplicationDB appDB)
		{
			var _SSSFSSroTransPostMisc = new Logistics.FieldService.Requests.SSSFSSroTransPostMisc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroTransPostMiscExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroTransPostMisc>(_SSSFSSroTransPostMisc);
			
			return iSSSFSSroTransPostMiscExt;
		}
	}
}
