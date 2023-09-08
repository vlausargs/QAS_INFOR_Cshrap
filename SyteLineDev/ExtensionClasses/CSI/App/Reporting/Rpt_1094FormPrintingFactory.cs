//PROJECT NAME: Reporting
//CLASS NAME: Rpt_1094FormPrintingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_1094FormPrintingFactory
	{
		public IRpt_1094FormPrinting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_1094FormPrinting = new Reporting.Rpt_1094FormPrinting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_1094FormPrintingExt = timerfactory.Create<Reporting.IRpt_1094FormPrinting>(_Rpt_1094FormPrinting);
			
			return iRpt_1094FormPrintingExt;
		}
	}
}
