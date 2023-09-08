
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTICSLShopFloorTrans
    {

        int JITProductionUpdate(string qty, string item, string site, string whse, string loc,
                string uom, string lot, string vendorLot, string shift, string employee,
                bool generateSerials, bool generateLot,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, string SessionID, out string InfoBar, string containerNum, string docNum, string userInitial = ""); 

        int JobMaterialIssueUpdate(string job, string suffix, string operation, string sequence, string qty,
                string item, string site, string whse, string loc, string lot, string uom,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool issueNewMaterial,
                bool processAsByProduct, string otherAcct,
                string otherAcctUnit1, string otherAcctUnit2,
                string otherAcctUnit3, string otherAcctUnit4,
                string materialCost, string SessionID, out string InfoBar, string docNum,
                string JobLot = "", string JobSerial = "", string containerNum = "", string userInitial = "");

        int JobMaterialIssueUpdateNew(string job, string suffix, string operation, string sequence, string qty,
                string item, string site, string whse, string loc, string lot, string uom,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool issueNewMaterial,
                bool processAsByProduct, string otherAcct,
                string otherAcctUnit1, string otherAcctUnit2,
                string otherAcctUnit3, string otherAcctUnit4,
                string materialCost, string SessionID, out string InfoBar, string docNum,
                string JobLot = "", string JobSerial = "", string containerNum = "", string userInitial = "", string serialsDataXML = "");

        int JobMoveUpdate(string job, string suffix, string oper, string deviceId, string transDate,
                    string qtyCompleted, string qtyScrapped, string qtyMoved, string uom, string reasonCode, bool operComplete,
                    bool closeJob, string lot, string loc, string whse, string site, string userInitials, bool addItemLocRecord,
                    bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink, bool generateSerials, string SessionID,
                    out string InfoBar, string containerNum, bool issueToParentInput, string postingFlag, ref string TransNum,
                    string employee, bool reverserQty, string scrapDataXML, string backflushLotsDataXML,
                    string backflushSerialsDataXML, string endItemSerialsDataXML, string coproductDataXML);

        int JobMaterialRapidEntryUpdate(string job, string suffix, string whse, string site, string materialXML, bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink,  string docNum, out string InfoBar, out string transStatus, string JobLot = "", string JobSerial = "",string userInitial=""); 

        int LaborCompleteOperUpload(string inputJobXML, out string InfoBar); 

        int MoveUpdate(string job, string suffix, string oper, string deviceId, string transDate, string qtyCompleted,
                string qtyScrapped, string qtyMoved, string uom, string reasonCode, bool operComplete, bool closeJob, string lot,
                string loc, string whse, string site, string userInitials,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool generateSerials, string SessionID, out string InfoBar, string containerNum, bool issueToParentInput, string postingFlag, ref string TransNum, string NextOper); 

        int MoveUpdateWithScrapedQty(string job, string suffix, string oper, string deviceId, string transDate, string qtyCompleted,
                string qtyScrapped, string qtyMoved, string uom, string reasonCode, bool operComplete, bool closeJob, string lot,
                string loc, string whse, string site, string userInitials,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool generateSerials, string SessionID, out string InfoBar, string containerNum, bool issueToParentInput, string postingFlag, ref string TransNum, string NextOper); 

        int ProjectMaterialIssueUpdate(string projNum, string task, string sequence, string qty, string item,
                string itemDesc, string site, string whse, string loc, string lot, string uom,
                string costCode, bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool issueNewMaterial,
                string otherAcct,
                string otherAcctUnit1, string otherAcctUnit2,
                string otherAcctUnit3, string otherAcctUnit4,
                string nonInvCost, out string InfoBar, string SessionID, string containerNum, string docNum, string userInitial); 

        int PSScrapUpdate(string item, string prodschedule, string workcenter,
                string operation, string site, string whse, string qty, string uom, string employee,
                string shift, string reasonCode,
                string SessionID, out string InfoBar, string userInitial = ""); 

        int PSUpdate(string item, string prodschedule, string workcenter,
                string operation, string site, string whse, string qty, string uom, string loc, string lot, string employee,
                string shift, string vendorLot, bool generateSerials, bool generateLot, bool addItemLocRecord,
                bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink,
                string qtyRej, string reasonCode,
                string SessionID, out string InfoBar, string containerNum, string docNum, string userInitial = ""); 

        int PSUpdateWithTransRestrict(string item, string prodschedule, string workcenter,
                string operation, string site, string whse, string qty, string uom, string loc, string lot, string employee,
                string shift, string vendorLot, bool generateSerials, bool generateLot, bool addItemLocRecord,
                bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink,
                string qtyRej, string reasonCode,
                string SessionID, out string InfoBar, string containerNum, string docNum, string userInitial = "",
                string LotMfgDate = "", string LotExpDate = "", string LotTrxRestrictCode = "",
                string SerialMfgDate = "", string SerialExpDate = "", string SerialTrxRestrictCode = ""); 

        int ReportProductionUpdate(string job, string suffix, string qty,
                string item, string site, string whse, string loc, string uom, string lot,
                bool generateSerials, bool generateLot, string documentNo,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, bool overRideQtyPrompt,
                string SessionID, out string InfoBar, string containerNum, string userInitial = ""); 

        int TASLJobUpload(string inputJobXML, out string InfoBar); 

        int TASLLaborUpload(string inputJobXML, out string InfoBar); 

        int WorkCenterMaterialIssueUpdate(string workcenter, string employee, string qty, string item, string site,
                string whse, string loc, string lot, string uom,
                bool allowNegInventory, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink,
                string SessionID, out string InfoBar, string containerNum, string docNum, string userInitial = ""); 

    }
}
    
