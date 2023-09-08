//PROJECT NAME: CSIMaterial
//CLASS NAME: SloclotFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class SloclotFactory
    {
        public ISloclot Create(IApplicationDB appDB)
        {
            var _Sloclot = new Sloclot(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSloclotExt = timerfactory.Create<ISloclot>(_Sloclot);

            return iSloclotExt;
        }
    }
}
