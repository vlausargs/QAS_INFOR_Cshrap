using System;

namespace CSI.BusInterface.ESBExtWhse
{

    public interface ITransferOrderNonNettableLocation
    {
        void CheckAndUpdateTOLoc(Guid sessionID, string itemNonNetLoc);
    }

    public class TransferOrderNonNettableLocation : ITransferOrderNonNettableLocation
    {

        readonly ITransferOrderLocation iTransferOrderLocation;
        readonly ITransferOrderLocationCRUD iTransferOrderLocationCRUD;

        public TransferOrderNonNettableLocation(
            ITransferOrderLocation iTransferOrderLocation,
            ITransferOrderLocationCRUD iTransferOrderLocationCRUD)
        {
            this.iTransferOrderLocation = iTransferOrderLocation;
            this.iTransferOrderLocationCRUD = iTransferOrderLocationCRUD;
        }

        public void CheckAndUpdateTOLoc(Guid sessionID, string itemNonNetLoc)
        {
            string loc = iTransferOrderLocationCRUD.LoadTopOneLocationTmp_transfer(sessionID);
            if (loc != itemNonNetLoc)
                iTransferOrderLocation.UpdateTransferOrderLocation(sessionID, itemNonNetLoc);
        }
    }
}
