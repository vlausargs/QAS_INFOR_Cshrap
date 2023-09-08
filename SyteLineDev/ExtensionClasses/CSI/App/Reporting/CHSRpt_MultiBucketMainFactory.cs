//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_MultiBucketMainFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_MultiBucketMainFactory
	{
		public ICHSRpt_MultiBucketMain Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_MultiBucketMain = new Reporting.CHSRpt_MultiBucketMain(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_MultiBucketMainExt = timerfactory.Create<Reporting.ICHSRpt_MultiBucketMain>(_CHSRpt_MultiBucketMain);
			
			return iCHSRpt_MultiBucketMainExt;
		}
	}
}
