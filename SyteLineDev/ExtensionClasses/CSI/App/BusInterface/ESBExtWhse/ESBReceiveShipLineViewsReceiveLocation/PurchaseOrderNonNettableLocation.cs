using System;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IPurchaseOrderNonNettableLocation
    {
        void CheckAndUpdatePOLoc(Guid sessionID, string itemNonNetLoc);
    }

    public class PurchaseOrderNonNettableLocation : IPurchaseOrderNonNettableLocation
    {

        readonly IPurchaseOrderLocation iPurchaseOrderLocation;
        readonly IPurchaseOrderLocationCRUD iPurchaseOrderLocationCRUD;

        public PurchaseOrderNonNettableLocation(
            IPurchaseOrderLocation iPurchaseOrderLocation,
            IPurchaseOrderLocationCRUD iPurchaseOrderLocationCRUD)
        {
            this.iPurchaseOrderLocation = iPurchaseOrderLocation;
            this.iPurchaseOrderLocationCRUD = iPurchaseOrderLocationCRUD;
        }

        public void CheckAndUpdatePOLoc(Guid sessionID, string itemNonNetLoc)
        {
            string loc = iPurchaseOrderLocationCRUD.LoadTopOneLocationTt_rcv(sessionID);
            if (loc != itemNonNetLoc)
                iPurchaseOrderLocation.UpdatePurchaseOrderLocation(sessionID, itemNonNetLoc);
        }
    }
}
