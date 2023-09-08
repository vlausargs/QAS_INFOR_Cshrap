//PROJECT NAME: CSIVendor
//CLASS NAME: ChgPoStatFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ChgPoStatFactory
	{
		public IChgPoStat Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ChgPoStat = new Logistics.Vendor.ChgPoStat(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChgPoStatExt = timerfactory.Create<Logistics.Vendor.IChgPoStat>(_ChgPoStat);
			
			return iChgPoStatExt;
		}
	}
}
