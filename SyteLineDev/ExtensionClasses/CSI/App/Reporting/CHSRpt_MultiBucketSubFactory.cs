//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_MultiBucketSubFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_MultiBucketSubFactory
	{
		public ICHSRpt_MultiBucketSub Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_MultiBucketSub = new Reporting.CHSRpt_MultiBucketSub(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_MultiBucketSubExt = timerfactory.Create<Reporting.ICHSRpt_MultiBucketSub>(_CHSRpt_MultiBucketSub);
			
			return iCHSRpt_MultiBucketSubExt;
		}
	}
}
