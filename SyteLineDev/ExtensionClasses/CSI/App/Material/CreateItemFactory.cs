//PROJECT NAME: CSIMaterial
//CLASS NAME: CreateItemFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CreateItemFactory
    {
        public ICreateItem Create(IApplicationDB appDB)
        {
            var _CreateItem = new CreateItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCreateItemExt = timerfactory.Create<ICreateItem>(_CreateItem);

            return iCreateItemExt;
        }
    }
}
