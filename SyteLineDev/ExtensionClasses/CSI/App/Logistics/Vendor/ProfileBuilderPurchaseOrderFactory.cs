//PROJECT NAME: CSIVendor
//CLASS NAME: ProfileBuilderPurchaseOrderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
    public class ProfileBuilderPurchaseOrderFactory
    {
        public IProfileBuilderPurchaseOrder Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _ProfileBuilderPurchaseOrder = new Logistics.Vendor.ProfileBuilderPurchaseOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iProfileBuilderPurchaseOrderExt = timerfactory.Create<Logistics.Vendor.IProfileBuilderPurchaseOrder>(_ProfileBuilderPurchaseOrder);

            return iProfileBuilderPurchaseOrderExt;
        }
    }
}
