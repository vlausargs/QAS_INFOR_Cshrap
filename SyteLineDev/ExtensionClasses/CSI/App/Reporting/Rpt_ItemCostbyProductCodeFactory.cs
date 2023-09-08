//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemCostbyProductCodeFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using System.Collections.Generic;

namespace CSI.Reporting
{
    public class Rpt_ItemCostbyProductCodeFactory
    {
        public const string IDO = "SLItemCostByProductCodeReport";
        public const string Method = "Rpt_ItemCostbyProductCode";

        private readonly ICloseSessionContextFactory closeSessionContextFactory;
        private IInitSessionContextFactory initSessionContextFactory;
        private readonly IGetIsolationLevelFactory getIsolationLevelFactory;
        private readonly IGetSiteDateFactory getSiteDateFactory;

        public Rpt_ItemCostbyProductCodeFactory(
            ICloseSessionContextFactory closeSessionContextFactory,
            IInitSessionContextFactory initSessionContextFactory,
            IGetIsolationLevelFactory getIsolationLevelFactory,
            IGetSiteDateFactory getSiteDateFactory
            )
        {
            this.closeSessionContextFactory = closeSessionContextFactory;
            this.initSessionContextFactory = initSessionContextFactory;
            this.getIsolationLevelFactory = getIsolationLevelFactory;
            this.getSiteDateFactory = getSiteDateFactory;
        }

        public IRpt_ItemCostbyProductCode Create(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO, ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iCloseSessionContext = this.closeSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iInitSessionContext = this.initSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = this.getIsolationLevelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var iGetSiteDate = this.getSiteDateFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IRpt_ItemCostbyProductCode _Rpt_ItemCostbyProductCode = new Rpt_ItemCostbyProductCode(appDB,
                bunchedLoadCollection,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iCloseSessionContext,
                iInitSessionContext,
                transactionFactory,
                iGetIsolationLevel,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                scalarFunction,
                existsChecker,
                convertToUtil,
                iGetSiteDate,
                variableUtil,
                stringUtil,
                sQLUtil,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_ItemCostbyProductCode = IDOMethodIntercept<IRpt_ItemCostbyProductCode>.Create(_Rpt_ItemCostbyProductCode, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_ItemCostbyProductCodeExt = timerfactory.Create<IRpt_ItemCostbyProductCode>(_Rpt_ItemCostbyProductCode);

            return iRpt_ItemCostbyProductCodeExt;

        }
                
    }
}
