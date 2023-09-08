//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MXDIOTExeptionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MXDIOTExeptionsFactory
	{
		public IRpt_MXDIOTExeptions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MXDIOTExeptions = new Reporting.Rpt_MXDIOTExeptions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MXDIOTExeptionsExt = timerfactory.Create<Reporting.IRpt_MXDIOTExeptions>(_Rpt_MXDIOTExeptions);
			
			return iRpt_MXDIOTExeptionsExt;
		}
	}
}
