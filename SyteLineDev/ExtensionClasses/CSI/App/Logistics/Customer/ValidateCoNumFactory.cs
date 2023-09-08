//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateCoNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ValidateCoNumFactory
    {
        public IValidateCoNum Create(IApplicationDB appDB)
        {
            var _ValidateCoNum = new ValidateCoNum(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateCoNumExt = timerfactory.Create<IValidateCoNum>(_ValidateCoNum);

            return iValidateCoNumExt;
        }
    }
}
