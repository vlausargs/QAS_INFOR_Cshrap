//PROJECT NAME: Finance
//CLASS NAME: CLM_BankReconChangeFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Finance
{
    public class CLM_BankReconChangeFactory
    {
        public const string IDO = "SLGlbanks";
        public const string Method = "CLM_BankReconChange";

        public ICLM_BankReconChange Create(
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
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
            var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
            var iHighDate = cSIExtensionClassBase.MongooseDependencies.HighDate;
            var iLowDate = cSIExtensionClassBase.MongooseDependencies.LowDate;
            var iHighInt = cSIExtensionClassBase.MongooseDependencies.HighInt;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iLowInt = cSIExtensionClassBase.MongooseDependencies.LowInt;
            var iCstr = cSIExtensionClassBase.MongooseDependencies.Cstr;

            ICLM_BankReconChange _CLM_BankReconChange = new CLM_BankReconChange(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                transactionFactory,
                iExecuteDynamicSQL,
                sQLCollectionLoad,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                stringUtil,
                iDayEndOf,
                iHighDate,
                iLowDate,
                iHighInt,
                sQLUtil,
                iLowInt,
                iCstr);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_BankReconChange = IDOMethodIntercept<ICLM_BankReconChange>.Create(_CLM_BankReconChange, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_BankReconChangeExt = timerfactory.Create<ICLM_BankReconChange>(_CLM_BankReconChange);

            return iCLM_BankReconChangeExt;
        }
    }
}
