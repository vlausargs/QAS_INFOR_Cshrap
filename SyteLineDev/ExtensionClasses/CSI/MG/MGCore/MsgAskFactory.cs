//PROJECT NAME: MG.MGCore
//CLASS NAME: MsgAskFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class MsgAskFactory : IMsgAskFactory
    {
        public IMsgAsk Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _MsgAsk = new MsgAsk(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMsgAskExt = timerfactory.Create<MG.MGCore.IMsgAsk>(_MsgAsk);

            return iMsgAskExt;
        }
    }
}
