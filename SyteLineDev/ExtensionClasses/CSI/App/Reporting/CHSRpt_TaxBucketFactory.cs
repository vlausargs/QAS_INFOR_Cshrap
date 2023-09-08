//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_TaxBucketFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_TaxBucketFactory
	{
		public ICHSRpt_TaxBucket Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_TaxBucket = new Reporting.CHSRpt_TaxBucket(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_TaxBucketExt = timerfactory.Create<Reporting.ICHSRpt_TaxBucket>(_CHSRpt_TaxBucket);
			
			return iCHSRpt_TaxBucketExt;
		}
	}
}
