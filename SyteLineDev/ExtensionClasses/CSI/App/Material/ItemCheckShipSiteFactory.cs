//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCheckShipSiteFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ItemCheckShipSiteFactory
    {
        public IItemCheckShipSite Create(IApplicationDB appDB)
        {
            var _ItemCheckShipSite = new ItemCheckShipSite(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemCheckShipSiteExt = timerfactory.Create<IItemCheckShipSite>(_ItemCheckShipSite);

            return iItemCheckShipSiteExt;
        }
    }
}
