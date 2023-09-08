//PROJECT NAME: Logistics
//CLASS NAME: RetransmitEDIPlanningSchedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class RetransmitEDIPlanningSchedFactory
	{
		public IRetransmitEDIPlanningSched Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RetransmitEDIPlanningSched = new Logistics.Vendor.RetransmitEDIPlanningSched(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRetransmitEDIPlanningSchedExt = timerfactory.Create<Logistics.Vendor.IRetransmitEDIPlanningSched>(_RetransmitEDIPlanningSched);
			
			return iRetransmitEDIPlanningSchedExt;
		}
	}
}
