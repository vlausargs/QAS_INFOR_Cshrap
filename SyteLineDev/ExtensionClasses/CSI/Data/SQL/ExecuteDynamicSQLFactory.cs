//PROJECT NAME: MG.MGCore
//CLASS NAME: ExecuteDynamicSQLFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class ExecuteDynamicSQLFactory : IExecuteDynamicSQLFactory
    {
        public IExecuteDynamicSQL Create(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _ExecuteDynamicSQL = new ExecuteDynamicSQL(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iExecuteDynamicSQLExt = timerfactory.Create<MG.MGCore.IExecuteDynamicSQL>(_ExecuteDynamicSQL);

            return iExecuteDynamicSQLExt;
        }
    }
}
