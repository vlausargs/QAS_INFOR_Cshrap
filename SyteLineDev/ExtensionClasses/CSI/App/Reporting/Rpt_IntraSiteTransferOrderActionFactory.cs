//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IntraSiteTransferOrderActionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_IntraSiteTransferOrderActionFactory
	{
		public IRpt_IntraSiteTransferOrderAction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_IntraSiteTransferOrderAction = new Reporting.Rpt_IntraSiteTransferOrderAction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_IntraSiteTransferOrderActionExt = timerfactory.Create<Reporting.IRpt_IntraSiteTransferOrderAction>(_Rpt_IntraSiteTransferOrderAction);
			
			return iRpt_IntraSiteTransferOrderActionExt;
		}
	}
}
