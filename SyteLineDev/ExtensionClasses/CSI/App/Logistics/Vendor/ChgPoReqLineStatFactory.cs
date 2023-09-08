//PROJECT NAME: CSIVendor
//CLASS NAME: ChgPoReqLineStatFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ChgPoReqLineStatFactory
	{
		public IChgPoReqLineStat Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ChgPoReqLineStat = new Logistics.Vendor.ChgPoReqLineStat(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChgPoReqLineStatExt = timerfactory.Create<Logistics.Vendor.IChgPoReqLineStat>(_ChgPoReqLineStat);
			
			return iChgPoReqLineStatExt;
		}
	}
}
