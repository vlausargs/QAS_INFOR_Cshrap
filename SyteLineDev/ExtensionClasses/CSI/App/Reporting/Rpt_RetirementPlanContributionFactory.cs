//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RetirementPlanContributionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RetirementPlanContributionFactory
	{
		public IRpt_RetirementPlanContribution Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RetirementPlanContribution = new Reporting.Rpt_RetirementPlanContribution(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RetirementPlanContributionExt = timerfactory.Create<Reporting.IRpt_RetirementPlanContribution>(_Rpt_RetirementPlanContribution);
			
			return iRpt_RetirementPlanContributionExt;
		}
	}
}
