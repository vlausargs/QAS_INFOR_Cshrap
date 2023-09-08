//PROJECT NAME: CSIMaterial
//CLASS NAME: TlocChkFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TlocChkFactory
    {
        public ITlocChk Create(IApplicationDB appDB)
        {
            var _TlocChk = new TlocChk(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTlocChkExt = timerfactory.Create<ITlocChk>(_TlocChk);

            return iTlocChkExt;
        }
    }
}
