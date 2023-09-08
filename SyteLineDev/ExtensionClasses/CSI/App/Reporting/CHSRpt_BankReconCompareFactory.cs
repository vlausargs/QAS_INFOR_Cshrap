//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_BankReconCompareFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_BankReconCompareFactory
	{
		public ICHSRpt_BankReconCompare Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_BankReconCompare = new Reporting.CHSRpt_BankReconCompare(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_BankReconCompareExt = timerfactory.Create<Reporting.ICHSRpt_BankReconCompare>(_CHSRpt_BankReconCompare);
			
			return iCHSRpt_BankReconCompareExt;
		}
	}
}
