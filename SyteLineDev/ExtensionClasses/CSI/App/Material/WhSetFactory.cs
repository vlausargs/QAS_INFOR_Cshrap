//PROJECT NAME: CSIMaterial
//CLASS NAME: WhSetFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class WhSetFactory
    {
        public IWhSet Create(IApplicationDB appDB)
        {
            var _WhSet = new WhSet(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWhSetExt = timerfactory.Create<IWhSet>(_WhSet);

            return iWhSetExt;
        }
    }
}
