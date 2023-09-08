//PROJECT NAME: Finance
//CLASS NAME: ChartAcctDeleteFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Finance
{
    public class ChartAcctDeleteFactory
    {
        public const string IDO = "SLCharts";
        public const string Method = "ChartAcctDelete";

        public IChartAcctDelete Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var iChartAcctDeleteCRUD = new ChartAcctDeleteCRUD(appDB, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker);
            IChartAcctDelete _ChartAcctDelete = new ChartAcctDelete(
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                stringUtil,
                sQLUtil,
                iMsgApp,
            iChartAcctDeleteCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _ChartAcctDelete = IDOMethodIntercept<IChartAcctDelete>.Create(_ChartAcctDelete, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iChartAcctDeleteExt = timerfactory.Create<IChartAcctDelete>(_ChartAcctDelete);

            return iChartAcctDeleteExt;
        }
    }
}
