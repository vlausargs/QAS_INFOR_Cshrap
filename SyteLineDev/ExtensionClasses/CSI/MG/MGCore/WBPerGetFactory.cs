//PROJECT NAME: MG.MGCore
//CLASS NAME: WBPerGetFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class WBPerGetFactory : IWBPerGetFactory
    {
        public IWBPerGet Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _WBPerGet = new WBPerGet(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWBPerGetExt = timerfactory.Create<MG.MGCore.IWBPerGet>(_WBPerGet);

            return iWBPerGetExt;
        }
    }
}
