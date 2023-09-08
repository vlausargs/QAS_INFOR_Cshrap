//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetQuarterlyCostIncurredFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FixedAssetQuarterlyCostIncurredFactory
	{
		public IRpt_FixedAssetQuarterlyCostIncurred Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FixedAssetQuarterlyCostIncurred = new Reporting.Rpt_FixedAssetQuarterlyCostIncurred(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FixedAssetQuarterlyCostIncurredExt = timerfactory.Create<Reporting.IRpt_FixedAssetQuarterlyCostIncurred>(_Rpt_FixedAssetQuarterlyCostIncurred);
			
			return iRpt_FixedAssetQuarterlyCostIncurredExt;
		}
	}
}
