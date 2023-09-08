//PROJECT NAME: Finance
//CLASS NAME: TaxPriceSeparationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
    public class TaxPriceSeparationFactory
    {
        public ITaxPriceSeparation Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
           
            var _TaxPriceSeparation = new Finance.TaxPriceSeparation(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTaxPriceSeparationExt = timerfactory.Create<Finance.ITaxPriceSeparation>(_TaxPriceSeparation);

            return iTaxPriceSeparationExt;
        }
    }
}
