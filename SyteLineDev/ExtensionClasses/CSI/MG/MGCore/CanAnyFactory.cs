//PROJECT NAME: MG.MGCore
//CLASS NAME: CanAnyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class CanAnyFactory : ICanAnyFactory
    {
        public ICanAny Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _CanAny = new CanAny(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCanAnyExt = timerfactory.Create<MG.MGCore.ICanAny>(_CanAny);

            return iCanAnyExt;
        }
    }
}
