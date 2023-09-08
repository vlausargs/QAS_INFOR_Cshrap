//PROJECT NAME: CSICodes
//CLASS NAME: TaxCodeExistsFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class TaxCodeExistsFactory
    {
        public ITaxCodeExists Create(IApplicationDB appDB)
        {
            var _TaxCodeExists = new Codes.TaxCodeExists(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTaxCodeExistsExt = timerfactory.Create<Codes.ITaxCodeExists>(_TaxCodeExists);

            return iTaxCodeExistsExt;
        }
    }
}
