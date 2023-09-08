//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintDeliveryOrderPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PrintDeliveryOrderPackingSlipFactory
	{
		public IRpt_PrintDeliveryOrderPackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PrintDeliveryOrderPackingSlip = new Reporting.Rpt_PrintDeliveryOrderPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PrintDeliveryOrderPackingSlipExt = timerfactory.Create<Reporting.IRpt_PrintDeliveryOrderPackingSlip>(_Rpt_PrintDeliveryOrderPackingSlip);
			
			return iRpt_PrintDeliveryOrderPackingSlipExt;
		}
	}
}
