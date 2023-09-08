//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MRPOrderActionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MRPOrderActionFactory
	{
		public IRpt_MRPOrderAction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MRPOrderAction = new Reporting.Rpt_MRPOrderAction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MRPOrderActionExt = timerfactory.Create<Reporting.IRpt_MRPOrderAction>(_Rpt_MRPOrderAction);
			
			return iRpt_MRPOrderActionExt;
		}
	}
}
