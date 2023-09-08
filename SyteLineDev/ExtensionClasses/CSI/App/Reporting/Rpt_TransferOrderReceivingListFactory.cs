//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferOrderReceivingListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TransferOrderReceivingListFactory
	{
		public IRpt_TransferOrderReceivingList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TransferOrderReceivingList = new Reporting.Rpt_TransferOrderReceivingList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TransferOrderReceivingListExt = timerfactory.Create<Reporting.IRpt_TransferOrderReceivingList>(_Rpt_TransferOrderReceivingList);
			
			return iRpt_TransferOrderReceivingListExt;
		}
	}
}
