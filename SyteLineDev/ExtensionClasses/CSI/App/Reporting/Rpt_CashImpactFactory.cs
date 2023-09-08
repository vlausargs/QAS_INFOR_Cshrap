//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CashImpactFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CashImpactFactory
	{
		public IRpt_CashImpact Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CashImpact = new Reporting.Rpt_CashImpact(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CashImpactExt = timerfactory.Create<Reporting.IRpt_CashImpact>(_Rpt_CashImpact);
			
			return iRpt_CashImpactExt;
		}
	}
}
