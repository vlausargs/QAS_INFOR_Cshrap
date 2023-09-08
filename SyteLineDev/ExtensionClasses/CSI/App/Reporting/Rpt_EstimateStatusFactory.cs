//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateStatusFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.Logistics.Vendor;
using CSI.DataCollection;

namespace CSI.Reporting
{
    public class Rpt_EstimateStatusFactory
    {
        public const string IDO = "SLEstimateStatusReport";
        public const string Method = "Rpt_EstimateStatus";

        private IInitSessionContextWithUserFactory initSessionContextWithUserFactory;
        private ICopySessionVariablesFactory copySessionVariablesFactory;
        private ICloseSessionContextFactory closeSessionContextFactory;
        private IGetIsolationLevelFactory getIsolationLevelFactory;
        private IApplyDateOffsetFactory applyDateOffsetFactory;
        private IGetLabelFactory getLabelFactory;

        public Rpt_EstimateStatusFactory(
            IInitSessionContextWithUserFactory initSessionContextWithUserFactory,
            ICopySessionVariablesFactory copySessionVariablesFactory,
            ICloseSessionContextFactory closeSessionContextFactory,
            IGetIsolationLevelFactory getIsolationLevelFactory,
            IApplyDateOffsetFactory applyDateOffsetFactory,
            IGetLabelFactory getLabelFactory)
        {
            this.initSessionContextWithUserFactory = initSessionContextWithUserFactory;
            this.copySessionVariablesFactory = copySessionVariablesFactory;
            this.closeSessionContextFactory = closeSessionContextFactory;
            this.getIsolationLevelFactory = getIsolationLevelFactory;
            this.applyDateOffsetFactory = applyDateOffsetFactory;
            this.getLabelFactory = getLabelFactory;
        }

        public IRpt_EstimateStatus Create(ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var iInitSessionContextWithUser = this.initSessionContextWithUserFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iCopySessionVariables = this.copySessionVariablesFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iCloseSessionContext = this.closeSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = this.getIsolationLevelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iApplyDateOffset = this.applyDateOffsetFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iUomConvAmt = new UomConvAmtFactory().Create(cSIExtensionClassBase);
            var stringUtil = new StringUtil();
            var iGetLabel = this.getLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iCurrCnvt = new CurrCnvtFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var mathUtil = new MathUtilFactory().Create();
            var iGetumcf = new GetumcfFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iRefFmt = new RefFmtFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);

            IRpt_EstimateStatus _Rpt_EstimateStatus = new Rpt_EstimateStatus(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                iInitSessionContextWithUser,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iCopySessionVariables,
                iCloseSessionContext,
                transactionFactory,
                iGetIsolationLevel,
                iApplyDateOffset,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                iUomConvAmt,
                stringUtil,
                iGetLabel,
                iCurrCnvt,
                mathUtil,
                iGetumcf,
                sQLUtil,
                iRefFmt,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_EstimateStatus = IDOMethodIntercept<IRpt_EstimateStatus>.Create(_Rpt_EstimateStatus, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_EstimateStatusExt = timerfactory.Create<IRpt_EstimateStatus>(_Rpt_EstimateStatus);

            return iRpt_EstimateStatusExt;
        }
    }
}
