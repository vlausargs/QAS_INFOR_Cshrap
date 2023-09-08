//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InboundPOAcknowledgmentFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InboundPOAcknowledgmentFactory
	{
		public IRpt_InboundPOAcknowledgment Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InboundPOAcknowledgment = new Reporting.Rpt_InboundPOAcknowledgment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InboundPOAcknowledgmentExt = timerfactory.Create<Reporting.IRpt_InboundPOAcknowledgment>(_Rpt_InboundPOAcknowledgment);
			
			return iRpt_InboundPOAcknowledgmentExt;
		}
	}
}
