//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferOrderKitPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TransferOrderKitPickListFactory
	{
		public IRpt_TransferOrderKitPickList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TransferOrderKitPickList = new Reporting.Rpt_TransferOrderKitPickList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TransferOrderKitPickListExt = timerfactory.Create<Reporting.IRpt_TransferOrderKitPickList>(_Rpt_TransferOrderKitPickList);
			
			return iRpt_TransferOrderKitPickListExt;
		}
	}
}
