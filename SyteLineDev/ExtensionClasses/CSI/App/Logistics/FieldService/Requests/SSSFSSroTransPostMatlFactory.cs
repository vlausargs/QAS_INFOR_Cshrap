//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroTransPostMatlFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroTransPostMatlFactory
	{
		public ISSSFSSroTransPostMatl Create(IApplicationDB appDB)
		{
			var _SSSFSSroTransPostMatl = new Logistics.FieldService.Requests.SSSFSSroTransPostMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroTransPostMatlExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroTransPostMatl>(_SSSFSSroTransPostMatl);
			
			return iSSSFSSroTransPostMatlExt;
		}
	}
}
