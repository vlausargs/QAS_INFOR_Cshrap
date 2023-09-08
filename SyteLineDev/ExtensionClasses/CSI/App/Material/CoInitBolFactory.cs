//PROJECT NAME: CSIMaterial
//CLASS NAME: CoInitBolFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CoInitBolFactory
    {
        public ICoInitBol Create(IApplicationDB appDB)
        {
            var _CoInitBol = new CoInitBol(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoInitBolExt = timerfactory.Create<ICoInitBol>(_CoInitBol);

            return iCoInitBolExt;
        }
    }
}
