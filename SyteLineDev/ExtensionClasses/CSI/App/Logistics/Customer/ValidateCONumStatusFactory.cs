//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateCONumStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ValidateCONumStatusFactory
    {
        public IValidateCONumStatus Create(IApplicationDB appDB)
        {
            var _ValidateCONumStatus = new ValidateCONumStatus(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateCONumStatusExt = timerfactory.Create<IValidateCONumStatus>(_ValidateCONumStatus);

            return iValidateCONumStatusExt;
        }
    }
}
