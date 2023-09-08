//PROJECT NAME: Production
//CLASS NAME: PmfRptSelectSessPnsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.ProcessManufacturing
{
    public class PmfRptSelectSessPnsFactory
    {
        public const string IDO = "PmfTmpRptPnsBase";
        public const string Method = "PmfRptSelectSessPns";

        public IPmfRptSelectSessPns Create(
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
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var iPmfRptSelectSessPnsCRUD = new PmfRptSelectSessPnsCRUD(appDB, collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                stringUtil);

            IPmfRptSelectSessPns _PmfRptSelectSessPns = new PmfRptSelectSessPns(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                sQLUtil,
                iPmfRptSelectSessPnsCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _PmfRptSelectSessPns = IDOMethodIntercept<IPmfRptSelectSessPns>.Create(_PmfRptSelectSessPns, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPmfRptSelectSessPnsExt = timerfactory.Create<IPmfRptSelectSessPns>(_PmfRptSelectSessPns);

            return iPmfRptSelectSessPnsExt;
        }
    }
}
