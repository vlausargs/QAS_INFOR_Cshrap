//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IndentedCostedBillofMaterialFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Adapters;
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Rpt_IndentedCostedBillofMaterialFactory
    {
        public const string IDO = "SLIndentedCostedBillOfMaterialReport";
        public const string Method = "Rpt_IndentedCostedBillofMaterial";

        public IRpt_IndentedCostedBillofMaterial Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
            var stringUtil = new StringUtil();
            var highString = cSIExtensionClassBase.MongooseDependencies.HighString;
            var lowString = cSIExtensionClassBase.MongooseDependencies.LowString;
            var iGetCode = new GetCodeCacheFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);

            var sortOrderFactory = new SortOrderFactory();
            var bookmarkFactory = new BookmarkFactory();
            var recordStreamFactory = new RecordStreamFactory();
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);

            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;

            var defineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;

            var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
            var collectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);

            var iRpt_IndentedCostedBillofMaterialCRUD = new Rpt_IndentedCostedBillofMaterialCRUD(appDB, collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                variableUtil,
                stringUtil,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                collectionNonTriggerInsertRequestFactory,
                collectionNonTriggerDeleteRequestFactory,
                iGetIsolationLevel,
                sQLUtil,
                transactionFactory);

            IRpt_IndentedCostedBillofMaterial _Rpt_IndentedCostedBillofMaterial = new Rpt_IndentedCostedBillofMaterial(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                iApplyDateOffset,
                scalarFunction,
                convertToUtil,
                variableUtil,
                iGetSiteDate,
                stringUtil,
                highString,
                lowString,
                iGetCode,
                sQLUtil,
                iRpt_IndentedCostedBillofMaterialCRUD,
                collectionLoadRequestFactory,
                appDB,
                recordStreamFactory,
                sortOrderFactory,
                queryLanguage,
                mgSessionVariableBasedCache,
                CachePageSize.XLarge,
                bunchedLoadCollection,
                defineProcessVariable,
                getVariable,
                bookmarkFactory,
                defineVariable
                );

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_IndentedCostedBillofMaterial = IDOMethodIntercept<IRpt_IndentedCostedBillofMaterial>.Create(_Rpt_IndentedCostedBillofMaterial, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_IndentedCostedBillofMaterialExt = timerfactory.Create<IRpt_IndentedCostedBillofMaterial>(_Rpt_IndentedCostedBillofMaterial);

            return iRpt_IndentedCostedBillofMaterialExt;
        }
    }
}
