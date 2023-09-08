using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Production.APS
{
    public interface IApsInvEvent
    {
        ICollectionLoadResponse ApsInvEventFn(int? detailDisplay, int? useFullyTransactedOrders, int? calledForIntraSiteTransfer);
    }
}
