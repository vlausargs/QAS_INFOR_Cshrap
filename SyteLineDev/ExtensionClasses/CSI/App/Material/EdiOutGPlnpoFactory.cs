//PROJECT NAME: CSIMaterial
//CLASS NAME: EdiOutGPlnpoFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EdiOutGPlnpoFactory
    {
        public IEdiOutGPlnpo Create(IApplicationDB appDB)
        {
            var _EdiOutGPlnpo = new EdiOutGPlnpo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEdiOutGPlnpoExt = timerfactory.Create<IEdiOutGPlnpo>(_EdiOutGPlnpo);

            return iEdiOutGPlnpoExt;
        }
    }
}
