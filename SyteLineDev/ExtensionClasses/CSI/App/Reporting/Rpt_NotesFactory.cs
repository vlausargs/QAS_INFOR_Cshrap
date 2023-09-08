//PROJECT NAME: Reporting
//CLASS NAME: Rpt_NotesFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.CRUD.Reporting;

namespace CSI.Reporting
{
	public class Rpt_NotesFactory
	{
		public const string IDO = "SLReportNotesViews";
		public const string Method = "Rpt_Notes";
		
		public IRpt_Notes Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var rpt_NotesCRUD = new Rpt_NotesCRUD(appDB, collectionLoadStatementRequestFactory, collectionLoadRequestFactory);
			
			IRpt_Notes _Rpt_Notes = new Rpt_Notes(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				existsChecker,
				stringUtil,
				sQLUtil,
				rpt_NotesCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_Notes = IDOMethodIntercept<IRpt_Notes>.Create(_Rpt_Notes, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_NotesExt = timerfactory.Create<IRpt_Notes>(_Rpt_Notes);
			
			return iRpt_NotesExt;
		}
	}
}
