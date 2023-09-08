//PROJECT NAME: Material
//CLASS NAME: CLM_ExpiringLotsSerialsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Material
{
    public class CLM_ExpiringLotsSerialsFactory
    {
        public const string IDO = "SLSerialAlls";
        public const string Method = "CLM_ExpiringLotsSerials";

        public ICLM_ExpiringLotsSerials Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var raiseError = new RaiseErrorFactory().Create(appDB);
            var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            string orderBy = $"ExpDate, Item, Type";
            var unionUtil = new UnionUtil(UnionType.UnionAll, orderBy);

            ICLM_ExpiringLotsSerials _CLM_ExpiringLotsSerials = new CLM_ExpiringLotsSerials(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iExecuteDynamicSQL,
                scalarFunction,
                existsChecker,
                convertToUtil,
                iGetSiteDate,
                variableUtil,
                stringUtil,
                raiseError,
                iDayEndOf,
                sQLUtil,
                unionUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_ExpiringLotsSerials = IDOMethodIntercept<ICLM_ExpiringLotsSerials>.Create(_CLM_ExpiringLotsSerials, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ExpiringLotsSerialsExt = timerfactory.Create<ICLM_ExpiringLotsSerials>(_CLM_ExpiringLotsSerials);

            return iCLM_ExpiringLotsSerialsExt;
        }
    }
}
