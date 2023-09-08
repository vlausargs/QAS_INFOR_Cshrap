//PROJECT NAME: MG.MGCore
//CLASS NAME: ResetSessionIDFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class ResetSessionIDFactory : IResetSessionIDFactory
    {
        public IResetSessionID Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _ResetSessionID = new ResetSessionID(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iResetSessionIDExt = timerfactory.Create<MG.MGCore.IResetSessionID>(_ResetSessionID);

            return iResetSessionIDExt;
        }
    }
}
