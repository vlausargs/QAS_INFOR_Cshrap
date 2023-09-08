//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseVATRegisterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PurchaseVATRegisterFactory
	{
		public IRpt_PurchaseVATRegister Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PurchaseVATRegister = new Reporting.Rpt_PurchaseVATRegister(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PurchaseVATRegisterExt = timerfactory.Create<Reporting.IRpt_PurchaseVATRegister>(_Rpt_PurchaseVATRegister);
			
			return iRpt_PurchaseVATRegisterExt;
		}
	}
}
