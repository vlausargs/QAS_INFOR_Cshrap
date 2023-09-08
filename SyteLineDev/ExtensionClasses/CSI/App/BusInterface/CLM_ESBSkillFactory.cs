//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSkillFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.BusInterface
{
    public class CLM_ESBSkillFactory
    {
        public const string IDO = "ESBSkillViews";
        public const string Method = "CLM_ESBSkill";

        public ICLM_ESBSkill Create(
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
            var iCLM_ESBSkillCRUD = new CLM_ESBSkillCRUD(appDB, collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                stringUtil);

            ICLM_ESBSkill _CLM_ESBSkill = new CLM_ESBSkill(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                sQLUtil,
                iCLM_ESBSkillCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_ESBSkill = IDOMethodIntercept<ICLM_ESBSkill>.Create(_CLM_ESBSkill, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ESBSkillExt = timerfactory.Create<ICLM_ESBSkill>(_CLM_ESBSkill);

            return iCLM_ESBSkillExt;
        }
    }
}
