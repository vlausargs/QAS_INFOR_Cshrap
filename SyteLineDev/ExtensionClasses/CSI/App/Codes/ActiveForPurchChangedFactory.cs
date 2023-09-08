//PROJECT NAME: CSICodes
//CLASS NAME: ActiveForPurchChangedFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class ActiveForPurchChangedFactory
    {
        public IActiveForPurchChanged Create(IApplicationDB appDB)
        {
            var _ActiveForPurchChanged = new ActiveForPurchChanged(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iActiveForPurchChangedExt = timerfactory.Create<IActiveForPurchChanged>(_ActiveForPurchChanged);

            return iActiveForPurchChangedExt;
        }
    }
}
