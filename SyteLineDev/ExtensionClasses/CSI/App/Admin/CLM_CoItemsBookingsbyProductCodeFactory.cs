//PROJECT NAME: Admin
//CLASS NAME: CLM_CoItemsBookingsbyProductCodeFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using System.Linq;

namespace CSI.Admin
{
    public class CLM_CoItemsBookingsbyProductCodeFactory
    {
        public const string IDO = "MobileHomepages";
        public const string Method = "CLM_CoItemsBookingsbyProductCode";

        public ICLM_CoItemsBookingsbyProductCode Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iDefaultToLocalSite = cSIExtensionClassBase.MongooseDependencies.DefaultToLocalSite;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var iInterpretText = cSIExtensionClassBase.MongooseDependencies.InterpretText;
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
            var stringUtil = new StringUtil();
            var iLowDate = cSIExtensionClassBase.MongooseDependencies.LowDate;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            ICLM_CoItemsBookingsbyProductCode _CLM_CoItemsBookingsbyProductCode = new CLM_CoItemsBookingsbyProductCode(appDB,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iDefaultToLocalSite,
                scalarFunction,
                iInterpretText,
                existsChecker,
                convertToUtil,
                dateTimeUtil,
                variableUtil,
                iMidnightOf,
                stringUtil,
                iLowDate,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_CoItemsBookingsbyProductCode = IDOMethodIntercept<ICLM_CoItemsBookingsbyProductCode>.Create(_CLM_CoItemsBookingsbyProductCode, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_CoItemsBookingsbyProductCodeExt = timerfactory.Create<ICLM_CoItemsBookingsbyProductCode>(_CLM_CoItemsBookingsbyProductCode);

            return iCLM_CoItemsBookingsbyProductCodeExt;
        }
    }
}
