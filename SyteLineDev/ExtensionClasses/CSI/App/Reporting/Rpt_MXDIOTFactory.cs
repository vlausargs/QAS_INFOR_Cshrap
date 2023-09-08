//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MXDIOTFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MXDIOTFactory
	{
		public IRpt_MXDIOT Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MXDIOT = new Reporting.Rpt_MXDIOT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MXDIOTExt = timerfactory.Create<Reporting.IRpt_MXDIOT>(_Rpt_MXDIOT);
			
			return iRpt_MXDIOTExt;
		}
	}
}
