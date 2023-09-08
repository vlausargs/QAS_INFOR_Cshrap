
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTICSLOutBoundTrans
    {

        int CustomerOrderPickAndShipUpdate(string order, String line, String release, String qty,
                String item, String site, string whse, String loc, String lot,
                String uom,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, string SessionID, string userInitial, bool allowNegInventory, out string Infobar, string docNum, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, string UbEsigUserName, string containerNum = ""); 

        int CustomerOrderShippingUpdate(string order, String site,
                string whse, string stageLocation,
                bool allowIfCycleCountExists, string noOfDaysToDueDate,
                bool addPermanentItemWhseLocLink,
                out string InfoBar, string userInitial, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, string UbEsigUserName); 

        int ManageCustomerOrderReservationsUpdate(string order, String line, String release, String qty,
                String item, String site, string whse, String loc, String lot,
                String uom, string stageLocation, String operationType,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, string SessionID, out string Infobar, string docNum, string userInitial); 

        int PickPackShipCreateShipmentRecordUpdate(string picklistID, string packer, string packagecount,
                string weight, string weightum, string sessionID, out string Infobar, string userInitial = ""); 

        int PickPackShipPickListConfirmUpdate(string picklistID, string picker, string packLocation, out string Infobar, string userInitial = ""); 

        int PickPackShipPickListItemUpdate(string picklistID, string picklistLocation, string picklistItem,
                string picklistLot, string serNum, string packLoc, string location, string lot, string qty, out string Infobar, string picklistSequence, string userInitial = ""); 

        int PickPackShipShipmentConfirmUpdate(string shipmentID, out string Infobar, string userInitial = ""); 

        int PickPackShipShipmentPackagePack(string shipmentID, string packageID, string refPackageID, string packageType,
                string rateCode, string NMFC, string weight, string hazard, string description,
                string marksExcept, out string Infobar, string userInitial = ""); 

        int PickPackShipShipmentSeqPack(string shipmentID, string packQty, string lot, string serialNum, string item, string packageID,
                string packageType, string rateCode, string NMFC, string weight, string hazard, string description, out string Infobar, string userInitial = ""); 

        int PickPackShipShipmentUpdate(string shipmentID, string trackingNum, string proNum, string vehicleNum, string ship, string shipFrom, string parentContainerNum, out string infobar, string AutoPrintBOL, string userInitial = ""); 

        int RMAReturnTransaction(string whse, string rmaOrder, string line, string item, string qty, string sessionID, string location, string lot,
                string uom, string rtnToStock, string reasonCode, string workkey,
                string importDocId, string matlCost, string laborCost, string fovCost, string vovCost, string outCost, string containerNum,
                string documentNum, string site, string userInitials, string returnType, bool generateSerials, bool generateLot, bool addItemLocRecord,
                bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink, out string Infobar); 

        int TransferOrderShipUpdate(string order, string line, string qty, string item, string fromSite,
                string fromWhse, string fromLoc, string fromLot, string toWhse,
                string toLot, string toSite, string uom, string reasonCode, string transitLocation,
                bool addItemLocRecord, bool allowIfCycleCountExists,
                bool addPermanentItemWhseLocLink, string SessionID, out string Infobar, string allowZerocostItem, string userInitial); 

    }
}
    
