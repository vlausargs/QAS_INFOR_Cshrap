//PROJECT NAME: Logistics
//CLASS NAME: GenerateVATFileFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Logistics.Customer
{
    public class GenerateVATFileFactory
    {
        public const string IDO = "SLArinvs";
        public const string Method = "GenerateVATFile";

        public IGenerateVATFile Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iFormatAddressForCP = new FormatAddressForCPFactory().Create(cSIExtensionClassBase);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iStringOfLanguage = new StringOfLanguageFactory().Create(cSIExtensionClassBase);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
            var iSplitString = cSIExtensionClassBase.MongooseDependencies.SplitString;
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var raiseError = new RaiseErrorFactory().Create(appDB);
            var iUserName = cSIExtensionClassBase.MongooseDependencies.UserName2;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);

            IGenerateVATFile _GenerateVATFile = new GenerateVATFile(appDB,
                collectionLoadStatementRequestFactory,
                collectionLoadBuilderRequestFactory,
                dataTableToCollectionLoadResponse,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iFormatAddressForCP,
                transactionFactory,
                iStringOfLanguage,
                scalarFunction,
                existsChecker,
                convertToUtil,
                dataTableUtil,
                iSplitString,
                dateTimeUtil,
                variableUtil,
                stringUtil,
                raiseError,
                iUserName,
                sQLUtil,
                iMsgApp);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _GenerateVATFile = IDOMethodIntercept<IGenerateVATFile>.Create(_GenerateVATFile, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGenerateVATFileExt = timerfactory.Create<IGenerateVATFile>(_GenerateVATFile);

            return iGenerateVATFileExt;
        }
    }
}