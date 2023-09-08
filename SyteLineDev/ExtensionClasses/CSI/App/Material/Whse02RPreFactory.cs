//PROJECT NAME: CSIMaterial
//CLASS NAME: Whse02RPreFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class Whse02RPreFactory
    {
        public IWhse02RPre Create(IApplicationDB appDB)
        {
            var _Whse02RPre = new Whse02RPre(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWhse02RPreExt = timerfactory.Create<IWhse02RPre>(_Whse02RPre);

            return iWhse02RPreExt;
        }
    }
}
