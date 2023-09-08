//PROJECT NAME: Logistics
//CLASS NAME: Rpt_ShippedLCRsWithARemainingBalanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Rpt_ShippedLCRsWithARemainingBalanceFactory
	{
		public IRpt_ShippedLCRsWithARemainingBalance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ShippedLCRsWithARemainingBalance = new Logistics.Customer.Rpt_ShippedLCRsWithARemainingBalance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ShippedLCRsWithARemainingBalanceExt = timerfactory.Create<Logistics.Customer.IRpt_ShippedLCRsWithARemainingBalance>(_Rpt_ShippedLCRsWithARemainingBalance);
			
			return iRpt_ShippedLCRsWithARemainingBalanceExt;
		}
	}
}
