using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.ExternalContracts.FactoryTrack;

namespace InforCollect.ERP.SL.ICSLInboundTrans
{
    public class InbondTransactions : FTKExtensionClassBase, IExtFTICSLInBoundTrans
    {
        private int retVal = -1;
        public int PoReceiptUpdate(string order, string line, string release, string qty, string qtyReturned, string item, string site, string whse, string loc,
                                          string uom, string reasonCode, string lot, string vendorLot,bool generateSerials,
                                          bool generateLot, bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, bool overrideQtyTolerance, string drReturn,string PackingSlipNumber,
                                          string sessionID, out string InfoBar, string containerNum, string importTaxId, out string receiverNum, out string qcHoldLoc,
                                          string grnNum, string grnLine, string docNum, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, string UbEsigUserName, string userInitial="")
        {
            string voucherNum = string.Empty;
            return PurchaseOrderReceiptUpdate(order, line, release, qty, qtyReturned, item, site, whse, loc,
                                          uom, reasonCode, lot, vendorLot, generateSerials,
                                          generateLot, addItemLocRecord, allowIfCycleCountExists,
                                          addPermanentItemWhseLocLink, overrideQtyTolerance, drReturn, PackingSlipNumber,
                                          sessionID, out InfoBar, containerNum, importTaxId, out receiverNum, out qcHoldLoc,
                                          grnNum, grnLine, docNum, UbEsigEncryptedPassword, UbEsigReasonCode, UbEsigRowPointer,
                                          UbEsigUserName, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,string.Empty,out voucherNum, userInitial); 
            
        }


        public int PurchaseOrderReceiptUpdate(string order, string line, string release, string qty, string qtyReturned, string item, string site, string whse, string loc,
                                          string uom, string reasonCode, string lot, string vendorLot, bool generateSerials,
                                          bool generateLot, bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, bool overrideQtyTolerance, string drReturn, string PackingSlipNumber,
                                          string sessionID, out string InfoBar, string containerNum, string importTaxId, out string receiverNum, out string qcHoldLoc,
                                          string grnNum, string grnLine, string docNum, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, 
                                          string UbEsigUserName, string LotMfgDate, string LotExpDate, string LotTrxRestrictCode, string SerialMfgDate,
                                          string SerialExpDate, string SerialTrxRestrictCode,string IsgenerateVoucher, out string voucherNum, string userInitial = "")
        {
            InfoBar = "";
            voucherNum = string.Empty;
            PoReceiptUpdate poReceiptUpdate = new PoReceiptUpdate(order, line, release, qty, qtyReturned, item, site, whse, loc,
                                           uom, reasonCode, lot, vendorLot, generateSerials,
                                            generateLot, addItemLocRecord, allowIfCycleCountExists,
                                            addPermanentItemWhseLocLink, overrideQtyTolerance, drReturn, PackingSlipNumber,
                                            sessionID, containerNum, importTaxId, grnNum, grnLine, docNum, UbEsigEncryptedPassword, UbEsigReasonCode, UbEsigRowPointer, UbEsigUserName,
                                            LotMfgDate, LotExpDate, LotTrxRestrictCode, SerialMfgDate, SerialExpDate, SerialTrxRestrictCode, IsgenerateVoucher);

            poReceiptUpdate.Initialize();
            poReceiptUpdate.SetContext(this.Context);
            poReceiptUpdate.SetMessageProvider(this.GetMessageProvider());
            poReceiptUpdate.UpdateUserInitial(userInitial, out InfoBar);
            var currentDateTime = DateTime.Now;
            var siteDateTime = GetSiteDate(currentDateTime);
            poReceiptUpdate.SiteDateTime = siteDateTime ?? currentDateTime;
            retVal = poReceiptUpdate.PerformUpdate(out InfoBar, out receiverNum, out qcHoldLoc,out voucherNum);
            return retVal;

        }



        public int TransferOrderReceivingUpdate(string order, string line, string qty, string item, string fromSite,
                                            string fromWhse, string fromLoc, string fromLot, string toWhse, string toLoc,
                                            string toLot, string toSite, string uom, string reasonCode, string transitLocation,
                                            bool addItemLocRecord, bool allowIfCycleCountExists,
                                            bool addPermanentItemWhseLocLink, string SessionId, out string InfoBar, string containerNum,string importTaxId,string allowZeroCostItem, string docNum, string userInitial = "")
        {            
                   
            return TransferOrderReceivingUpdateWithTransRestrict(order, line,qty, item, fromSite,
                                            fromWhse, fromLoc, fromLot, toWhse, toLoc, toLot, toSite, uom,
                                            reasonCode, transitLocation, addItemLocRecord, allowIfCycleCountExists,
                                            addPermanentItemWhseLocLink, SessionId,out InfoBar, containerNum, importTaxId, allowZeroCostItem, docNum,
                                            userInitial, string.Empty,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty);
             
           
        }
        public int TransferOrderReceivingUpdateWithTransRestrict(string order, string line, string qty, string item, string fromSite,
                                            string fromWhse, string fromLoc, string fromLot, string toWhse, string toLoc,
                                            string toLot, string toSite, string uom, string reasonCode, string transitLocation,
                                            bool addItemLocRecord, bool allowIfCycleCountExists,
                                            bool addPermanentItemWhseLocLink, string SessionId, out string InfoBar, string containerNum, string importTaxId, 
                                            string allowZeroCostItem, string docNum, string userInitial = "", string LotMfgDate = "", string LotExpDate = "", 
                                            string LotTrxRestrictCode = "", string SerialMfgDate = "", string SerialExpDate = "", string SerialTrxRestrictCode = "")
        {
            InfoBar = string.Empty;
            TransferOrderReceivingUpdate transferOrderReceivingUpdate = new TransferOrderReceivingUpdate(order, line, qty, item, fromSite,
                                            fromWhse, fromLoc, fromLot, toWhse, toLoc, toLot, toSite, uom,
                                            reasonCode, transitLocation, addItemLocRecord, allowIfCycleCountExists,
                                            addPermanentItemWhseLocLink, SessionId, containerNum, importTaxId, allowZeroCostItem, docNum,
                                            LotMfgDate,LotExpDate, LotTrxRestrictCode, SerialMfgDate, SerialExpDate, SerialTrxRestrictCode);

            transferOrderReceivingUpdate.Initialize();
            transferOrderReceivingUpdate.SetContext(this.Context);
            transferOrderReceivingUpdate.UpdateUserInitial(userInitial, out InfoBar);
            var currentDateTime = DateTime.Now;
            var siteDateTime = GetSiteDate(currentDateTime);
            transferOrderReceivingUpdate.SiteDateTime = siteDateTime ?? currentDateTime;
            retVal = transferOrderReceivingUpdate.PerformUpdate(out InfoBar);
            return retVal;
        }
    }
}
