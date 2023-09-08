//PROJECT NAME: CSICustomer
//CLASS NAME: ChargebackTypeAccountFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ChargebackTypeAccountFactory
    {
        public IChargebackTypeAccount Create(IApplicationDB appDB)
        {
            var _ChargebackTypeAccount = new ChargebackTypeAccount(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iChargebackTypeAccountExt = timerfactory.Create<IChargebackTypeAccount>(_ChargebackTypeAccount);

            return iChargebackTypeAccountExt;
        }
    }
}
