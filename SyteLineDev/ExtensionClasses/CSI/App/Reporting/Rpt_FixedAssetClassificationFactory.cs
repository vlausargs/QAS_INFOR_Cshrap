//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetClassificationFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FixedAssetClassificationFactory
	{
		public IRpt_FixedAssetClassification Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FixedAssetClassification = new Reporting.Rpt_FixedAssetClassification(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FixedAssetClassificationExt = timerfactory.Create<Reporting.IRpt_FixedAssetClassification>(_Rpt_FixedAssetClassification);
			
			return iRpt_FixedAssetClassificationExt;
		}
	}
}
