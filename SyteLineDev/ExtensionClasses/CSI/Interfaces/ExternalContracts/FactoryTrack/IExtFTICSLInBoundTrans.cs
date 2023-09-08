
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTICSLInBoundTrans
    {

        int PoReceiptUpdate(string order, string line, string release, string qty, string qtyReturned, string item, string site, string whse, string loc,
                string uom, string reasonCode, string lot, string vendorLot,bool generateSerials,
                bool generateLot, bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool overrideQtyTolerance, string drReturn,string PackingSlipNumber,
                string sessionID, out string InfoBar, string containerNum, string importTaxId, out string receiverNum, out string qcHoldLoc,
                string grnNum, string grnLine, string docNum, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, string UbEsigUserName, string userInitial=""); 

        int PurchaseOrderReceiptUpdate(string order, string line, string release, string qty, string qtyReturned, string item, string site, string whse, string loc,
                string uom, string reasonCode, string lot, string vendorLot, bool generateSerials,
                bool generateLot, bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool overrideQtyTolerance, string drReturn, string PackingSlipNumber,
                string sessionID, out string InfoBar, string containerNum, string importTaxId, out string receiverNum, out string qcHoldLoc,
                string grnNum, string grnLine, string docNum, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer,
                string UbEsigUserName, string LotMfgDate, string LotExpDate, string LotTrxRestrictCode, string SerialMfgDate,
                string SerialExpDate, string SerialTrxRestrictCode,string IsgenerateVoucher, out string voucherNum, string userInitial = ""); 

        int TransferOrderReceivingUpdate(string order, string line, string qty, string item, string fromSite,
                string fromWhse, string fromLoc, string fromLot, string toWhse, string toLoc,
                string toLot, string toSite, string uom, string reasonCode, string transitLocation,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, string SessionId, out string InfoBar, string containerNum,string importTaxId,string allowZeroCostItem, string docNum, string userInitial = ""); 

        int TransferOrderReceivingUpdateWithTransRestrict(string order, string line, string qty, string item, string fromSite,
                string fromWhse, string fromLoc, string fromLot, string toWhse, string toLoc,
                string toLot, string toSite, string uom, string reasonCode, string transitLocation,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, string SessionId, out string InfoBar, string containerNum, string importTaxId,
                string allowZeroCostItem, string docNum, string userInitial = "", string LotMfgDate = "", string LotExpDate = "",
                string LotTrxRestrictCode = "", string SerialMfgDate = "", string SerialExpDate = "", string SerialTrxRestrictCode = ""); 

    }
}
    
