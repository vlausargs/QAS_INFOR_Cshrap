//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsNonInvItemFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpIsNonInvItemFactory
    {
        public IApsCtpIsNonInvItem Create(IApplicationDB appDB)
        {
            var _ApsCtpIsNonInvItem = new ApsCtpIsNonInvItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpIsNonInvItemExt = timerfactory.Create<IApsCtpIsNonInvItem>(_ApsCtpIsNonInvItem);

            return iApsCtpIsNonInvItemExt;
        }
    }
}
