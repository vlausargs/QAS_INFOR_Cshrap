//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniWcFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniWcFactory
    {
        public IEcniWc Create(IApplicationDB appDB)
        {
            var _EcniWc = new EcniWc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniWcExt = timerfactory.Create<IEcniWc>(_EcniWc);

            return iEcniWcExt;
        }
    }
}
