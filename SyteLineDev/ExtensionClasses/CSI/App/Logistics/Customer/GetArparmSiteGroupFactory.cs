//PROJECT NAME: CSICustomer
//CLASS NAME: GetArparmSiteGroupFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class GetArparmSiteGroupFactory
    {
        public IGetArparmSiteGroup Create(IApplicationDB appDB)
        {
            var _GetArparmSiteGroup = new GetArparmSiteGroup(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetArparmSiteGroupExt = timerfactory.Create<IGetArparmSiteGroup>(_GetArparmSiteGroup);

            return iGetArparmSiteGroupExt;
        }
    }
}
