using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;

using System.Xml;
using System.Diagnostics;
using CSI.ExternalContracts.FactoryTrack;

namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class OutBoundTransactions : ExtensionClassBase, IExtFTICSLOutBoundTrans
    {

        private int retVal = -1;
        public int CustomerOrderShippingUpdate(string order, String site,
                                            string whse, string stageLocation,
                                            bool allowIfCycleCountExists, string noOfDaysToDueDate,
                                            bool addPermanentItemWhseLocLink,
                                            out string InfoBar, string userInitial, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, string UbEsigUserName)
        {
            InfoBar = "";
            CustomerOrderShippingUpdate customerOrderShippingUpdate = new CustomerOrderShippingUpdate(order, site, whse, stageLocation, allowIfCycleCountExists,
                                      noOfDaysToDueDate, addPermanentItemWhseLocLink, UbEsigEncryptedPassword, UbEsigReasonCode, UbEsigRowPointer, UbEsigUserName);
            //  The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
            customerOrderShippingUpdate.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103                        
            customerOrderShippingUpdate.SetContext(this.Context);//set the context- This method is in the base class. JH:20140103
            customerOrderShippingUpdate.UpdateUserInitial(userInitial, out InfoBar);
            retVal = customerOrderShippingUpdate.PerformUpdate(out InfoBar);
            return retVal;

        }
        public int ManageCustomerOrderReservationsUpdate(string order, String line, String release, String qty,
                                                     String item, String site, string whse, String loc, String lot,
                                                     String uom, string stageLocation, String operationType,
                                            bool addItemLocRecord, bool allowIfCycleCountExists,
                                            bool addPermanentItemWhseLocLink, string SessionID, out string Infobar, string docNum, string userInitial)
        {
            Infobar = "";

            ManageCustomerOrderReservationsUpdate manageCustomerOrderReservationsUpdate = new ManageCustomerOrderReservationsUpdate(order, line, release, qty, item, site, whse,
                                                                                          loc, lot, uom, stageLocation, operationType, addItemLocRecord, allowIfCycleCountExists,
                                                                                          addPermanentItemWhseLocLink, SessionID, docNum, userInitial);
            //  The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
            manageCustomerOrderReservationsUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103                        

            manageCustomerOrderReservationsUpdate.SetContext(this.Context);
            manageCustomerOrderReservationsUpdate.UpdateUserInitial(userInitial, out Infobar);
            retVal = manageCustomerOrderReservationsUpdate.PerformUpdate(out Infobar);
            return retVal;
        }


        public int CustomerOrderPickAndShipUpdate(string order, String line, String release, String qty,
                                                   String item, String site, string whse, String loc, String lot,
                                                   String uom,
                                          bool addItemLocRecord, bool allowIfCycleCountExists,
                                          bool addPermanentItemWhseLocLink, string SessionID, string userInitial, bool allowNegInventory, out string Infobar, string docNum, string UbEsigEncryptedPassword, string UbEsigReasonCode, string UbEsigRowPointer, string UbEsigUserName, string containerNum = "")
        {
            Infobar = "";
            if (containerNum != "" && containerNum != null)
            {
                LoadCollectionResponseData containerResponseData = new LoadCollectionResponseData();
                ContainerFunctions containerFunctions = new ContainerFunctions(order, whse, containerNum);
                containerFunctions.SetContext(this.Context);
                containerResponseData = containerFunctions.GetCOByContainer(ref Infobar);
                if (!string.IsNullOrEmpty(Infobar) || containerResponseData.Items.Count() == 0)
                {
                    Infobar = "Not a Valid Container.";
                    retVal = 16;
                    return retVal;
                }
                for (int i = 0; i < containerResponseData.Items.Count(); i++)
                {
                    line = containerResponseData[i, "CoLine"].ToString();
                    release = containerResponseData[i, "CoRelease"].ToString();
                    qty = containerResponseData[i, "UbQtyToShp"].ToString();
                    item = containerResponseData[i, "Item"].ToString();
                    loc = containerResponseData[i, "UbLoc"].ToString();
                    uom = containerResponseData[i, "UM"].ToString();
                    lot = containerResponseData[i, "UbLot"].ToString();
                    whse = containerResponseData[i, "Whse"].ToString();
                    CustomerOrderPickAndShipUpdate customerOrderPickAndShipUpdate = new CustomerOrderPickAndShipUpdate(order, line, release, qty, item, site, whse,
                                                                                         loc, lot, uom, addItemLocRecord, allowIfCycleCountExists,
                                                                                         addPermanentItemWhseLocLink, SessionID, userInitial, allowNegInventory, docNum, UbEsigEncryptedPassword, UbEsigReasonCode, UbEsigRowPointer, UbEsigUserName, containerNum);
                    //  The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
                    customerOrderPickAndShipUpdate.Initialize();
                    customerOrderPickAndShipUpdate.SetContext(this.Context);
                    customerOrderPickAndShipUpdate.UpdateUserInitial(userInitial, out Infobar);
                    retVal = customerOrderPickAndShipUpdate.PerformUpdate(out Infobar);
                    if (retVal == 16)
                        return retVal;
                }
                return retVal;
            }
            else
            {
                CustomerOrderPickAndShipUpdate customerOrderPickAndShipUpdate = new CustomerOrderPickAndShipUpdate(order, line, release, qty, item, site, whse,
                                                                                          loc, lot, uom, addItemLocRecord, allowIfCycleCountExists,
                                                                                          addPermanentItemWhseLocLink, SessionID, userInitial, allowNegInventory, docNum, UbEsigEncryptedPassword, UbEsigReasonCode, UbEsigRowPointer, UbEsigUserName, containerNum);
                //  The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
                customerOrderPickAndShipUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103                        

                customerOrderPickAndShipUpdate.SetContext(this.Context);
                customerOrderPickAndShipUpdate.UpdateUserInitial(userInitial, out Infobar);
                retVal = customerOrderPickAndShipUpdate.PerformUpdate(out Infobar);
                return retVal;
            }
        }
        public int TransferOrderShipUpdate(string order, string line, string qty, string item, string fromSite,
                                           string fromWhse, string fromLoc, string fromLot, string toWhse,
                                           string toLot, string toSite, string uom, string reasonCode, string transitLocation,
                                           bool addItemLocRecord, bool allowIfCycleCountExists,
                                           bool addPermanentItemWhseLocLink, string SessionID, out string Infobar, string allowZerocostItem, string userInitial)
        {

            Infobar = "";
            TransferOrderShipUpdate transferOrderShipUpdate = new TransferOrderShipUpdate(order, line, qty, item, fromSite,
                                             fromWhse, fromLoc, fromLot, toWhse,
                                             toLot, toSite, uom, reasonCode, transitLocation,
                                             addItemLocRecord, allowIfCycleCountExists,
                                             addPermanentItemWhseLocLink, SessionID, allowZerocostItem, userInitial);
            //  The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
            transferOrderShipUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103                                   
            transferOrderShipUpdate.SetContext(this.Context);
            transferOrderShipUpdate.UpdateUserInitial(userInitial, out Infobar);
            retVal = transferOrderShipUpdate.PerformUpdate(out Infobar);
            return retVal;

        }
        public int RMAReturnTransaction(string whse, string rmaOrder, string line, string item, string qty, string sessionID, string location, string lot,
                                        string uom, string rtnToStock, string reasonCode, string workkey,
                                        string importDocId, string matlCost, string laborCost, string fovCost, string vovCost, string outCost, string containerNum,
                                        string documentNum, string site, string userInitials, string returnType, bool generateSerials, bool generateLot, bool addItemLocRecord,
                                        bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink, out string Infobar)
        {

            Infobar = "";
            RMAReturnTransaction returnRMATransaction = new RMAReturnTransaction(whse, rmaOrder, line, item, qty,
                                             sessionID, location, lot, uom, rtnToStock, reasonCode, workkey, importDocId, matlCost, laborCost, fovCost, vovCost, outCost, containerNum,
                                             documentNum, site, userInitials, returnType, generateSerials, generateLot, addItemLocRecord, allowIfCycleCountExists, addPermanentItemWhseLocLink);

            //  The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
            returnRMATransaction.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103                                   
            returnRMATransaction.SetContext(this.Context);
            returnRMATransaction.UpdateUserInitial(userInitials, out Infobar);
            retVal = returnRMATransaction.PerformUpdate(out Infobar);
            return retVal;

        }
        #region PickPackShip
        public int PickPackShipCreateShipmentRecordUpdate(string picklistID, string packer, string packagecount,
                                                      string weight, string weightum, string sessionID, out string Infobar, string userInitial = "")
        {
            Infobar = "";

            PickPackShipCreateShipmentRecordUpdate pickPackShipCreateShipmentRecordUpdate =
                                new PickPackShipCreateShipmentRecordUpdate(picklistID, packer, packagecount,
                                                       weight, weightum, sessionID);

            //  The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
            pickPackShipCreateShipmentRecordUpdate.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103                                   
            pickPackShipCreateShipmentRecordUpdate.SetContext(this.Context);
            pickPackShipCreateShipmentRecordUpdate.UpdateUserInitial(userInitial, out Infobar);
            retVal = pickPackShipCreateShipmentRecordUpdate.PerformUpdate(out Infobar);
            return retVal;

        }

        public int PickPackShipPickListConfirmUpdate(string picklistID, string picker, string packLocation, out string Infobar, string userInitial = "")
        {
            Infobar = "";

            PickPackShipPickListConfirmUpdate pickPackShipPickListConfirmUpdate =
                                new PickPackShipPickListConfirmUpdate(picklistID, picker, packLocation);
            //The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
            pickPackShipPickListConfirmUpdate.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103                                   
            pickPackShipPickListConfirmUpdate.SetContext(this.Context);
            pickPackShipPickListConfirmUpdate.UpdateUserInitial(userInitial, out Infobar);
            retVal = pickPackShipPickListConfirmUpdate.PerformUpdate(out Infobar);
            return retVal;

        }

        public int PickPackShipPickListItemUpdate(string picklistID, string picklistLocation, string picklistItem,
                                              string picklistLot, string serNum, string packLoc, string location, string lot, string qty, out string Infobar, string picklistSequence, string userInitial = "")
        {//added collect PickPackShipPickListItemUpdate update method.  JH:20130816

            Infobar = "";

            PickPackShipPickListItemUpdate pickPackShipPickListItemUpdate = new PickPackShipPickListItemUpdate();  //declare new object Calling the class constructor.
            //alternate way to set the parameters for a object.  JH:20130108
            pickPackShipPickListItemUpdate.setInputs(picklistID, picklistSequence, picklistLocation, picklistItem, picklistLot, location, lot, qty, serNum, packLoc);

            //The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
            pickPackShipPickListItemUpdate.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103                                   
            pickPackShipPickListItemUpdate.SetContext(Context);

            //set the pickPackShipPickListItemUpdate's context.
            //pickPackShipPickListItemUpdate.Context = this.Context; //SetContext(this.Context);            
            //pickPackShipPickListItemUpdate.Initialize(); //This tries to initalize the outboundtransaction class (same as above).
            pickPackShipPickListItemUpdate.UpdateUserInitial(userInitial, out Infobar);
            retVal = pickPackShipPickListItemUpdate.PerformUpdate(out Infobar);
            return retVal;

        }

        public int PickPackShipShipmentConfirmUpdate(string shipmentID, out string Infobar, string userInitial = "")
        {//added collect PickPackShipShipmentConfirmUpdate update method.  JH:20130819

            Infobar = "";

            PickPackShipShipmentConfirmUpdate pickPackShipShipmentConfirmUpdate = new PickPackShipShipmentConfirmUpdate();  //declare new object Calling the class constructor.
            pickPackShipShipmentConfirmUpdate.setInputs(shipmentID);

            pickPackShipShipmentConfirmUpdate.Initialize();
            pickPackShipShipmentConfirmUpdate.SetContext(Context);

            //set the pickPackShipPickListItemUpdate's context.
            //pickPackShipShipmentConfirmUpdate.Context = this.Context; //SetContext(this.Context);
            pickPackShipShipmentConfirmUpdate.UpdateUserInitial(userInitial, out Infobar);
            retVal = pickPackShipShipmentConfirmUpdate.PerformUpdate(out Infobar);
            return retVal;

        }


        public int PickPackShipShipmentPackagePack(string shipmentID, string packageID, string refPackageID, string packageType,
                              string rateCode, string NMFC, string weight, string hazard, string description,
                              string marksExcept, out string Infobar, string userInitial = "")
        {//added collect PickPackShipShipmentPackagePack update method.  JH:2013020

            Infobar = "";

            PickPackShipShipmentPackagePack pickPackShipShipmentPackagePack = new PickPackShipShipmentPackagePack();  //declare new object Calling the class constructor.
            pickPackShipShipmentPackagePack.setInputs(shipmentID, packageID, refPackageID, packageType,
                              rateCode, NMFC, weight, hazard, description,
                              marksExcept);

            pickPackShipShipmentPackagePack.Initialize();
            pickPackShipShipmentPackagePack.SetContext(Context);

            //set the pickPackShipPickListItemUpdate's context.
            //pickPackShipShipmentPackagePack.Context = this.Context; //SetContext(this.Context);            
            pickPackShipShipmentPackagePack.UpdateUserInitial(userInitial, out Infobar);
            return pickPackShipShipmentPackagePack.PerformUpdate(out Infobar);

        }

        public int PickPackShipShipmentSeqPack(string shipmentID, string packQty, string lot, string serialNum, string item, string packageID,
                              string packageType, string rateCode, string NMFC, string weight, string hazard, string description, out string Infobar, string userInitial = "")
        {//added collect PickPackShipShipmentConfirmUpdate update method.  JH:20130819
            Infobar = "";

            PickPackShipShipmentSeqPack pickPackShipShipmentSeqPack = new PickPackShipShipmentSeqPack(shipmentID, packQty, lot, serialNum, item, packageID,
                               packageType, rateCode, NMFC, weight, hazard, description, this.Context);  //declare new object Calling the class constructor.

            /* The explicate way to setup and call the object.
            PickPackShipShipmentSeqPack pickPackShipShipmentSeqPack = new PickPackShipShipmentSeqPack();  //declare new object Calling the class constructor.

            //set the pickPackShipPickListItemUpdate's context.
            pickPackShipShipmentSeqPack.Context = this.Context; //SetContext(this.Context);

            pickPackShipShipmentSeqPack.setInputs( shipmentID, packQty, lot, serialNum, item, packageID,  
                               packageType, rateCode, NMFC, weight,  hazard, description);
            */
            pickPackShipShipmentSeqPack.UpdateUserInitial(userInitial, out Infobar);
            return pickPackShipShipmentSeqPack.PerformUpdate(out Infobar);

        }


        public int PickPackShipShipmentUpdate(string shipmentID, string trackingNum, string proNum, string vehicleNum, string ship, string shipFrom, string parentContainerNum, out string infobar, string AutoPrintBOL, string userInitial = "")
        {//added collect PickPackShipShipmentUpdate method.  JH:20130821
            int retval = 0;

            //string infobar = "";

            PickPackShipShipmentUpdate pickPackShipShipmentUpdate = new PickPackShipShipmentUpdate(shipmentID, trackingNum, proNum, vehicleNum, ship, shipFrom, parentContainerNum, this.Context, AutoPrintBOL);

            /* The explicate way to setup and call the object.
            PickPackShipShipmentUpdate pickPackShipShipmentUpdate = new PickPackShipShipmentUpdate();  //declare new object Calling the class constructor.

            //set the pickPackShipPickListItemUpdate's context.
            pickPackShipShipmentUpdate.Context = this.Context; //SetContext(this.Context);

            pickPackShipShipmentUpdate.setInputs(shipmentID, trackingNum, proNum, vehicleNum, ship);
            */
            pickPackShipShipmentUpdate.UpdateUserInitial(userInitial, out infobar);
            pickPackShipShipmentUpdate.PerformUpdate(out infobar);

            if (infobar != "")
            {
                retval = 1;

            }
            return retval;
        }

        #endregion

        public void EventTest(string message)
        {
            PickPackShipShipmentUpdate pickPackShipShipmentUpdate = new PickPackShipShipmentUpdate();
            pickPackShipShipmentUpdate.Context = this.Context;
            pickPackShipShipmentUpdate.MessageTest(message);
        }

        public void EventTest1(string message)
        {
            string sSource; //should be global
            string sLog; //should be global
            string sEvent;

            sSource = "Event Testing :-)";
            sLog = "Infor Collect";   ///should be global
            sEvent = message; //the message displayed on the general tab


            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);
            //EventLog myNewLog = new EventLog();
            //myNewLog.MaximumKilobytes = 512;


            //EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Error, 999);
            //EventLog.WriteEntry(sSource, "Failure: " + sEvent, EventLogEntryType.FailureAudit, 900);
            //EventLog.WriteEntry(sSource, "Success: " + sEvent, EventLogEntryType.SuccessAudit, 100);

            //Console.WriteLine("Finish event test");
        }
    }
}