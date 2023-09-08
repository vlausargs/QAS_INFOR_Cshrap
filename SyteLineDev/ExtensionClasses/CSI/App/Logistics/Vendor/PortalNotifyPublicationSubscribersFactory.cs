using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Logistics.Vendor
{
    public class PortalNotifyPublicationSubscribersFactory
    {
        public IPortalNotifyPublicationSubscribers Create(IApplicationDB appDB)
        {
            var _PortalNotifyPublicationSubscribers = new PortalNotifyPublicationSubscribers(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPortalNotifyPublicationSubscribersExt = timerfactory.Create<IPortalNotifyPublicationSubscribers>(_PortalNotifyPublicationSubscribers);

            return iPortalNotifyPublicationSubscribersExt;
        }
    }
}
