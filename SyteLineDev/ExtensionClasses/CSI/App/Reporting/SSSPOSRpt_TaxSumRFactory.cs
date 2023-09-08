//PROJECT NAME: Reporting
//CLASS NAME: SSSPOSRpt_TaxSumRFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSPOSRpt_TaxSumRFactory
	{
		public ISSSPOSRpt_TaxSumR Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSPOSRpt_TaxSumR = new Reporting.SSSPOSRpt_TaxSumR(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSRpt_TaxSumRExt = timerfactory.Create<Reporting.ISSSPOSRpt_TaxSumR>(_SSSPOSRpt_TaxSumR);
			
			return iSSSPOSRpt_TaxSumRExt;
		}
	}
}
