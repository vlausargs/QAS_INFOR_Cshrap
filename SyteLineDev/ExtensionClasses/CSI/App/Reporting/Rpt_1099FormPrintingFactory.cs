//PROJECT NAME: Reporting
//CLASS NAME: Rpt_1099FormPrintingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_1099FormPrintingFactory
	{
		public IRpt_1099FormPrinting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_1099FormPrinting = new Reporting.Rpt_1099FormPrinting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_1099FormPrintingExt = timerfactory.Create<Reporting.IRpt_1099FormPrinting>(_Rpt_1099FormPrinting);
			
			return iRpt_1099FormPrintingExt;
		}
	}
}
