//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectChangeOrderDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectChangeOrderDetailFactory
	{
		public IRpt_ProjectChangeOrderDetail Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectChangeOrderDetail = new Reporting.Rpt_ProjectChangeOrderDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectChangeOrderDetailExt = timerfactory.Create<Reporting.IRpt_ProjectChangeOrderDetail>(_Rpt_ProjectChangeOrderDetail);
			
			return iRpt_ProjectChangeOrderDetailExt;
		}
	}
}
