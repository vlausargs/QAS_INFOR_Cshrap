//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CurrencyRevaluationFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CurrencyRevaluationFactory
	{
		public IRpt_CurrencyRevaluation Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CurrencyRevaluation = new Reporting.Rpt_CurrencyRevaluation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CurrencyRevaluationExt = timerfactory.Create<Reporting.IRpt_CurrencyRevaluation>(_Rpt_CurrencyRevaluation);
			
			return iRpt_CurrencyRevaluationExt;
		}
	}
}
