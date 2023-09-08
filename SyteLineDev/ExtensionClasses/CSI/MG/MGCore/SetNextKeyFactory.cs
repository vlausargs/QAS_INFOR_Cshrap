//PROJECT NAME: MG.MGCore
//CLASS NAME: SetNextKeyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class SetNextKeyFactory : ISetNextKeyFactory
    {
        public ISetNextKey Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _SetNextKey = new SetNextKey(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSetNextKeyExt = timerfactory.Create<MG.MGCore.ISetNextKey>(_SetNextKey);

            return iSetNextKeyExt;
        }
    }
}
