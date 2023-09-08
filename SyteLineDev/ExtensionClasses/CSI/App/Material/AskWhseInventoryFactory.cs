//PROJECT NAME: CSIMaterial
//CLASS NAME: AskWhseInventoryFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class AskWhseInventoryFactory
    {
        public IAskWhseInventory Create(IApplicationDB appDB)
        {
            var _AskWhseInventory = new AskWhseInventory(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAskWhseInventoryExt = timerfactory.Create<IAskWhseInventory>(_AskWhseInventory);

            return iAskWhseInventoryExt;
        }
    }
}
