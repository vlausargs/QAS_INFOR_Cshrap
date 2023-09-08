//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCustProfileExistsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EdiCustProfileExistsFactory
    {
        public IEdiCustProfileExists Create(IApplicationDB appDB)
        {
            var _EdiCustProfileExists = new Logistics.Customer.EdiCustProfileExists(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEdiCustProfileExistsExt = timerfactory.Create<Logistics.Customer.IEdiCustProfileExists>(_EdiCustProfileExists);

            return iEdiCustProfileExistsExt;
        }
    }
}
