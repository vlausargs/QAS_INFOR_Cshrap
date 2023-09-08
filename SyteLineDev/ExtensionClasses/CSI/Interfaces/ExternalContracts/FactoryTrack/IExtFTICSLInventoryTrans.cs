
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTICSLInventoryTrans
    {

        int AdjustmentUpdate(string qty,string item,string site, string whse,
                string loc, string uom, string reasonCode,bool addItemLocRecord,
                bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink,
                string documentNumber, out string Infobar, string userInitial); 

        int BuildContainer(string qty, string item, string site, string whse,
                string loc, string uom, string lot, bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool allowIfSlowMoving,
                string SerialsSessionID, string containerNum, out string Infobar, string userInitial); 

        int MiscellaneousIssueUpdate(string qty, string item, string site, string whse, string loc,
                string uom, string reasonCode, string lot, bool allowNegInventory, bool addItemLocRecord,
                bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink, string documentNumber,
                string SerialsSessionID, out string Infobar, string containerNum, string userInitial, string ImportDocID); 

        int MiscellaneousReceiptUpdate(string qty, string item, string site, string whse, string loc,
                string uom, string reasonCode, string lot, bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool allowIfSlowMoving,
                string documentNumber,
                string SerialsSessionID, string ImportDocID, string ContainerNum, out string Infobar,string userInitial); 

        int MiscellaneousReceiptUpdateWithTransRestrict(string qty, string item, string site, string whse, string loc,
                string uom, string reasonCode, string lot, bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool allowIfSlowMoving,
                string documentNumber, string SerialsSessionID, string ImportDocID, string ContainerNum, out string Infobar, string userInitial,
                string LotMfgDate, string LotExpDate, string LotTrxRestrictCode, string SerialMfgDate, string SerialExpDate, string SerialTrxRestrictCode); 

        int TransferUpdate(string qty, string item, string fromSite,
                string fromWhse, string fromLoc, string fromLot,
                string toWhse, string toLoc, string toLot,string toSite,
                string uom, bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, string SerialsSessionID, out string Infobar, string containerNum, string userInitial, string docNum); 

    }
}
    
