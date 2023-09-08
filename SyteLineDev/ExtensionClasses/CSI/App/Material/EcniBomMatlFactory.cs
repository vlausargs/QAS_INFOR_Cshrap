//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniBomMatlFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniBomMatlFactory
    {
        public IEcniBomMatl Create(IApplicationDB appDB)
        {
            var _EcniBomMatl = new EcniBomMatl(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniBomMatlExt = timerfactory.Create<IEcniBomMatl>(_EcniBomMatl);

            return iEcniBomMatlExt;
        }
    }
}
