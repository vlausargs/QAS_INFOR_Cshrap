using System;
using CSI.Admin;
using CSI.MG.MGCore;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IESBReceiveShipLineViewsReceiveLocation
    {
        void UpdateReceiveLocationPerHoldCode(string documentIDName, string purchaseOrderRef, string salesOrderRef, string item, string warehouse, string holdcode);
    }

    public class ESBReceiveShipLineViewsReceiveLocation : IESBReceiveShipLineViewsReceiveLocation
    {
        readonly IIsFeatureActive iIsFeatureActive;
        readonly IHoldCodeAndItemNonNettableLocation iHoldCodeAndItemNonNettableLocation;
        readonly IDocumentIDName iDocumentIDName;
        readonly ISalesOrderNonNettableLocation iSalesOrderNonNettableLocation;
        readonly IPurchaseOrderNonNettableLocation iPurchaseOrderNonNettableLocation;
        readonly ITransferOrderNonNettableLocation iTransferOrderNonNettableLocation;
        readonly ISessionID iSessionID;

        public ESBReceiveShipLineViewsReceiveLocation(IIsFeatureActive iIsFeatureActive,
            IHoldCodeAndItemNonNettableLocation iHoldCodeAndItemNonNettableLocation,
            IDocumentIDName iDocumentIDName,
            ISalesOrderNonNettableLocation iSalesOrderNonNettableLocation,
            IPurchaseOrderNonNettableLocation iPurchaseOrderNonNettableLocation,
            ITransferOrderNonNettableLocation iTransferOrderNonNettableLocation,
            ISessionID iSessionID)
        {
            this.iIsFeatureActive = iIsFeatureActive;
            this.iHoldCodeAndItemNonNettableLocation = iHoldCodeAndItemNonNettableLocation;
            this.iDocumentIDName = iDocumentIDName;
            this.iSalesOrderNonNettableLocation = iSalesOrderNonNettableLocation;
            this.iPurchaseOrderNonNettableLocation = iPurchaseOrderNonNettableLocation;
            this.iTransferOrderNonNettableLocation = iTransferOrderNonNettableLocation;
            this.iSessionID = iSessionID;
        }

        public void UpdateReceiveLocationPerHoldCode(
            string documentIDName,
            string purchaseOrderRef,
            string salesOrderRef,
            string item,
            string warehouse,
            string holdcode)
        {
            (int? severity, int? featureActive, string infoBar) = iIsFeatureActive.IsFeatureActiveSp(
                ProductName: "CSI",
                FeatureID: "RS9166",
                FeatureActive: 0,
                InfoBar: null);

            if ((severity ?? 0) != 0)
                throw new Exception(infoBar);
            else if ((featureActive ?? 0) == 0)
                return;

            string itemNonNetLoc = iHoldCodeAndItemNonNettableLocation.GetItemNonNetLocWhenHoldCodeExists(item, warehouse, holdcode);
            Guid sessionID = iSessionID.SessionIDSp();

            if (string.IsNullOrEmpty(itemNonNetLoc))
                return;

            documentIDName = iDocumentIDName.GetDocIDName(documentIDName, purchaseOrderRef, salesOrderRef);

            if (string.Compare(documentIDName, "SalesOrder", StringComparison.InvariantCultureIgnoreCase) == 0
                || string.Compare(documentIDName, "CustomerReturn", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                iSalesOrderNonNettableLocation.CheckAndUpdateSOLoc(sessionID, itemNonNetLoc);
            }
            else if (string.Compare(documentIDName, "PurchaseOrder", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                iPurchaseOrderNonNettableLocation.CheckAndUpdatePOLoc(sessionID, itemNonNetLoc);
            }
            else if (string.Compare(documentIDName, "Transfer", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                iTransferOrderNonNettableLocation.CheckAndUpdateTOLoc(sessionID, itemNonNetLoc);
            }

        }
    }
}
