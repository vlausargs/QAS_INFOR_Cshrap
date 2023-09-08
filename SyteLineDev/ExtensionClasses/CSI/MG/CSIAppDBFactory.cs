using CSI.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using CSI.Data.SQL;
using CSI.ServiceClasses.CSIServiceClasses;
using Mongoose.IDO;
using Mongoose.IDO.DataAccess;
using Mongoose.IDO.Protocol;

namespace CSI.MG
{
    public class CSIAppDBFactory
    {
        public IApplicationDB CreateAppDB(AppDB mgAppDb, IIDOExtensionClassContext context, Mongoose.IDO.IMessageProvider mgMessageProvider)
        {
            var commandParameters = new MGCommandParameters(mgAppDb);
            var commandExecutor = new MGCommandExecutor(mgAppDb, commandParameters);
            var interceptConfiguration = new InterceptConfiguration();
            var commandProvider = new MGCommandProvider(mgAppDb);
            var parameterProvider = new SQLParameterProvider();
            var messageProvider = new MGMessageProvider(mgMessageProvider);
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var literalProvider = new MGLiteralProvider();

            var tablePrimaryKeyCache = new SQLTablePrimaryKeyCache();
            var tableSchemaCache = new SQLTableSchemaCache();
            var parameterizedCommandFactory = new SQLParameterizedCommandFactory();
            var appDbSchema = new SQLDbSchema(commandProvider, parameterProvider, tablePrimaryKeyCache, tableSchemaCache, parameterizedCommandFactory);

            var triggerManagement = new TriggerManagement(appDbSchema, parameterizedCommandFactory);

            var sqlCollectionLoad = new CollectionLoadFactory().Create(context, commandProvider, queryLanguage, appDbSchema, triggerManagement, interceptConfiguration);
            var sqlCollectionInsert = new CollectionInsertFactory().Create(context, commandProvider, queryLanguage, appDbSchema, triggerManagement, interceptConfiguration);
            var sqlCollectionUpdate = new CollectionUpdateFactory().Create(context, commandProvider, queryLanguage, appDbSchema, triggerManagement, interceptConfiguration);
            var sqlCollectionDelete = new CollectionDeleteFactory().Create(context, commandProvider, queryLanguage, appDbSchema, triggerManagement, interceptConfiguration);

            var sqlCollectionLoadStatement = new CollectionLoadStatementFactory().Create(commandProvider, queryLanguage, triggerManagement);
            var sqlCollectionLoadBuild = new CollectionLoadBuilderFactory().Create();

            var sqlCollectionNonTriggerUpdate = new CollectionNonTriggerUpdateFactory().Create(queryLanguage, commandProvider);
            var sqlCollectionNonTriggerDelete = new CollectionNonTriggerDeleteFactory().Create(queryLanguage, commandProvider);
            var sqlCollectionNonTriggerInsert = new CollectionNonTriggerInsertFactory().Create(queryLanguage, commandProvider);

            return new CSIAppDB(
                commandExecutor,
                messageProvider,
                sqlCollectionLoad,
                sqlCollectionLoadBuild,
                sqlCollectionLoadStatement,
                sqlCollectionInsert,
                sqlCollectionUpdate,
                sqlCollectionDelete,
                commandProvider,
                commandParameters,
                literalProvider,
                parameterProvider,
                sqlCollectionNonTriggerUpdate,
                sqlCollectionNonTriggerDelete,
                sqlCollectionNonTriggerInsert);
        }

        public IBunchedLoadCollection CreateLoadCollectionDatabase(AppDB idoExt, LoadCollectionDataBase request)
        {
            IProcessVariableProvider mgProcessVariableProvider = new ProcessVariableProvider(idoExt);
            IMGBunchedRequest mgBunchedRequest = new MGBunchedRequest(request);
            return new SQLBunchedLoadCollection(mgProcessVariableProvider, mgBunchedRequest);
        }
    }
}
