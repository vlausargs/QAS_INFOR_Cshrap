//PROJECT NAME: Reporting
//CLASS NAME: Rpt_1095FormPrintingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_1095FormPrintingFactory
	{
		public IRpt_1095FormPrinting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_1095FormPrinting = new Reporting.Rpt_1095FormPrinting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_1095FormPrintingExt = timerfactory.Create<Reporting.IRpt_1095FormPrinting>(_Rpt_1095FormPrinting);
			
			return iRpt_1095FormPrintingExt;
		}
	}
}
