//PROJECT NAME: MG.MGCore
//CLASS NAME: MsgPreFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class MsgPreFactory : IMsgPreFactory
    {
        public IMsgPre Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _MsgPre = new MsgPre(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMsgPreExt = timerfactory.Create<MG.MGCore.IMsgPre>(_MsgPre);

            return iMsgPreExt;
        }
    }
}
