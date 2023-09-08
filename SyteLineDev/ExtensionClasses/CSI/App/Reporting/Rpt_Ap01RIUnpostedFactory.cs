//PROJECT NAME: Reporting
//CLASS NAME: Rpt_Ap01RIUnpostedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_Ap01RIUnpostedFactory
	{
		public IRpt_Ap01RIUnposted Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_Ap01RIUnposted = new Reporting.Rpt_Ap01RIUnposted(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_Ap01RIUnpostedExt = timerfactory.Create<Reporting.IRpt_Ap01RIUnposted>(_Rpt_Ap01RIUnposted);
			
			return iRpt_Ap01RIUnpostedExt;
		}
	}
}
