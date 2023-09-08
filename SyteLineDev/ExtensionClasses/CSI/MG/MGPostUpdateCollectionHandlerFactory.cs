using CSI.Data.Cache;
using CSI.Data.CRUD.Triggers;
using CSI.Data.SQL;
using CSI.ServiceClasses.CSIServiceClasses;
using Mongoose.IDO;
using Mongoose.IDO.DataAccess;
using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGPostUpdateCollectionHandlerFactory
    {
        public MGPostUpdateCollectionHandler Create(IIDOExtensionClassContext context, AppDB mgAppDb)
        {
            var commandProvider = new MGCommandProvider(mgAppDb);
            var parameterProvider = new SQLParameterProvider();
            var tablePrimaryKeyCache = new SQLTablePrimaryKeyCache();
            var tableSchemaCache = new SQLTableSchemaCache();
            var parameterizedCommandFactory = new SQLParameterizedCommandFactory();
            var appDbSchema = new SQLDbSchema(commandProvider, parameterProvider, tablePrimaryKeyCache, tableSchemaCache, parameterizedCommandFactory);

            var triggerManagement = new TriggerManagement(appDbSchema, parameterizedCommandFactory);

            var idoMetaData = new MGIdoMetaData();

            return new MGPostUpdateCollectionHandler(
                context,
                triggerManagement,
                idoMetaData);
        }
    }
}
