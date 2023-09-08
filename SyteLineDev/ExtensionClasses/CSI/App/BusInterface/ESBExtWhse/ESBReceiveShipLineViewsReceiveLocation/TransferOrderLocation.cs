using System;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface ITransferOrderLocation
    {
        void UpdateTransferOrderLocation(Guid sessionID, string itemNonNetLoc);
    }

    public class TransferOrderLocation : ITransferOrderLocation
    {

        readonly ITransferOrderLocationCRUD iTransferOrderLocationCRUD;

        public TransferOrderLocation(
            ITransferOrderLocationCRUD iTransferOrderLocationCRUD)
        {
            this.iTransferOrderLocationCRUD = iTransferOrderLocationCRUD;
        }

        public void UpdateTransferOrderLocation(Guid sessionID, string itemNonNetLoc)
        {
            var tmp_transferLocResponse = iTransferOrderLocationCRUD.LoadLocationTmp_transfer(sessionID);
            iTransferOrderLocationCRUD.UpdateLocationTmp_transfer(itemNonNetLoc, tmp_transferLocResponse);
        }
    }
}

