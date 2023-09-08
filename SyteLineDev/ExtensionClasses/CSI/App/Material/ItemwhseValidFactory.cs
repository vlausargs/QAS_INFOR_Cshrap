//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemwhseValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemwhseValidFactory
    {
        public IItemwhseValid Create(IApplicationDB appDB)
        {
            var _ItemwhseValid = new ItemwhseValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemwhseValidExt = timerfactory.Create<IItemwhseValid>(_ItemwhseValid);

            return iItemwhseValidExt;
        }
    }
}
