//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AvailableInventorytoReserveFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_AvailableInventorytoReserveFactory
	{
		public IRpt_AvailableInventorytoReserve Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_AvailableInventorytoReserve = new Reporting.Rpt_AvailableInventorytoReserve(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_AvailableInventorytoReserveExt = timerfactory.Create<Reporting.IRpt_AvailableInventorytoReserve>(_Rpt_AvailableInventorytoReserve);
			
			return iRpt_AvailableInventorytoReserveExt;
		}
	}
}
