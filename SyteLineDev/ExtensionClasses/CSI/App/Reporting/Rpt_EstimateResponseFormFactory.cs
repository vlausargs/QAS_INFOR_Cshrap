//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateResponseFormFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EstimateResponseFormFactory
	{
		public IRpt_EstimateResponseForm Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EstimateResponseForm = new Reporting.Rpt_EstimateResponseForm(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EstimateResponseFormExt = timerfactory.Create<Reporting.IRpt_EstimateResponseForm>(_Rpt_EstimateResponseForm);
			
			return iRpt_EstimateResponseFormExt;
		}
	}
}
