//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_ARAccountBookFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_ARAccountBookFactory
	{
		public ICHSRpt_ARAccountBook Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_ARAccountBook = new Reporting.CHSRpt_ARAccountBook(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_ARAccountBookExt = timerfactory.Create<Reporting.ICHSRpt_ARAccountBook>(_CHSRpt_ARAccountBook);
			
			return iCHSRpt_ARAccountBookExt;
		}
	}
}
