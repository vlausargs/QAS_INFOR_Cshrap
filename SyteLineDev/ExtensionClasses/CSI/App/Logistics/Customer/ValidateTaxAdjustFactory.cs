//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateTaxAdjustFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ValidateTaxAdjustFactory
    {
        public IValidateTaxAdjust Create(IApplicationDB appDB)
        {
            var _ValidateTaxAdjust = new ValidateTaxAdjust(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateTaxAdjustExt = timerfactory.Create<IValidateTaxAdjust>(_ValidateTaxAdjust);

            return iValidateTaxAdjustExt;
        }
    }
}
