using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using CSI.Data.Metric;
using CSI.Data.SQL;
using CSI.ServiceClasses.CSIServiceClasses;
using Mongoose.IDO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public class CollectionDeleteFactory
    {
        public ICollectionDelete Create(IIDOExtensionClassContext context, ICommandProvider commandProvider, IQueryLanguage queryLanguage, IAppDbSchema appDbSchema, ITriggerManagement triggerManagement, IInterceptConfiguration interceptConfiguration)
        {
            ICollectionDelete sqlCollectionDelete = new SQLCollectionDelete(commandProvider, queryLanguage, appDbSchema, triggerManagement);
            var mgCollectionDelete = new MGCollectionDelete(context);
            sqlCollectionDelete = new SQLCollectionDeleteWithMGIntercept(mgCollectionDelete, sqlCollectionDelete, interceptConfiguration);

            sqlCollectionDelete = new TimerFactory().Create<ICollectionDelete>(sqlCollectionDelete);

            return sqlCollectionDelete;
        }
    }
}
