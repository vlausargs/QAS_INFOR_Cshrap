using CSI.Data.CRUD;
using CSI.Data.CRUD.Triggers;
using CSI.Data.Metric;
using CSI.Data.RecordSets;
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
    public class CollectionLoadFactory
    {
        public ICollectionLoad Create(IIDOExtensionClassContext context, ICommandProvider commandProvider, IQueryLanguage queryLanguage, IAppDbSchema appDbSchema, ITriggerManagement triggerManagement, IInterceptConfiguration interceptConfiguration)
        {
            var loadRequestVariablesUpdate = new LoadRequestVariablesUpdate();
            var sqlCollectionLoadProcess = new SQLCollectionLoadProcess(commandProvider, loadRequestVariablesUpdate);
            var mgCollectionLoader = new MGCollectionLoad(context, loadRequestVariablesUpdate);

            ICollectionLoad sqlCollectionLoad = new SQLCollectionLoadNonArbitrary(queryLanguage, triggerManagement, sqlCollectionLoadProcess);

            sqlCollectionLoad = new SQLCollectionLoadWithMGIntercept(mgCollectionLoader, sqlCollectionLoad, interceptConfiguration);

            sqlCollectionLoad = new TimerFactory().Create<ICollectionLoad>(sqlCollectionLoad);

            return sqlCollectionLoad;
        }
    }
}
