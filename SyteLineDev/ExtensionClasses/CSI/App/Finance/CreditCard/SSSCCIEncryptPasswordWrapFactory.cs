//PROJECT NAME: Finance
//CLASS NAME: SSSCCIEncryptPasswordWrapFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;
using CSI.Data.CreditCard;

namespace CSI.Finance.CreditCard
{
    public class SSSCCIEncryptPasswordWrapFactory
    {
        public const string IDO = "CCIParms";
        public const string Method = "SSSCCIEncryptPasswordWrap";

        public ISSSCCIEncryptPasswordWrap Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var iCreditCardUtil = new CreditCardUtilFactory().Create(appDB);
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var existsChecker = new ExistsChecker(appDB, collectionLoadRequestFactory, collectionLoadStatementRequestFactory);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            ISSSCCIEncryptPasswordWrap _SSSCCIEncryptPasswordWrap = new SSSCCIEncryptPasswordWrap(appDB,
            collectionInsertRequestFactory,
            collectionDeleteRequestFactory,
            collectionLoadRequestFactory,
            iCreditCardUtil,
            sQLExpressionExecutor,
            scalarFunction,
            existsChecker,
            sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _SSSCCIEncryptPasswordWrap = IDOMethodIntercept<ISSSCCIEncryptPasswordWrap>.Create(_SSSCCIEncryptPasswordWrap, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSCCIEncryptPasswordWrapExt = timerfactory.Create<ISSSCCIEncryptPasswordWrap>(_SSSCCIEncryptPasswordWrap);

            return iSSSCCIEncryptPasswordWrapExt;
        }
    }
}

