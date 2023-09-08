//PROJECT NAME: Finance
//CLASS NAME: CCIGetLastTransInfoFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Material;

namespace CSI.Finance.CreditCard
{
    public class CCIGetLastTransInfoFactory
    {
        public const string IDO = "CCITrans";
        public const string Method = "CCIGetLastTransInfo";

        public ICCIGetLastTransInfo Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, false);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);

            ICCIGetLastTransInfo _CCIGetLastTransInfo = new CCIGetLastTransInfo(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                variableUtil,
                stringUtil,
                sQLUtil,
                iMsgApp);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CCIGetLastTransInfo = IDOMethodIntercept<ICCIGetLastTransInfo>.Create(_CCIGetLastTransInfo, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCCIGetLastTransInfoExt = timerfactory.Create<ICCIGetLastTransInfo>(_CCIGetLastTransInfo);

            return iCCIGetLastTransInfoExt;
        }
    }
}
