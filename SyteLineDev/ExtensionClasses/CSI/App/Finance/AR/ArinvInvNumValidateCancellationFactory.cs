//PROJECT NAME: CSICustomer
//CLASS NAME: ArinvInvNumValidateCancellationFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArinvInvNumValidateCancellationFactory
    {
        public IArinvInvNumValidateCancellation Create(IApplicationDB appDB)
        {
            var _ArinvInvNumValidateCancellation = new ArinvInvNumValidateCancellation(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArinvInvNumValidateCancellationExt = timerfactory.Create<IArinvInvNumValidateCancellation>(_ArinvInvNumValidateCancellation);

            return iArinvInvNumValidateCancellationExt;
        }
    }
}
