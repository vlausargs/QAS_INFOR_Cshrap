//PROJECT NAME: Codes
//CLASS NAME: GenerateEFTMappedImportViewFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;

namespace CSI.Codes
{
	public class GenerateEFTMappedImportViewFactory
	{
		public IGenerateEFTMappedImportView Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
			var _GenerateEFTMappedImportView = new Codes.GenerateEFTMappedImportView(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse, dataTableUtil);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateEFTMappedImportViewExt = timerfactory.Create<Codes.IGenerateEFTMappedImportView>(_GenerateEFTMappedImportView);
			
			return iGenerateEFTMappedImportViewExt;
		}
	}
}
