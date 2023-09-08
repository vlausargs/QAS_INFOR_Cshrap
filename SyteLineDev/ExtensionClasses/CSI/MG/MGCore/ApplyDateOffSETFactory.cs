//PROJECT NAME: Production
//CLASS NAME: ApplyDateOffsetFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class ApplyDateOffsetFactory : IApplyDateOffsetFactory
    {
        public IApplyDateOffset Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _ApplyDateOffset = new ApplyDateOffset(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApplyDateOffsetExt = timerfactory.Create<MG.MGCore.IApplyDateOffset>(_ApplyDateOffset);

            return iApplyDateOffsetExt;
        }
    }
}
