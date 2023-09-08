//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DunningFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_DunningFactory
	{
		public IRpt_Dunning Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_Dunning = new Reporting.Rpt_Dunning(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_DunningExt = timerfactory.Create<Reporting.IRpt_Dunning>(_Rpt_Dunning);
			
			return iRpt_DunningExt;
		}
	}
}
