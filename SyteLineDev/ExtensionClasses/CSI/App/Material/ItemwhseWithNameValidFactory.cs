//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemwhseWithNameValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemwhseWithNameValidFactory
    {
        public IItemwhseWithNameValid Create(IApplicationDB appDB)
        {
            var _ItemwhseWithNameValid = new ItemwhseWithNameValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemwhseWithNameValidExt = timerfactory.Create<IItemwhseWithNameValid>(_ItemwhseWithNameValid);

            return iItemwhseWithNameValidExt;
        }
    }
}
