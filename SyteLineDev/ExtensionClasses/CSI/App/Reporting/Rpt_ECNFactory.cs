//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECNFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ECNFactory
	{
		public IRpt_ECN Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ECN = new Reporting.Rpt_ECN(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ECNExt = timerfactory.Create<Reporting.IRpt_ECN>(_Rpt_ECN);
			
			return iRpt_ECNExt;
		}
	}
}
