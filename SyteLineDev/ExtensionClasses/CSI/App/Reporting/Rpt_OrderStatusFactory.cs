//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_OrderStatusFactory
	{
		public IRpt_OrderStatus Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_OrderStatus = new Reporting.Rpt_OrderStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_OrderStatusExt = timerfactory.Create<Reporting.IRpt_OrderStatus>(_Rpt_OrderStatus);
			
			return iRpt_OrderStatusExt;
		}
	}
}
