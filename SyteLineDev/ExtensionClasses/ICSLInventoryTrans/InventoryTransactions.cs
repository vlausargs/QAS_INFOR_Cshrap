using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.ExternalContracts.FactoryTrack;

namespace InforCollect.ERP.SL.ICSLInventoryTrans
{
    public class InventoryTransactions : FTKExtensionClassBase, IExtFTICSLInventoryTrans
    {
        private int retVal = -1;
        public int BuildContainer(string qty, string item, string site, string whse,
                                     string loc, string uom, string lot, bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, bool allowIfSlowMoving,
                                          string SerialsSessionID, string containerNum, out string Infobar, string userInitial)
        {
           
            BuildContainer buildContainer = new BuildContainer(qty, item, site, whse,
                                     loc, uom,lot, addItemLocRecord,allowIfCycleCountExists,
                                      addPermanentItemWhseLocLink, allowIfSlowMoving,SerialsSessionID,containerNum,  userInitial);

            //  The base class is initalized here rather than the derived class to avoid unintentionally clearing the context. 
            buildContainer.Initialize(); //Initilize the base class.             

            buildContainer.SetContext(this.Context);
            retVal = buildContainer.PerformUpdate(out Infobar);
            return retVal;
        }
        public int EmptyContainer (string qty, string containerNum, string emptyall, string item, string site,string lot,
                                          string whse, string loc, bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, string SerialsSessionID, out string Infobar, string userInitial)
        {
           
            EmptyContainer emptyContainer = new EmptyContainer(qty, containerNum, emptyall, item, site,lot, whse, loc, addItemLocRecord, allowIfCycleCountExists,addPermanentItemWhseLocLink,SerialsSessionID, userInitial);

            //  The base class is initalized here rather than the derived class to avoid unintentionally clearing the context. 
            emptyContainer.Initialize(); //Initilize the base class.             

            emptyContainer.SetContext(this.Context);
            retVal = emptyContainer.PerformUpdate(out Infobar);
            return retVal;
        }
        public int AdjustmentUpdate(string qty,string item,string site, string whse,
                                     string loc, string uom, string reasonCode,bool addItemLocRecord,
                                     bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink,
                                     string documentNumber, out string Infobar, string userInitial)
        {
                      
            AdjustmentUpdate adjustmentUpdate = new AdjustmentUpdate(qty, item, site, whse,
                                     loc, uom, reasonCode, addItemLocRecord,
                                      allowIfCycleCountExists, addPermanentItemWhseLocLink, documentNumber,  userInitial);

            //  The base class is initalized here rather than the derived class to avoid unintentionally clearing the context. 
            adjustmentUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103            

            adjustmentUpdate.SetContext(this.Context);                        
            retVal = adjustmentUpdate.PerformUpdate(out Infobar);
            return retVal;
        }

        public int TransferUpdate(string qty, string item, string fromSite,
                                   string fromWhse, string fromLoc, string fromLot, 
                                   string toWhse, string toLoc, string toLot,string toSite,
                                   string uom, bool addItemLocRecord, bool allowIfCycleCountExists,
                                   bool addPermanentItemWhseLocLink, string SerialsSessionID, out string Infobar, string containerNum, string userInitial, string docNum)
        {

            TransferUpdate transferUpdate = new TransferUpdate(qty, item, fromSite, fromWhse,
                                     fromLoc, fromLot, toWhse, toLoc, toLot, toSite, uom, addItemLocRecord,
                                      allowIfCycleCountExists, addPermanentItemWhseLocLink, SerialsSessionID, containerNum, userInitial, docNum);
            
            //The base class is initalized here rather than the derived class to avoid unintentionally clearing the context. 
            transferUpdate.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103            
            transferUpdate.SetContext(this.Context);
            var currentDateTime = DateTime.Now;
            var siteDateTime = GetSiteDate(currentDateTime,out Infobar);
            if(!string.IsNullOrEmpty(Infobar))
            {
                retVal = 16;
                return retVal;
            }
            transferUpdate.SiteDateTime = siteDateTime ?? currentDateTime;
            retVal = transferUpdate.PerformUpdate(out Infobar);
            return retVal;
        }

        public int MiscellaneousReceiptUpdate(string qty, string item, string site, string whse, string loc,
                                          string uom, string reasonCode, string lot, bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, bool allowIfSlowMoving, 
                                          string documentNumber,
                                          string SerialsSessionID, string ImportDocID, string ContainerNum, out string Infobar,string userInitial)
        {
            return MiscellaneousReceiptUpdateWithTransRestrict(qty, item, site, whse, loc,
                                           uom, reasonCode, lot, addItemLocRecord, allowIfCycleCountExists,
                                           addPermanentItemWhseLocLink, allowIfSlowMoving,
                                           documentNumber, SerialsSessionID, ImportDocID, ContainerNum, out Infobar, userInitial, "", "", "", "", "", "");


        }
        public int MiscellaneousReceiptUpdateWithTransRestrict(string qty, string item, string site, string whse, string loc,
                                        string uom, string reasonCode, string lot, bool addItemLocRecord, bool allowIfCycleCountExists,
                                        bool addPermanentItemWhseLocLink, bool allowIfSlowMoving,
                                        string documentNumber, string SerialsSessionID, string ImportDocID, string ContainerNum, out string Infobar, string userInitial,
                                        string LotMfgDate, string LotExpDate, string LotTrxRestrictCode, string SerialMfgDate, string SerialExpDate, string SerialTrxRestrictCode)
        {
            MiscellaneousReceiptUpdate miscellaneousReceiptUpdate = new MiscellaneousReceiptUpdate(qty, item, site, whse, loc,
                                          uom, reasonCode, lot, addItemLocRecord, allowIfCycleCountExists,
                                          addPermanentItemWhseLocLink, allowIfSlowMoving, documentNumber,
                                          SerialsSessionID, ImportDocID, ContainerNum, userInitial, LotMfgDate,
                                          LotExpDate, LotTrxRestrictCode, SerialMfgDate, SerialExpDate, SerialTrxRestrictCode);
            //The base class is initalized here rather than the derived class to avoid unintentionally clearing the context. 
            miscellaneousReceiptUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103            
            miscellaneousReceiptUpdate.SetContext(this.Context);

            retVal = miscellaneousReceiptUpdate.PerformUpdate(out Infobar);
            return retVal;
        }

        public int MiscellaneousIssueUpdate(string qty, string item, string site, string whse, string loc,
                                             string uom, string reasonCode, string lot, bool allowNegInventory, bool addItemLocRecord,
                                             bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink, string documentNumber,
                                             string SerialsSessionID, out string Infobar, string containerNum, string userInitial, string ImportDocID)
                                          
        {                      
            MiscellaneousIssueUpdate miscellaneousIssueUpdate = new MiscellaneousIssueUpdate(qty, item, site, whse, loc,
                                          uom, reasonCode, lot, allowNegInventory,addItemLocRecord, allowIfCycleCountExists,
                                          addPermanentItemWhseLocLink, documentNumber, SerialsSessionID,containerNum, userInitial,ImportDocID);
            //The base class is initalized here rather than the derived class to avoid unintentionally clearing the context. 
            miscellaneousIssueUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103            
            
            miscellaneousIssueUpdate.SetContext(this.Context);                       
            retVal = miscellaneousIssueUpdate.PerformUpdate(out Infobar);
            return retVal;
        }
    }
}
