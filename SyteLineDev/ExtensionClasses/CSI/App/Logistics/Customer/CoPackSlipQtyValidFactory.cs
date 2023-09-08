//PROJECT NAME: CSICustomer
//CLASS NAME: CoPackSlipQtyValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CoPackSlipQtyValidFactory
    {
        public ICoPackSlipQtyValid Create(IApplicationDB appDB)
        {
            var _CoPackSlipQtyValid = new CoPackSlipQtyValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoPackSlipQtyValidExt = timerfactory.Create<ICoPackSlipQtyValid>(_CoPackSlipQtyValid);

            return iCoPackSlipQtyValidExt;
        }
    }
}
