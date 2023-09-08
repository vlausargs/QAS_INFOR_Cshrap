//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintW2FormsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PrintW2FormsFactory
	{
		public IRpt_PrintW2Forms Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PrintW2Forms = new Reporting.Rpt_PrintW2Forms(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PrintW2FormsExt = timerfactory.Create<Reporting.IRpt_PrintW2Forms>(_Rpt_PrintW2Forms);
			
			return iRpt_PrintW2FormsExt;
		}
	}
}
