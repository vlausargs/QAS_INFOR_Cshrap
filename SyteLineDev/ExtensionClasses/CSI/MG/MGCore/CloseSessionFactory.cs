//PROJECT NAME: MG.MGCore
//CLASS NAME: CloseSessionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class CloseSessionFactory : ICloseSessionFactory
    {
        public ICloseSession Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _CloseSession = new CloseSession(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCloseSessionExt = timerfactory.Create<MG.MGCore.ICloseSession>(_CloseSession);

            return iCloseSessionExt;
        }
    }
}
