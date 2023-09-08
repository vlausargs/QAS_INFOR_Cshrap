//PROJECT NAME: CSIMaterial
//CLASS NAME: ResforOrderUpdateFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ResforOrderUpdateFactory
    {
        public IResforOrderUpdate Create(IApplicationDB appDB)
        {
            var _ResforOrderUpdate = new ResforOrderUpdate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iResforOrderUpdateExt = timerfactory.Create<IResforOrderUpdate>(_ResforOrderUpdate);

            return iResforOrderUpdateExt;
        }
    }
}
