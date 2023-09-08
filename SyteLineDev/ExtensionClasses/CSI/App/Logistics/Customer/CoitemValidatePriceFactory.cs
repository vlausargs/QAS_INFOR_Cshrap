//PROJECT NAME: CSICustomer
//CLASS NAME: CoitemValidatePriceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CoitemValidatePriceFactory
    {
        public ICoitemValidatePrice Create(IApplicationDB appDB)
        {
            var _CoitemValidatePrice = new CoitemValidatePrice(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoitemValidatePriceExt = timerfactory.Create<ICoitemValidatePrice>(_CoitemValidatePrice);

            return iCoitemValidatePriceExt;
        }
    }
}
