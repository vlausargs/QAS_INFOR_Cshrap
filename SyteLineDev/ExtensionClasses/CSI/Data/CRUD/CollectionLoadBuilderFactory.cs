using CSI.Data.Metric;
using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CRUD
{
    public class CollectionLoadBuilderFactory
    {
        public ICollectionLoadBuilder Create()
        {
            var loadRequestVariablesUpdate = new LoadRequestVariablesUpdate();
            var sqlCollectionLoadBuildProcess = new SQLCollectionLoadBuilderProcess(loadRequestVariablesUpdate);

            ICollectionLoadBuilder sqlCollectionLoad = new SQLCollectionLoadBuilder(sqlCollectionLoadBuildProcess);

            sqlCollectionLoad = new TimerFactory().Create<ICollectionLoadBuilder>(sqlCollectionLoad);

            return sqlCollectionLoad;
        }
    }
}
