//PROJECT NAME: Reporting
//CLASS NAME: Rpt_Ap01RIDoPostFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_Ap01RIDoPostFactory
	{
		public IRpt_Ap01RIDoPost Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_Ap01RIDoPost = new Reporting.Rpt_Ap01RIDoPost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_Ap01RIDoPostExt = timerfactory.Create<Reporting.IRpt_Ap01RIDoPost>(_Rpt_Ap01RIDoPost);
			
			return iRpt_Ap01RIDoPostExt;
		}
	}
}
