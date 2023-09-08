//PROJECT NAME: Employee
//CLASS NAME: AlertPORequisitionFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;

namespace CSI.Employee
{
    public class AlertPORequisitionFactory
    {
        public const string IDO = "SLEmpSelfServPreqitems";
        public const string Method = "AlertPORequisition";

        public IAlertPORequisition Create(
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
            var iInsertEventInputParameter = cSIExtensionClassBase.MongooseDependencies.InsertEventInputParameter;
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, true);
            var iResetSessionID = cSIExtensionClassBase.MongooseDependencies.ResetSessionID;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var iInterpretText = cSIExtensionClassBase.MongooseDependencies.InterpretText;
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iSessionID = cSIExtensionClassBase.MongooseDependencies.SessionID;
            var iFireEvent = cSIExtensionClassBase.MongooseDependencies.FireEvent;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IAlertPORequisition _AlertPORequisition = new AlertPORequisition(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                iInsertEventInputParameter,
                sQLExpressionExecutor,
                iExpandKyByType,
                iResetSessionID,
                scalarFunction,
                iInterpretText,
                existsChecker,
                convertToUtil,
                variableUtil,
                stringUtil,
                iSessionID,
                iFireEvent,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _AlertPORequisition = IDOMethodIntercept<IAlertPORequisition>.Create(_AlertPORequisition, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAlertPORequisitionExt = timerfactory.Create<IAlertPORequisition>(_AlertPORequisition);

            return iAlertPORequisitionExt;
        }
    }
}
