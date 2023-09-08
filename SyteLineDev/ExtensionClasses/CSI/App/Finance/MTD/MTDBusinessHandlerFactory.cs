using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Serializer;

namespace CSI.Finance.MTD
{
    public class MTDBusinessHandlerFactory
    {
        public IMTDBusinessHandler Create(ICSIExtensionClassBase csiExtensionClassBase)
        {
            var parameterProvider = csiExtensionClassBase.ParameterProvider;
            // MTDBusinessHandlerCRUD
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(csiExtensionClassBase.AppDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var mtdBusinessHandlerCRUD = new MTDBusinessHandlerCRUD(csiExtensionClassBase.AppDB,
                collectionInsertRequestFactory, collectionUpdateRequestFactory, collectionLoadRequestFactory,
                collectionLoadBuilderRequestFactory, existsChecker, variableUtil);
            // IMTDAPIResponseDataProcessor
            var mtdAPIResponseDataProcessor = new MTDAPIResponseDataProcessorFactory().Create(mtdBusinessHandlerCRUD);
            // IMsgApp
            var iMsgApp = new MsgApp(csiExtensionClassBase.AppDB);
            // ISerializer
            var serializer = new SerializerFactory().Create(SerializerType.NewtonConvert);
            // IMTDVATAPIs
            var mtdVatApis = new MTDVATAPIsFactory().Create(iMsgApp);
            // IMTDOAuth
            var mtdOAuth = new MTDOAuthFactory().Create(iMsgApp);

            var mtdBusinessHandler =
                new MTDBusinessHandler(serializer, mtdVatApis, mtdOAuth, mtdBusinessHandlerCRUD, mtdAPIResponseDataProcessor, iMsgApp);

            var timerFactory = new CSI.Data.Metric.TimerFactory();
            return timerFactory.Create<IMTDBusinessHandler>(mtdBusinessHandler);
        }
    }
}