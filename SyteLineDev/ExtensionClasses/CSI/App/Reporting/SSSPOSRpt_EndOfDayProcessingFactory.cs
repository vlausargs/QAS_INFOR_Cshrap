//PROJECT NAME: Reporting
//CLASS NAME: SSSPOSRpt_EndOfDayProcessingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSPOSRpt_EndOfDayProcessingFactory
	{
		public ISSSPOSRpt_EndOfDayProcessing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSPOSRpt_EndOfDayProcessing = new Reporting.SSSPOSRpt_EndOfDayProcessing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSRpt_EndOfDayProcessingExt = timerfactory.Create<Reporting.ISSSPOSRpt_EndOfDayProcessing>(_SSSPOSRpt_EndOfDayProcessing);
			
			return iSSSPOSRpt_EndOfDayProcessingExt;
		}
	}
}
