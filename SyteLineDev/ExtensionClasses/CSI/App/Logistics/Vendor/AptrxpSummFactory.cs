//PROJECT NAME: Logistics
//CLASS NAME: AptrxpSummFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class AptrxpSummFactory
	{
		public IAptrxpSumm Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _AptrxpSumm = new Logistics.Vendor.AptrxpSumm(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAptrxpSummExt = timerfactory.Create<Logistics.Vendor.IAptrxpSumm>(_AptrxpSumm);
			
			return iAptrxpSummExt;
		}
	}
}
