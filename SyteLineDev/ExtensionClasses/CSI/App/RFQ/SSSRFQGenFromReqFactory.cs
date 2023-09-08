//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQGenFromReqFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.RFQ
{
	public class SSSRFQGenFromReqFactory
	{
		public ISSSRFQGenFromReq Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRFQGenFromReq = new RFQ.SSSRFQGenFromReq(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQGenFromReqExt = timerfactory.Create<RFQ.ISSSRFQGenFromReq>(_SSSRFQGenFromReq);
			
			return iSSSRFQGenFromReqExt;
		}
	}
}
