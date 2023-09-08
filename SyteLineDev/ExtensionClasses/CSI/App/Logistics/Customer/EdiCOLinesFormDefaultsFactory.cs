//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCOLinesFormDefaultsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EdiCOLinesFormDefaultsFactory
    {
        public IEdiCOLinesFormDefaults Create(IApplicationDB appDB)
        {
            var _EdiCOLinesFormDefaults = new Logistics.Customer.EdiCOLinesFormDefaults(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEdiCOLinesFormDefaultsExt = timerfactory.Create<Logistics.Customer.IEdiCOLinesFormDefaults>(_EdiCOLinesFormDefaults);

            return iEdiCOLinesFormDefaultsExt;
        }
    }
}
