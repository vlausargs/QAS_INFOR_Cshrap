//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniBomSeqFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniBomSeqFactory
    {
        public IEcniBomSeq Create(IApplicationDB appDB)
        {
            var _EcniBomSeq = new EcniBomSeq(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniBomSeqExt = timerfactory.Create<IEcniBomSeq>(_EcniBomSeq);

            return iEcniBomSeqExt;
        }
    }
}
