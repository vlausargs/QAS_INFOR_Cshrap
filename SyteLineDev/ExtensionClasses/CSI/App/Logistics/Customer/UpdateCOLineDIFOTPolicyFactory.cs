//PROJECT NAME: CSICustomer
//CLASS NAME: UpdateCOLineDIFOTPolicyFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class UpdateCOLineDIFOTPolicyFactory
    {
        public IUpdateCOLineDIFOTPolicy Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _UpdateCOLineDIFOTPolicy = new UpdateCOLineDIFOTPolicy(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iUpdateCOLineDIFOTPolicyExt = timerfactory.Create<IUpdateCOLineDIFOTPolicy>(_UpdateCOLineDIFOTPolicy);

            return iUpdateCOLineDIFOTPolicyExt;
        }
    }
}
