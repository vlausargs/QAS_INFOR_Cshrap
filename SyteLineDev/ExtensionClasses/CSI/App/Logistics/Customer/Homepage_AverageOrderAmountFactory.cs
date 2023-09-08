//PROJECT NAME: Logistics
//CLASS NAME: Homepage_AverageOrderAmountFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Finance;

namespace CSI.Logistics.Customer
{
    public class Homepage_AverageOrderAmountFactory
    {
        public const string IDO = "SLHomepages";
        public const string Method = "Homepage_AverageOrderAmount";

        public IHomepage_AverageOrderAmount Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
            var stringUtil = new StringUtil();
            var iGetLabel = cSIExtensionClassBase.MongooseDependencies.GetLabel;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var mathUtil = new MathUtilFactory().Create();
            var currCnvtSingleAmt2 = new CurrCnvtSingleAmt2Factory().Create(cSIExtensionClassBase, calledFromIDO);

            IHomepage_AverageOrderAmount _Homepage_AverageOrderAmount = new Homepage_AverageOrderAmount(appDB,
                bunchedLoadCollection,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadBuilderRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                transactionFactory,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                iMidnightOf,
                stringUtil,
                iGetLabel,
                sQLUtil,
                mathUtil,
                currCnvtSingleAmt2);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Homepage_AverageOrderAmount = IDOMethodIntercept<IHomepage_AverageOrderAmount>.Create(_Homepage_AverageOrderAmount, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_AverageOrderAmountExt = timerfactory.Create<IHomepage_AverageOrderAmount>(_Homepage_AverageOrderAmount);

            return iHomepage_AverageOrderAmountExt;
        }
    }
}
