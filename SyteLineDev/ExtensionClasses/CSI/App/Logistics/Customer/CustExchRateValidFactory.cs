//PROJECT NAME: CSICustomer
//CLASS NAME: CustExchRateValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CustExchRateValidFactory
    {
        public ICustExchRateValid Create(IApplicationDB appDB)
        {
            var _CustExchRateValid = new Logistics.Customer.CustExchRateValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCustExchRateValidExt = timerfactory.Create<Logistics.Customer.ICustExchRateValid>(_CustExchRateValid);

            return iCustExchRateValidExt;
        }
    }
}
