//PROJECT NAME: Production
//CLASS NAME: ValidateExpRecDemandFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;
using CSI.Material;

namespace CSI.Production.APS
{
    public class ValidateExpRecDemandFactory
    {
        public const string IDO = "SLExpectedReceipts";
        public const string Method = "ValidateExpRecDemand";

        public ValidateExpRecDemandFactory(IExpandKyByTypeFactory expandKyByTypeFactory)
        {
            this.expandKyByTypeFactory = expandKyByTypeFactory;
        }

        private IExpandKyByTypeFactory expandKyByTypeFactory;

        public IValidateExpRecDemand Create(IApplicationDB appDB,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var iExpandKyByType = this.expandKyByTypeFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);

            IValidateExpRecDemand _ValidateExpRecDemand = new ValidateExpRecDemand(appDB,
                collectionLoadRequestFactory,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                variableUtil,
                sQLUtil,
                iMsgApp);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _ValidateExpRecDemand = IDOMethodIntercept<IValidateExpRecDemand>.Create(_ValidateExpRecDemand, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateExpRecDemandExt = timerfactory.Create<IValidateExpRecDemand>(_ValidateExpRecDemand);

            return iValidateExpRecDemandExt;
        }
    }
}
