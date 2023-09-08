//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateJobIndentedBOMFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EstimateJobIndentedBOMFactory
	{
		public IRpt_EstimateJobIndentedBOM Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EstimateJobIndentedBOM = new Reporting.Rpt_EstimateJobIndentedBOM(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EstimateJobIndentedBOMExt = timerfactory.Create<Reporting.IRpt_EstimateJobIndentedBOM>(_Rpt_EstimateJobIndentedBOM);
			
			return iRpt_EstimateJobIndentedBOMExt;
		}
	}
}
