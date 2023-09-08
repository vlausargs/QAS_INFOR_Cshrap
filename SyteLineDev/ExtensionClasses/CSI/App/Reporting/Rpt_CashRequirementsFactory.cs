//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CashRequirementsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CashRequirementsFactory
	{
		public IRpt_CashRequirements Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CashRequirements = new Reporting.Rpt_CashRequirements(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CashRequirementsExt = timerfactory.Create<Reporting.IRpt_CashRequirements>(_Rpt_CashRequirements);
			
			return iRpt_CashRequirementsExt;
		}
	}
}
