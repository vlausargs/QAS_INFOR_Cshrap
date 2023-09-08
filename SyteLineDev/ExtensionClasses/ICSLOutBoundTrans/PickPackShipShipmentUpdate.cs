using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;



namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    class PickPackShipShipmentUpdate : OutBoundUtilities
    {
        //Input Variables.
        string shipmentID = "";
        string trackingNum = "";
        string proNum = "";
        string vehicleNum = "";
        string ship = "";
        string shipFrom = "";
        string parentContainerNum = "";
        private string AutoPrintBOL = "0";
        private ICSLOutBoundTrans.SLDAL.SLShipmentsDAL DAL;
        private ICSLOutBoundTrans.SLDAL.SLCoitemShpsDAL DAL2;

        string errorMessage = ""; //added to keep track of the local error message.  On a error this 
        //  will be passed back to the calling method.  JH:20131217

        public PickPackShipShipmentUpdate()
        {//constructor.  initialize the object.
            initialize();

            //LogMessage("Init Complete");
        }

        //constructor overload that accepts all inputs and sets up the object in one step.
        public PickPackShipShipmentUpdate(string shipmentID, string trackingNum, string proNum, string vehicleNum, string ship,string shipFrom,string parentContainerNum, IIDOExtensionClassContext context, string AutoPrintBOL)
        {//constructor.  initialize the object.
            MessageLogging("PickPackShipShipmentUpdate: Constructor ", ICSLBase.msgLevel.l1_information);

            initialize();
            Context = context;
            setInputs(shipmentID, trackingNum, proNum, vehicleNum, ship, shipFrom, parentContainerNum,AutoPrintBOL);
        }


        public bool setInputs(string shipmentID, string trackingNum, string proNum, string vehicleNum, string ship, string shipFrom, string parentContainerNum,string AutoPrintBOL)
        {
            initialize();

            this.shipmentID = shipmentID;
            this.trackingNum = trackingNum;
            this.proNum = proNum;
            this.vehicleNum = vehicleNum;
            this.ship = ship;
            this.shipFrom = shipFrom;
            this.parentContainerNum = parentContainerNum;
            this.AutoPrintBOL = AutoPrintBOL;
            MessageLogging("PickPackShipShipmentUpdate: SetInputs complete ", msgLevel.l1_information);
            return true;
        }

        public void MessageTest(string msg)
        {

            //this.loggingLevel = msgLevel.l5_failure; //log warnings and above.
            //MessageLoging("PickPackShipShipmentUpdate: initialize complete: Allways ", 1200002, SLERPBase.msgLevel.l9_allways);
            //MessageLoging("PickPackShipShipmentUpdate: initialize complete: Fail ", 1200002, SLERPBase.msgLevel.l5_failure);
            //MessageLoging("PickPackShipShipmentUpdate: error msg  ", 1200002, SLERPBase.msgLevel.l4_error);
            MessageLogging("PickPackShipShipmentUpdate: Warning " + msg, msgLevel.l3_warning, 1200002);
        }
        public void initialize()
        {
            //Input variables initialization
            shipmentID = "";
            trackingNum = "";
            proNum = "";
            vehicleNum = "";
            ship = "";
            shipFrom = "";
            parentContainerNum = "";  
            errorMessage = "";
            AutoPrintBOL = "";
        }


        public bool formatInputs()
        {
           // shipmentID = queryRequest.GetFieldValue("shipmentID");
            if (shipmentID == "")
            {
                errorMessage = constructErrorMessage("shipmentID input mandatory", "PPSS0001", null);
                return false;
            }

            return true;
        }

        private bool validateInputs( )
        {
            bool retVal = true;

            return retVal;
        }

        public bool PerformUpdate(out string infobar)
        {//converted processMessage to collect PerformUpdate  JH:20130820
            infobar = "";
                     
            //initialize();

            if (formatInputs( ) == false)
            {
                infobar = errorMessage;
                return false;
            }

            validateInputs( );

            if (performUpdate() == false)
            {
                infobar = errorMessage;
                return false;
            }
            return true;
        }

        private bool performUpdate()
        {
            bool retVal = true;
            string msg = "";
            

            DAL = new ICSLOutBoundTrans.SLDAL.SLShipmentsDAL(this.Context);
            DAL2 = new ICSLOutBoundTrans.SLDAL.SLCoitemShpsDAL(this.Context);


            LoadCollectionResponseData DALResponseData = null;

            LoadCollectionRequestData DALRequest = null;

            DAL.ShipmentId = shipmentID;

            DALRequest = DAL.GetQueryRquest();

            DALResponseData = ExcuteQueryRequest(DALRequest);

            if (DALResponseData.Items.Count == 0)
            {
                constructErrorMessage("Shipment details not found", "PPSS0002", null);
                return false;
            }
            else if (DALResponseData[0, "Status"].Value.Equals("S"))                                   // MSF#175783  New vaidation check added to check the Shipment status 02/24/2014 Sdommata
            {
                errorMessage = "Shipments that have been shipped";
                return false;
            }

            if (ship.ToLower().Trim() == "no")
            {
                DAL.UbSelect = "1";
                DAL.Status = "R";
            }

            DAL.RowPointer = GetPropertyValue(DALResponseData, "RowPointer");
            DAL.RecordDate = GetPropertyValue(DALResponseData, "RecordDate");
            DAL.ShipmentId = shipmentID;

            DAL.TrackingNumber = trackingNum;
            DAL.ProNumber = proNum;
            DAL.VehNum = vehicleNum;
            DAL.ShipLoc = shipFrom;
            DAL.ParentContainerNum = parentContainerNum;

            msg = DAL.Update();

            if (msg != "")
            {
                errorMessage = msg;
                return false;
            }

            if (ship.ToLower().Trim() == "no")
            {
                return true;
            }

            DAL.ShipmentId = shipmentID;
            
            DAL.Curdate = System.DateTime.Now.ToString(WMLongDateTimePattern); // FTDEV-9195 - Adding Time to the date/time string passed into CSI - Untested
            DAL.IgnoreLCR = "0";
            DAL.IgnoreCount = "1"; // doubt

            msg = DAL.InvokeIDOMethod_ShipConfirmationSp();
            if (msg != "")
            {
                errorMessage = msg;
                return false;
            }

            DAL2.OnHandNegative = "0"; // doubt 
            DAL2.RecordsPosted = "0";
            msg = DAL2.InvokeIDOMethod_COShippingLoopSp();
            if (msg != "")
            {
                errorMessage = msg;
                return false;
            }

            msg = DAL2.InvokeIDOMethod_COShippingCleanupSp();
            if (msg != "")
            {
                errorMessage = msg;
                return false;
            }
            if (AutoPrintBOL == "1")
            {
                if (!string.IsNullOrEmpty(PrintBOL()) || !string.IsNullOrEmpty(PrintPackingSlip()))
                {
                    return false;
                }
            }
            return retVal;
        }

        private string PrintBOL()
        {
            string taskName = "ShipmentBillofLadingReport";
            StringBuilder taskParamBuilder = new StringBuilder();
            taskParamBuilder.Append($"SETVARVALUES(ShipmentStarting={shipmentID},ShipmentEnding={shipmentID}");
            taskParamBuilder.Append($", CustomerStarting=~LIT~(),CustomerEnding=~LIT~(),CustSeqStarting = ~LIT~()");
            taskParamBuilder.Append($", CustSeqEnding = ~LIT~(),PickupDateStarting = ~LIT~(),PickupDateEnding = ~LIT~()");
            taskParamBuilder.Append($", PickupDateStartingOffset = ~LIT~(), PickupDateEndingOffset = ~LIT~(), DisplayHeader = ~LIT~(1),pSite = ~LIT~({IDORuntime.Site}))");
            return PrintBOLAndPacking(taskName, taskParamBuilder.ToString());
        }

        private string PrintPackingSlip()
        { 
            string taskName = "ShipmentPackingSlipReport";
            StringBuilder taskParamBuilder = new StringBuilder();
            taskParamBuilder.Append($"SETVARVALUES(PrintBlankPickupDate=~LIT~(1), IncludeSerialNumbers=~LIT~(0), DisplayShipmentNotes = ~LIT~(0)");
            taskParamBuilder.Append($", PrintShipmentSeqNotes = ~LIT~(0), DisplayShipmentPackageNotes = ~LIT~(0), MinShipNum = {shipmentID}, MaxShipNum ={shipmentID}");
            taskParamBuilder.Append($", CustomerStarting = ~LIT~(), CustomerEnding = ~LIT~(), ShipToStarting = ~LIT~(), ShipToEnding = ~LIT~()");
            taskParamBuilder.Append($", PickupDateStarting = ~LIT~(), PickupDateEnding = ~LIT~(), PickupDateStartingOffset = ~LIT~()");
            taskParamBuilder.Append($", PickupDateEndingOffset = ~LIT~(), ShowInternal = ~LIT~(0), ShowExternal = ~LIT~(0), DisplayHeader = ~LIT~(1)");
            taskParamBuilder.Append($", UseProfile = ~LIT~(1), pSite = ~LIT~({IDORuntime.Site}), PrintDescription = ~LIT~(0), PrintHeaderOnAllPagesVar = ~LIT~(0)");
            taskParamBuilder.Append($", PageBetweenPackagesVar = ~LIT~(0), PrintCertificateOfConformanceVar = ~LIT~(0), PrintPackageWeightVar = ~LIT~(0)");
            taskParamBuilder.Append($", PrintDeliveryIncoTermsVar = ~LIT~(0), PrintEUDetailsVar = ~LIT~(0), PrintKitComponents = ~LIT~(0), PrintLotNumbersVar = ~LIT~(1))");
            return PrintBOLAndPacking(taskName, taskParamBuilder.ToString());
        }
        private string PrintBOLAndPacking(string taskName, string taskParms1)
        {
            string infoBar = string.Empty;
            object[] inputValues = new object[]{
                                                taskName,
                                                taskParms1,
                                                null,
                                                "",
                                                "",
                                                null,
                                                "en-US",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
            InvokeResponseData InvokeResponseData = InvokeIDO("SLJobQueues", "BGTaskSubmitSp", inputValues);
            if (!InvokeResponseData.ReturnValue.Equals("0"))
            {
                infoBar = constructErrorMessage(InvokeResponseData.Parameters.ElementAt(3).ToString(), "-2", null);
            }

            return infoBar;
        }
    }
}
