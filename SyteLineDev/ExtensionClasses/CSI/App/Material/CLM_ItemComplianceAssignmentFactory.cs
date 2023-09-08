//PROJECT NAME: Material
//CLASS NAME: CLM_ItemComplianceAssignmentFactory.cs

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
    public class CLM_ItemComplianceAssignmentFactory
    {
        public const string IDO = "SLItemCompliances";
        public const string Method = "CLM_ItemComplianceAssignment";

        public ICLM_ItemComplianceAssignment Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var iSetItemComplianceStatus = new SetItemComplianceStatusFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iDefineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var raiseError = new RaiseErrorFactory().Create(appDB);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var iCLM_ItemComplianceAssignmentCRUD = new CLM_ItemComplianceAssignmentCRUD(appDB, collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                stringUtil);

            ICLM_ItemComplianceAssignment _CLM_ItemComplianceAssignment = new CLM_ItemComplianceAssignment(collectionLoadResponseUtil,
                iSetItemComplianceStatus,
                sQLExpressionExecutor,
                iDefineVariable,
                scalarFunction,
                raiseError,
                sQLUtil,
                iCLM_ItemComplianceAssignmentCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_ItemComplianceAssignment = IDOMethodIntercept<ICLM_ItemComplianceAssignment>.Create(_CLM_ItemComplianceAssignment, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ItemComplianceAssignmentExt = timerfactory.Create<ICLM_ItemComplianceAssignment>(_CLM_ItemComplianceAssignment);

            return iCLM_ItemComplianceAssignmentExt;
        }
    }
}
