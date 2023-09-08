//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroTransPostLaborFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroTransPostLaborFactory
	{
		public ISSSFSSroTransPostLabor Create(IApplicationDB appDB)
		{
			var _SSSFSSroTransPostLabor = new Logistics.FieldService.Requests.SSSFSSroTransPostLabor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroTransPostLaborExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroTransPostLabor>(_SSSFSSroTransPostLabor);
			
			return iSSSFSSroTransPostLaborExt;
		}
	}
}
