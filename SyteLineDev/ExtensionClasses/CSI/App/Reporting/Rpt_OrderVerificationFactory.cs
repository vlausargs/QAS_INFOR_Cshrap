//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderVerificationFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_OrderVerificationFactory
	{
		public IRpt_OrderVerification Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_OrderVerification = new Reporting.Rpt_OrderVerification(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_OrderVerificationExt = timerfactory.Create<Reporting.IRpt_OrderVerification>(_Rpt_OrderVerification);
			
			return iRpt_OrderVerificationExt;
		}
	}
}
