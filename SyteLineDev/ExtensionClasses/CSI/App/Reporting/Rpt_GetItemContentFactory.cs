//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GetItemContentFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;

namespace CSI.Reporting
{
    public class Rpt_GetItemContentFactory
    {
        public const string IDO = "SLGetItemContentReport";
        public const string Method = "Rpt_GetItemContent";

        private readonly ICloseSessionContextFactory iCloseSessionContextFactory;
        private readonly IInitSessionContextFactory iInitSessionContextFactory;

        public Rpt_GetItemContentFactory(ICloseSessionContextFactory iCloseSessionContextFactory,
            IInitSessionContextFactory iInitSessionContextFactory)
        {
            this.iCloseSessionContextFactory = iCloseSessionContextFactory;
            this.iInitSessionContextFactory = iInitSessionContextFactory;
        }

        public IRpt_GetItemContent Create(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO, ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iCloseSessionContext = this.iCloseSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iInitSessionContext = this.iInitSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iGetItemContent = new GetItemContentFactory().Create(appDB, bunchedLoadCollection, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IRpt_GetItemContent _Rpt_GetItemContent = new Rpt_GetItemContent(appDB,
                bunchedLoadCollection,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iCloseSessionContext,
                iInitSessionContext,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                iExpandKyByType,
                iGetItemContent,
                scalarFunction,
                existsChecker,
                variableUtil,
                stringUtil,
                sQLUtil,
                cSIExtensionClassBase.MongooseDependencies.LowString);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_GetItemContent = IDOMethodIntercept<IRpt_GetItemContent>.Create(_Rpt_GetItemContent, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_GetItemContentExt = timerfactory.Create<IRpt_GetItemContent>(_Rpt_GetItemContent);

            return iRpt_GetItemContentExt;
        }
    }
}
