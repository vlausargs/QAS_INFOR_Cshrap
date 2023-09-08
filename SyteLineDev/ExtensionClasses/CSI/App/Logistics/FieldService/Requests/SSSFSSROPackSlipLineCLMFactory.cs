//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROPackSlipLineCLMFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROPackSlipLineCLMFactory
	{
		public ISSSFSSROPackSlipLineCLM Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSSROPackSlipLineCLM = new Logistics.FieldService.Requests.SSSFSSROPackSlipLineCLM(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSROPackSlipLineCLMExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSROPackSlipLineCLM>(_SSSFSSROPackSlipLineCLM);
			
			return iSSSFSSROPackSlipLineCLMExt;
		}
	}
}
