using System;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IPurchaseOrderLocation
    {
        void UpdatePurchaseOrderLocation(Guid sessionID, string itemNonNetLoc);
    }

    public class PurchaseOrderLocation : IPurchaseOrderLocation
    {

        readonly IPurchaseOrderLocationCRUD iPurchaseOrderLocationCRUD;

        public PurchaseOrderLocation(
            IPurchaseOrderLocationCRUD iPurchaseOrderLocationCRUD)
        {
            this.iPurchaseOrderLocationCRUD = iPurchaseOrderLocationCRUD;
        }

        public void UpdatePurchaseOrderLocation(Guid sessionID, string itemNonNetLoc)
        {
            var tt_rcvLocResponse = iPurchaseOrderLocationCRUD.LoadLocationTt_rcv(sessionID);
            iPurchaseOrderLocationCRUD.UpdateLocationTt_rcv(itemNonNetLoc, tt_rcvLocResponse);
        }
    }
}

