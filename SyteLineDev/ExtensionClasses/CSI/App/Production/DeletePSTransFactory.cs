//PROJECT NAME: Production
//CLASS NAME: DeletePSTransFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Production
{
    public class DeletePSTransFactory
    {
        public const string IDO = "SLJobTrans";
        public const string Method = "DeletePSTrans";

        public IDeletePSTrans Create(
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
            var iUndefineVariableBySessionId = cSIExtensionClassBase.MongooseDependencies.UndefineVariableBySessionId;
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var iDefinedValueBySessionId = cSIExtensionClassBase.MongooseDependencies.DefinedValueBySessionId;
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var convertToUtil = new ConvertToUtilFactory().Create();

            IDeletePSTrans _DeletePSTrans = new DeletePSTrans(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                iUndefineVariableBySessionId,
                collectionLoadResponseUtil,
                iDefinedValueBySessionId,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                variableUtil,
                stringUtil,
                sQLUtil,
                convertToUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _DeletePSTrans = IDOMethodIntercept<IDeletePSTrans>.Create(_DeletePSTrans, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDeletePSTransExt = timerfactory.Create<IDeletePSTrans>(_DeletePSTrans);

            return iDeletePSTransExt;
        }
    }
}
