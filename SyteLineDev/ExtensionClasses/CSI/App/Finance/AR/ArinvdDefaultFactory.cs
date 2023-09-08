//PROJECT NAME: CSICustomer
//CLASS NAME: ArinvdDefaultFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArinvdDefaultFactory
    {
        public IArinvdDefault Create(IApplicationDB appDB)
        {
            var _ArinvdDefault = new ArinvdDefault(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArinvdDefaultExt = timerfactory.Create<IArinvdDefault>(_ArinvdDefault);

            return iArinvdDefaultExt;
        }
    }
}
