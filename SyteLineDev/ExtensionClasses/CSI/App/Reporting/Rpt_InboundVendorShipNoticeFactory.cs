//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InboundVendorShipNoticeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InboundVendorShipNoticeFactory
	{
		public IRpt_InboundVendorShipNotice Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InboundVendorShipNotice = new Reporting.Rpt_InboundVendorShipNotice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InboundVendorShipNoticeExt = timerfactory.Create<Reporting.IRpt_InboundVendorShipNotice>(_Rpt_InboundVendorShipNotice);
			
			return iRpt_InboundVendorShipNoticeExt;
		}
	}
}
