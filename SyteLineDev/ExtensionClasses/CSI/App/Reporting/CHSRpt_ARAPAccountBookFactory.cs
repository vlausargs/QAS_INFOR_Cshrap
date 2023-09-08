//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_ARAPAccountBookFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_ARAPAccountBookFactory
	{
		public ICHSRpt_ARAPAccountBook Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_ARAPAccountBook = new Reporting.CHSRpt_ARAPAccountBook(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_ARAPAccountBookExt = timerfactory.Create<Reporting.ICHSRpt_ARAPAccountBook>(_CHSRpt_ARAPAccountBook);
			
			return iCHSRpt_ARAPAccountBookExt;
		}
	}
}
