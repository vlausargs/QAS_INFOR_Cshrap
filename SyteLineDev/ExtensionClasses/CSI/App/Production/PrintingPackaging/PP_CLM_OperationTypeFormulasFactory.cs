//PROJECT NAME: Production
//CLASS NAME: PP_CLM_OperationTypeFormulasFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.PrintingPackaging
{
	public class PP_CLM_OperationTypeFormulasFactory
	{
		public IPP_CLM_OperationTypeFormulas Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PP_CLM_OperationTypeFormulas = new Production.PrintingPackaging.PP_CLM_OperationTypeFormulas(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_CLM_OperationTypeFormulasExt = timerfactory.Create<Production.PrintingPackaging.IPP_CLM_OperationTypeFormulas>(_PP_CLM_OperationTypeFormulas);
			
			return iPP_CLM_OperationTypeFormulasExt;
		}
	}
}
