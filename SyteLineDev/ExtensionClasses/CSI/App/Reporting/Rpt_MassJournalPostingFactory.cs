//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MassJournalPostingFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Finance;
using CSI.Data.Cache;

namespace CSI.Reporting
{
	public class Rpt_MassJournalPostingFactory
	{
		public const string IDO = "SLMassJournalPostingReport";
		public const string Method = "Rpt_MassJournalPosting";
		
		public IRpt_MassJournalPosting Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, true);
			var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, true);
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iPrtAcctDis = new PrtAcctDisFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var stringUtil = new StringUtil();
			//var iLowDate = cSIExtensionClassBase.MGCoreFeatures.LowDate;
            var lowDataCache = cSIExtensionClassBase.MongooseDependencies.LowDateCache;
            var unionUtil = new UnionUtil(UnionType.UnionAll);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iPerGet = new PerGetFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);
            var sortOrderFactory = new SortOrderFactory();
            var recordStreamFactory = new RecordStreamFactory();
            var bookmarkFactory = new BookmarkFactory();
            var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
            var collectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);
            
            var iRpt_MassJournalPostingCRUD = new Rpt_MassJournalPostingCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
                collectionNonTriggerInsertRequestFactory,
                collectionNonTriggerDeleteRequestFactory,
                existsChecker,
				convertToUtil,
				variableUtil,
				stringUtil,
				sQLUtil,
                unionUtil,
                sQLExpressionExecutor,
                bunchedLoadCollection,
                recordStreamFactory,
                sortOrderFactory,
                bookmarkFactory,
                queryLanguage,
                mgSessionVariableBasedCache,
                defineProcessVariable,
                getVariable,
                CachePageSize.XLarge);
			
			IRpt_MassJournalPosting _Rpt_MassJournalPosting = new Rpt_MassJournalPosting(bunchedLoadCollection,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iGetWinRegDecGroup,
				iFixMaskForCrystal,
				iApplyDateOffset,
				scalarFunction,
				convertToUtil,
				iPrtAcctDis,
				stringUtil,
                lowDataCache,
				sQLUtil,
				iPerGet,
				iRpt_MassJournalPostingCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_MassJournalPosting = IDOMethodIntercept<IRpt_MassJournalPosting>.Create(_Rpt_MassJournalPosting, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MassJournalPostingExt = timerfactory.Create<IRpt_MassJournalPosting>(_Rpt_MassJournalPosting);
			
			return iRpt_MassJournalPostingExt;
		}
	}
}
