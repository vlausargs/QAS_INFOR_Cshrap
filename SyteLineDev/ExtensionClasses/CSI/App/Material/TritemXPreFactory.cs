//PROJECT NAME: CSIMaterial
//CLASS NAME: TritemXPreFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TritemXPreFactory
    {
        public ITritemXPre Create(IApplicationDB appDB)
        {
            var _TritemXPre = new TritemXPre(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTritemXPreExt = timerfactory.Create<ITritemXPre>(_TritemXPre);

            return iTritemXPreExt;
        }
    }
}
