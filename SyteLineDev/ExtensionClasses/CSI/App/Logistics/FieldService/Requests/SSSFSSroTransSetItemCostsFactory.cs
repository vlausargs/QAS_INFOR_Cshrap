//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroTransSetItemCostsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSroTransSetItemCostsFactory
	{
		public ISSSFSSroTransSetItemCosts Create(IApplicationDB appDB)
		{
			var _SSSFSSroTransSetItemCosts = new Logistics.FieldService.Requests.SSSFSSroTransSetItemCosts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSroTransSetItemCostsExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroTransSetItemCosts>(_SSSFSSroTransSetItemCosts);
			
			return iSSSFSSroTransSetItemCostsExt;
		}
	}
}
