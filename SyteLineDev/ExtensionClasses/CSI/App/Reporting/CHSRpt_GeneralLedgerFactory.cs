//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_GeneralLedgerFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_GeneralLedgerFactory
	{
		public ICHSRpt_GeneralLedger Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_GeneralLedger = new Reporting.CHSRpt_GeneralLedger(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_GeneralLedgerExt = timerfactory.Create<Reporting.ICHSRpt_GeneralLedger>(_CHSRpt_GeneralLedger);
			
			return iCHSRpt_GeneralLedgerExt;
		}
	}
}
