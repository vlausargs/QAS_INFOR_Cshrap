//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetCurrentDepreciationFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FixedAssetCurrentDepreciationFactory
	{
		public IRpt_FixedAssetCurrentDepreciation Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FixedAssetCurrentDepreciation = new Reporting.Rpt_FixedAssetCurrentDepreciation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FixedAssetCurrentDepreciationExt = timerfactory.Create<Reporting.IRpt_FixedAssetCurrentDepreciation>(_Rpt_FixedAssetCurrentDepreciation);
			
			return iRpt_FixedAssetCurrentDepreciationExt;
		}
	}
}
