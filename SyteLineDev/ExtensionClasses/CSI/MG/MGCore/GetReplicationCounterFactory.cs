//PROJECT NAME: MG.MGCore
//CLASS NAME: GetReplicationCounterFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class GetReplicationCounterFactory : IGetReplicationCounterFactory
    {
        public IGetReplicationCounter Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetReplicationCounter = new GetReplicationCounter(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetReplicationCounterExt = timerfactory.Create<MG.MGCore.IGetReplicationCounter>(_GetReplicationCounter);

            return iGetReplicationCounterExt;
        }
    }
}
