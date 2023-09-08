//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetAcquisitionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_FixedAssetAcquisitionFactory
	{
		public IRpt_FixedAssetAcquisition Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_FixedAssetAcquisition = new Reporting.Rpt_FixedAssetAcquisition(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_FixedAssetAcquisitionExt = timerfactory.Create<Reporting.IRpt_FixedAssetAcquisition>(_Rpt_FixedAssetAcquisition);
			
			return iRpt_FixedAssetAcquisitionExt;
		}
	}
}
