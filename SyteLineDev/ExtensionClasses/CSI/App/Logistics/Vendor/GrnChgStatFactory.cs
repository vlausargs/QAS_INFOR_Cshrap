//PROJECT NAME: Logistics
//CLASS NAME: GrnChgStatFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class GrnChgStatFactory
	{
		public IGrnChgStat Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GrnChgStat = new Logistics.Vendor.GrnChgStat(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGrnChgStatExt = timerfactory.Create<Logistics.Vendor.IGrnChgStat>(_GrnChgStat);
			
			return iGrnChgStatExt;
		}
	}
}
