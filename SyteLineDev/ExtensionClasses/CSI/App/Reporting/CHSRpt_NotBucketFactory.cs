//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_NotBucketFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_NotBucketFactory
	{
		public ICHSRpt_NotBucket Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_NotBucket = new Reporting.CHSRpt_NotBucket(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_NotBucketExt = timerfactory.Create<Reporting.ICHSRpt_NotBucket>(_CHSRpt_NotBucket);
			
			return iCHSRpt_NotBucketExt;
		}
	}
}
