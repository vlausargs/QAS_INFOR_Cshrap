//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_PrintBankBookFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_PrintBankBookFactory
	{
		public ICHSRpt_PrintBankBook Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_PrintBankBook = new Reporting.CHSRpt_PrintBankBook(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_PrintBankBookExt = timerfactory.Create<Reporting.ICHSRpt_PrintBankBook>(_CHSRpt_PrintBankBook);
			
			return iCHSRpt_PrintBankBookExt;
		}
	}
}
