//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MXIETUFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MXIETUFactory
	{
		public IRpt_MXIETU Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MXIETU = new Reporting.Rpt_MXIETU(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MXIETUExt = timerfactory.Create<Reporting.IRpt_MXIETU>(_Rpt_MXIETU);
			
			return iRpt_MXIETUExt;
		}
	}
}
