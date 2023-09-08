//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OutboundShippingScheduleFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_OutboundShippingScheduleFactory
	{
		public IRpt_OutboundShippingSchedule Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_OutboundShippingSchedule = new Reporting.Rpt_OutboundShippingSchedule(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_OutboundShippingScheduleExt = timerfactory.Create<Reporting.IRpt_OutboundShippingSchedule>(_Rpt_OutboundShippingSchedule);
			
			return iRpt_OutboundShippingScheduleExt;
		}
	}
}
