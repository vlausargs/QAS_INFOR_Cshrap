//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemStatusChangeFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemStatusChangeFactory
    {
        public IItemStatusChange Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _ItemStatusChange = new ItemStatusChange(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemStatusChangeExt = timerfactory.Create<IItemStatusChange>(_ItemStatusChange);

            return iItemStatusChangeExt;
        }
    }
}
