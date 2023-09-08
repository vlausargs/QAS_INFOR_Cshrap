//PROJECT NAME: CSIProduct
//CLASS NAME: PreGenPsFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class PreGenPsFactory
    {
        public IPreGenPs Create(IApplicationDB appDB)
        {
            var _PreGenPs = new PreGenPs(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPreGenPsExt = timerfactory.Create<IPreGenPs>(_PreGenPs);

            return iPreGenPsExt;
        }
    }
}
