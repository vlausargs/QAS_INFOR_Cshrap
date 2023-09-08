//PROJECT NAME: MG.MGCore
//CLASS NAME: CloseSessionContextFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class CloseSessionContextFactory : ICloseSessionContextFactory
    {
        public ICloseSessionContext Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _CloseSessionContext = new CloseSessionContext(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCloseSessionContextExt = timerfactory.Create<MG.MGCore.ICloseSessionContext>(_CloseSessionContext);

            return iCloseSessionContextExt;
        }
    }
}
