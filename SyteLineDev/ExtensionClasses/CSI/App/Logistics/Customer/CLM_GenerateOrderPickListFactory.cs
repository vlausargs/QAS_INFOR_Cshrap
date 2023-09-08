//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateOrderPickListFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Material;
using CSI.MG.MGCore;

namespace CSI.Logistics.Customer
{
    public class CLM_GenerateOrderPickListFactory
    {
        public const string IDO = "SLCos";
        public const string Method = "CLM_GenerateOrderPickList";

        private IExpandKyByTypeFactory ExpandKyByTypeFactory;
        private IDayEndOfFactory DayEndOfFactory;
        private IHighDateFactory HighDateFactory;
        private ILowDateFactory LowDateFactory;
        private IHighIntFactory HighIntFactory;
        private ILowIntFactory LowIntFactory;

        public CLM_GenerateOrderPickListFactory(IExpandKyByTypeFactory ExpandKyByTypeFactory, IDayEndOfFactory DayEndOfFactory,
            IHighDateFactory HighDateFactory, ILowDateFactory LowDateFactory, IHighIntFactory HighIntFactory, ILowIntFactory LowIntFactory)
        {
            this.ExpandKyByTypeFactory = ExpandKyByTypeFactory;
            this.DayEndOfFactory = DayEndOfFactory;
            this.HighDateFactory = HighDateFactory;
            this.LowDateFactory = LowDateFactory;
            this.HighIntFactory = HighIntFactory;
            this.LowIntFactory = LowIntFactory;
        }

        public ICLM_GenerateOrderPickList Create(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO, ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iExpandKyByType = ExpandKyByTypeFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iDayEndOf = DayEndOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iHighDate = HighDateFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iLowDate = LowDateFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iHighInt = HighIntFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iLowInt = LowIntFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iMsgApp = new MsgApp(appDB);

            ICLM_GenerateOrderPickList _CLM_GenerateOrderPickList = new CLM_GenerateOrderPickList(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                stringUtil,
                iDayEndOf,
                iHighDate,
                iLowDate,
                iHighInt,
                sQLUtil,
                iLowInt,
                iMsgApp,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString
                );

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_GenerateOrderPickList = IDOMethodIntercept<ICLM_GenerateOrderPickList>.Create(_CLM_GenerateOrderPickList, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_GenerateOrderPickListExt = timerfactory.Create<ICLM_GenerateOrderPickList>(_CLM_GenerateOrderPickList);

            return iCLM_GenerateOrderPickListExt;
        }
    }
}
