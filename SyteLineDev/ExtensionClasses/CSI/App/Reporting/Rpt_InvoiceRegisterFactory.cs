//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceRegisterFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InvoiceRegisterFactory
	{
		public IRpt_InvoiceRegister Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InvoiceRegister = new Reporting.Rpt_InvoiceRegister(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InvoiceRegisterExt = timerfactory.Create<Reporting.IRpt_InvoiceRegister>(_Rpt_InvoiceRegister);
			
			return iRpt_InvoiceRegisterExt;
		}
	}
}
