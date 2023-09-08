//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MassJP_MsgFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MassJP_MsgFactory
	{
		public IRpt_MassJP_Msg Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MassJP_Msg = new Reporting.Rpt_MassJP_Msg(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MassJP_MsgExt = timerfactory.Create<Reporting.IRpt_MassJP_Msg>(_Rpt_MassJP_Msg);
			
			return iRpt_MassJP_MsgExt;
		}
	}
}
