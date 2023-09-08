//PROJECT NAME: CSIReport
//CLASS NAME: ItemABCAnalysisFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class ItemABCAnalysisFactory
	{
		public IItemABCAnalysis Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ItemABCAnalysis = new Reporting.ItemABCAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemABCAnalysisExt = timerfactory.Create<Reporting.IItemABCAnalysis>(_ItemABCAnalysis);
			
			return iItemABCAnalysisExt;
		}
	}
}
