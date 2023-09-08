//PROJECT NAME: Production
//CLASS NAME: PmfRptSelectSessFmFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.ProcessManufacturing
{
    public class PmfRptSelectSessFmFactory
    {
        public const string IDO = "PmfFormulasBase";
        public const string Method = "PmfRptSelectSessFm";

        public IPmfRptSelectSessFm Create(
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
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var iPmfRptSelectSessFmCRUD = new PmfRptSelectSessFmCRUD(appDB, collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                stringUtil);

            IPmfRptSelectSessFm _PmfRptSelectSessFm = new PmfRptSelectSessFm(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                sQLUtil,
                iPmfRptSelectSessFmCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _PmfRptSelectSessFm = IDOMethodIntercept<IPmfRptSelectSessFm>.Create(_PmfRptSelectSessFm, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPmfRptSelectSessFmExt = timerfactory.Create<IPmfRptSelectSessFm>(_PmfRptSelectSessFm);

            return iPmfRptSelectSessFmExt;
        }
    }
}
