using CSI.Data.CRUD.Triggers;
using CSI.Data.Metric;
using CSI.Data.RecordSets;
using CSI.Data.SQL;

namespace CSI.Data.CRUD
{
    public class CollectionLoadStatementFactory
    {
        public ICollectionLoadStatement Create(ICommandProvider commandProvider, IQueryLanguage queryLanguage, ITriggerManagement triggerManagement)
        {
            var loadRequestVariablesUpdate = new LoadRequestVariablesUpdate();
            var sqlCollectionLoadProcess = new SQLCollectionLoadProcess(commandProvider, loadRequestVariablesUpdate);

            ICollectionLoadStatement sqlCollectionLoad = new SQLCollectionLoadArbitrary(queryLanguage,sqlCollectionLoadProcess, triggerManagement);
            
            sqlCollectionLoad = new TimerFactory().Create<ICollectionLoadStatement>(sqlCollectionLoad);

            return sqlCollectionLoad;
        }
    }
}
