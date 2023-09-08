//PROJECT NAME: MG.MGCore
//CLASS NAME: ClearSessionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class ClearSessionFactory : IClearSessionFactory
    {
        public IClearSession Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _ClearSession = new MG.MGCore.ClearSession(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iClearSessionExt = timerfactory.Create<MG.MGCore.IClearSession>(_ClearSession);

            return iClearSessionExt;
        }
    }
}
