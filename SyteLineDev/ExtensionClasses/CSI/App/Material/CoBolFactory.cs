//PROJECT NAME: CSIMaterial
//CLASS NAME: CoBolFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CoBolFactory
    {
        public ICoBol Create(IApplicationDB appDB)
        {
            var _CoBol = new CoBol(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCoBolExt = timerfactory.Create<ICoBol>(_CoBol);

            return iCoBolExt;
        }
    }
}
