//PROJECT NAME: Reporting
//CLASS NAME: SSSPOSRpt_POSInc_RFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSPOSRpt_POSInc_RFactory
	{
		public ISSSPOSRpt_POSInc_R Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSPOSRpt_POSInc_R = new Reporting.SSSPOSRpt_POSInc_R(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSRpt_POSInc_RExt = timerfactory.Create<Reporting.ISSSPOSRpt_POSInc_R>(_SSSPOSRpt_POSInc_R);
			
			return iSSSPOSRpt_POSInc_RExt;
		}
	}
}
