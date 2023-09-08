//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniBomMatlRefFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniBomMatlRefFactory
    {
        public IEcniBomMatlRef Create(IApplicationDB appDB)
        {
            var _EcniBomMatlRef = new EcniBomMatlRef(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniBomMatlRefExt = timerfactory.Create<IEcniBomMatlRef>(_EcniBomMatlRef);

            return iEcniBomMatlRefExt;
        }
    }
}
