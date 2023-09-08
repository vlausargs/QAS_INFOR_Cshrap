//PROJECT NAME: MG.MGCore
//CLASS NAME: BGTaskSubmitFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class BGTaskSubmitFactory : IBGTaskSubmitFactory
    {
        public IBGTaskSubmit Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _BGTaskSubmit = new BGTaskSubmit(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iBGTaskSubmitExt = timerfactory.Create<MG.MGCore.IBGTaskSubmit>(_BGTaskSubmit);

            return iBGTaskSubmitExt;
        }
    }
}
