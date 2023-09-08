//PROJECT NAME: Finance
//CLASS NAME: CLM_EftOutputFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_EftOutputFactory
	{
		public ICLM_EftOutput Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_EftOutput = new Finance.CLM_EftOutput(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_EftOutputExt = timerfactory.Create<Finance.ICLM_EftOutput>(_CLM_EftOutput);
			
			return iCLM_EftOutputExt;
		}
	}
}
