//PROJECT NAME: Production
//CLASS NAME: PP_CLM_LoadEstimateWorksheetDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.PrintingPackaging
{
	public class PP_CLM_LoadEstimateWorksheetDataFactory
	{
		public IPP_CLM_LoadEstimateWorksheetData Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PP_CLM_LoadEstimateWorksheetData = new Production.PrintingPackaging.PP_CLM_LoadEstimateWorksheetData(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_CLM_LoadEstimateWorksheetDataExt = timerfactory.Create<Production.PrintingPackaging.IPP_CLM_LoadEstimateWorksheetData>(_PP_CLM_LoadEstimateWorksheetData);
			
			return iPP_CLM_LoadEstimateWorksheetDataExt;
		}
	}
}
