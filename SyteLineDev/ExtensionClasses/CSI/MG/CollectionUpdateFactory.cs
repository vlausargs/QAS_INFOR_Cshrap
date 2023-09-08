using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using CSI.Data.Metric;
using CSI.Data.SQL;
using CSI.ServiceClasses.CSIServiceClasses;
using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class CollectionUpdateFactory
    {
        public ICollectionUpdate Create(IIDOExtensionClassContext context, ICommandProvider commandProvider, IQueryLanguage queryLanguage, IAppDbSchema appDbSchema, ITriggerManagement triggerManagement, IInterceptConfiguration interceptConfiguration)
        {
            ICollectionUpdate sqlCollectionUpdate = new SQLCollectionUpdate(commandProvider, queryLanguage, appDbSchema, triggerManagement);
            var mgUpdateCollection = new MGCollectionUpdate(context);
            sqlCollectionUpdate = new SQLCollectionUpdateWithMGIntercept(mgUpdateCollection, sqlCollectionUpdate, interceptConfiguration);

            sqlCollectionUpdate = new TimerFactory().Create<ICollectionUpdate>(sqlCollectionUpdate);

            return sqlCollectionUpdate;
        }
    }
}
