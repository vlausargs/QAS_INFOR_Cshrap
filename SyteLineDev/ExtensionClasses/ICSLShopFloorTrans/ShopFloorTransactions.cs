using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using InforCollect.ERP.SL.ICSLShopFloorTrans.Labor;
using System.Diagnostics; //added to allow message handling
using CSI.ExternalContracts.FactoryTrack;
using CSI.Logistics.WarehouseMobility;
using CSI.MG;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    [IDOExtensionClass("ICSLShopFloorTrans")]
    public class ShopFloorTransactions : FTKExtensionClassBase, IExtFTICSLShopFloorTrans
    {
        private int retval = -1;
        private string WMTimePattern = "HH:mm:ss.fff"; // FTDEV-9195 - Adding Time to the date/time string passed into CSI
        public DataTable dtSerials;

        public int JobMaterialIssueUpdate(string job, string suffix, string operation, string sequence, string qty,
                              string item, string site, string whse, string loc, string lot, string uom,
                              bool addItemLocRecord, bool allowIfCycleCountExists,
                              bool addPermanentItemWhseLocLink, bool issueNewMaterial,
                              bool processAsByProduct, string otherAcct,
                              string otherAcctUnit1, string otherAcctUnit2,
                              string otherAcctUnit3, string otherAcctUnit4,
                              string materialCost, string SessionID, out string InfoBar, string docNum,
                              string JobLot = "", string JobSerial = "",
                              string containerNum = "", string userInitial = "")
        {
            return JobMaterialIssueUpdateNew(job, suffix, operation, sequence, qty, item, site, whse, loc, lot, uom,
                                             addItemLocRecord, allowIfCycleCountExists, addPermanentItemWhseLocLink, issueNewMaterial,
                                             processAsByProduct, otherAcct,
                                             otherAcctUnit1, otherAcctUnit2,
                                             otherAcctUnit3, otherAcctUnit4,
                                             materialCost, SessionID, out InfoBar, docNum,
                                             JobLot, JobSerial,
                                             containerNum, userInitial, "");
        }

        public int JobMaterialIssueUpdateNew(string job, string suffix, string operation, string sequence, string qty,
                                      string item, string site, string whse, string loc, string lot, string uom,
                                      bool addItemLocRecord, bool allowIfCycleCountExists,
                                      bool addPermanentItemWhseLocLink, bool issueNewMaterial,
                                      bool processAsByProduct, string otherAcct,
                                      string otherAcctUnit1, string otherAcctUnit2,
                                      string otherAcctUnit3, string otherAcctUnit4,
                                      string materialCost, string SessionID, out string InfoBar, string docNum,
                                      string JobLot = "", string JobSerial = "", 
                                      string containerNum = "", string userInitial = "",
                                      string serialsDataXML= "")
        {
            InfoBar = "";

            if (containerNum != "" && containerNum != null && processAsByProduct == false)
            { // Job material Issue By Container                
                LoadCollectionResponseData containerResponseData = new LoadCollectionResponseData();
                ContainerFunctions containerFunctions = new ContainerFunctions(site, job, suffix, item, whse, containerNum, InfoBar);
                containerFunctions.SetContext(this.Context);
                containerResponseData = containerFunctions.GetJobMatlsByContainer();
                int count = containerResponseData.Items.Count();
                if (count == 0)
                {
                    InfoBar = "Container contains Items not found on the Job";
                    retval = 16;
                    return retval;
                }
                //FTDEV-17020 added to check BOM materials and Item Material are same 
                if (!containerFunctions.CheckContainerAndJobItems(containerResponseData, out InfoBar))
                {
                    retval = 16;
                    return retval;
                }
                var currentDateTime = DateTime.Now;
                var siteDateTime = GetSiteDate(currentDateTime, out InfoBar);
                if (!string.IsNullOrWhiteSpace(InfoBar))
                {
                    retval = 16;
                    return retval;
                }                
                LoadCollectionResponseData serialLoadResponce;
                string errorMessageSerial = "";
                dtSerials = new DataTable();
                DataRow datarow;
                int icontainerqty = 0;
                dtSerials.Columns.Add("Serial", typeof(string));
                dtSerials.Columns.Add("Item", typeof(string));
                dtSerials.Columns.Add("Loc", typeof(string));
                dtSerials.Columns.Add("Lot", typeof(string));
                dtSerials.Columns.Add("QtyContained", typeof(int));
                for (int iCon = 0; iCon < count; iCon++)
                {
                    if (containerResponseData[iCon, "DerItemSerialTracked"].ToString() == "1")
                    {
                        serialLoadResponce = new LoadCollectionResponseData();
                        serialLoadResponce = containerFunctions.SerialLoadSpByContainer("T", containerResponseData[iCon, "Item"].ToString(), whse, containerResponseData[iCon, "DerLoc"].ToString(),
                                                                            containerResponseData[iCon, "DerLot"].ToString(), "", "", "", "", "",
                                                                           job, "0", suffix, site, "",
                                                                           "", containerNum, containerResponseData[iCon, "UbStartingSerial"].ToString(), containerResponseData[iCon, "UbEndingSerial"].ToString(), out errorMessageSerial);

                        if (string.IsNullOrEmpty(errorMessageSerial) && serialLoadResponce != null && serialLoadResponce.Items.Count > 0)
                        {
                            icontainerqty = containerFunctions.GetContainerQtyCount(containerNum, containerResponseData[iCon, "Item"].ToString(), containerResponseData[iCon, "DerLot"].ToString()); 
                            for (int iresponse = 0; iresponse < serialLoadResponce.Items.Count; iresponse++)
                            {
                                datarow = dtSerials.NewRow();
                                datarow["Serial"] = serialLoadResponce[iresponse, "SerNum"].ToString();
                                datarow["Item"] = containerResponseData[iCon, "Item"].ToString();
                                datarow["Loc"] = containerResponseData[iCon, "DerLoc"].ToString();
                                datarow["Lot"] = containerResponseData[iCon, "DerLot"].ToString();
                                datarow["QtyContained"] = icontainerqty.ToString();                                
                                dtSerials.Rows.Add(datarow);
                            }
                        }
                    }
                }
               for (int i = 0; i < count; i++)
                {
                    operation = containerResponseData[i, "OperNum"].ToString();
                    sequence = containerResponseData[i, "Sequence"].ToString();
                    qty = containerResponseData[i, "DerQtyConv"].ToString();
                    item = containerResponseData[i, "Item"].ToString();
                    loc = containerResponseData[i, "DerLoc"].ToString();
                    uom = containerResponseData[i, "UM"].ToString();
                    lot = containerResponseData[i, "DerLot"].ToString();

                    JobMaterialIssueUpdate jobMaterialIssueUpdate = new JobMaterialIssueUpdate(job, suffix, operation, sequence, qty,
                                      item, site, whse, loc, lot, uom,
                                      addItemLocRecord, allowIfCycleCountExists,
                                      addPermanentItemWhseLocLink, issueNewMaterial,
                                      processAsByProduct, otherAcct, otherAcctUnit1, otherAcctUnit2,
                                      otherAcctUnit3, otherAcctUnit4, materialCost, SessionID, docNum, JobLot,
                                      JobSerial, containerNum, containerResponseData[i, "UbStartingSerial"].ToString(),
                                      containerResponseData[i, "UbEndingSerial"].ToString(), dtSerials, serialsDataXML);
                    jobMaterialIssueUpdate.Initialize();
                    jobMaterialIssueUpdate.SetContext(this.Context);
                    jobMaterialIssueUpdate.SiteDateTime = siteDateTime ?? currentDateTime;
                    jobMaterialIssueUpdate.UpdateUserInitial(userInitial, out InfoBar);
                    retval = jobMaterialIssueUpdate.PerformUpdate(out InfoBar);
                    if (retval == 16)
                        return retval;
                }
                return retval;

            }
            else
            {
                // Regular Job material issue with out container
                JobMaterialIssueUpdate jobMaterialIssueUpdate = new JobMaterialIssueUpdate(job, suffix, operation, sequence, qty,
                                          item, site, whse, loc, lot, uom,
                                          addItemLocRecord, allowIfCycleCountExists,
                                          addPermanentItemWhseLocLink, issueNewMaterial,
                                          processAsByProduct, otherAcct, otherAcctUnit1, otherAcctUnit2,
                                          otherAcctUnit3, otherAcctUnit4, materialCost, SessionID, docNum, JobLot, 
                                          JobSerial, containerNum, "", "",null, serialsDataXML);  //the constructor handles initializing the derived class.
                //  The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
                jobMaterialIssueUpdate.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103                        
                jobMaterialIssueUpdate.SetContext(this.Context);//set the context- This method is in the base class. JH:20140103

                //--> jobMaterialIssueUpdate.setlogginglevel(10); //set logging level to log information and above.
                jobMaterialIssueUpdate.UpdateUserInitial(userInitial, out InfoBar);
                var currentDateTime = DateTime.Now;
                var siteDateTime = GetSiteDate(currentDateTime, out InfoBar);                
                if (!string.IsNullOrWhiteSpace(InfoBar))
                {
                    retval = 16;
                    return retval;
                }               
                jobMaterialIssueUpdate.SiteDateTime = siteDateTime ?? currentDateTime;
                retval = jobMaterialIssueUpdate.PerformUpdate(out InfoBar);
                return retval;
            }
        }
        public int JobMaterialRapidEntryUpdate(string job, string suffix, string whse, string site, string materialXML, bool addItemLocRecord, bool allowIfCycleCountExists,
                                                bool addPermanentItemWhseLocLink,  string docNum, out string InfoBar, out string transStatus, string JobLot = "", string JobSerial = "",string userInitial="")
        {
            JobMaterialRapidEntryUpdate jobMaterialIssueEntry = new JobMaterialRapidEntryUpdate(job, suffix, whse, site, materialXML, addItemLocRecord, allowIfCycleCountExists,
                                                                                                addPermanentItemWhseLocLink, docNum, JobLot, JobSerial);
            jobMaterialIssueEntry.Initialize();                   
            jobMaterialIssueEntry.SetContext(this.Context);
            //--> jobMaterialIssueUpdate.setlogginglevel(10); //set logging level to log information and above.
            jobMaterialIssueEntry.UpdateUserInitial(userInitial, out InfoBar);
            var currentDateTime = DateTime.Now;
            var siteDateTime = GetSiteDate(currentDateTime, out InfoBar);
            if (!string.IsNullOrWhiteSpace(InfoBar))
            {
               transStatus = string.Empty;
               return 16;
            }
            jobMaterialIssueEntry.SiteDateTime = siteDateTime ?? currentDateTime;
            retval = jobMaterialIssueEntry.PerformUpdate(out InfoBar, out transStatus);
            return retval;
        }
        public int ReportProductionUpdate(string job, string suffix, string qty,
                                     string item, string site, string whse, string loc, string uom, string lot,
                                     bool generateSerials, bool generateLot, string documentNo,
                                     bool addItemLocRecord, bool allowIfCycleCountExists,
                                     bool addPermanentItemWhseLocLink, bool overRideQtyPrompt,
                                     string SessionID, out string InfoBar, string containerNum, string userInitial = "")
        {
            ReportProductionUpdate ReportProductionUpdate = new ReportProductionUpdate(job, suffix, qty,
                                      item, site, whse, loc, uom, lot,
                                      generateSerials, generateLot, documentNo,
                                      addItemLocRecord, allowIfCycleCountExists,
                                      addPermanentItemWhseLocLink, overRideQtyPrompt,
                                      SessionID, containerNum); //the constructor handles initializing the derived class.            
            //  The base class is initalized here rather than in the derived class to avoid unintentionally clearing the context. 
            ReportProductionUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103                       
            ReportProductionUpdate.SetContext(this.Context);//set the context- This method is in the base class. JH:20140103
            //--> ReportProductionUpdate.setlogginglevel("INFORMATION"); //set logging level to log information and above.
            ReportProductionUpdate.UpdateUserInitial(userInitial, out InfoBar);
            retval = ReportProductionUpdate.PerformUpdate(out InfoBar);
            return retval;
        }

        public int WorkCenterMaterialIssueUpdate(string workcenter, string employee, string qty, string item, string site,
                                     string whse, string loc, string lot, string uom,
                                     bool allowNegInventory, bool allowIfCycleCountExists,
                                     bool addPermanentItemWhseLocLink,
                                     string SessionID, out string InfoBar, string containerNum, string docNum, string userInitial = "")
        {
            WorkCenterMaterialIssueUpdate workCenterMaterialIssueUpdate = new WorkCenterMaterialIssueUpdate(workcenter, employee, qty, item, site,
                                       whse, loc, lot, uom,
                                      allowNegInventory, allowIfCycleCountExists,
                                      addPermanentItemWhseLocLink, SessionID, containerNum, docNum); //the constructor handles initializing the derived class.

            workCenterMaterialIssueUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103

            workCenterMaterialIssueUpdate.SetContext(this.Context); //set the context- This method is in the base class. JH:20140103
            workCenterMaterialIssueUpdate.UpdateUserInitial(userInitial, out InfoBar);
            retval = workCenterMaterialIssueUpdate.PerformUpdate(out InfoBar);
            return retval;
        }

        public int JITProductionUpdate(string qty, string item, string site, string whse, string loc,
                                    string uom, string lot, string vendorLot, string shift, string employee,
                                    bool generateSerials, bool generateLot,
                                    bool addItemLocRecord, bool allowIfCycleCountExists,
                                    bool addPermanentItemWhseLocLink, string SessionID, out string InfoBar, string containerNum, string docNum, string userInitial = "")
        {
            JITProductionUpdate jitProductionUpdate = new JITProductionUpdate(qty, item, site, whse, loc,
                                     uom, lot, vendorLot, shift, employee,
                                     generateSerials, generateLot,
                                     addItemLocRecord, allowIfCycleCountExists,
                                     addPermanentItemWhseLocLink, SessionID, containerNum, docNum);  //the constructor handles initializing the derived class.

            //jitProductionUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103
            jitProductionUpdate.SetContext(this.Context); //set the context- This method is in the base class. JH:20140103
            jitProductionUpdate.UpdateUserInitial(userInitial, out InfoBar);
            retval = jitProductionUpdate.PerformUpdate(out InfoBar);
            return retval;
        }

        public int MoveUpdateWithScrapedQty(string job, string suffix, string oper, string deviceId, string transDate, string qtyCompleted,
                        string qtyScrapped, string qtyMoved, string uom, string reasonCode, bool operComplete, bool closeJob, string lot,
                        string loc, string whse, string site, string userInitials,
                        bool addItemLocRecord, bool allowIfCycleCountExists,
                        bool addPermanentItemWhseLocLink, bool generateSerials, string SessionID, out string InfoBar, string containerNum, bool issueToParentInput, string postingFlag, ref string TransNum, string NextOper)
        {

            InfoBar = "";

            if (TransNum == null || TransNum.Equals(""))
            {
                TransNum = "";
            }
            string[] strqtyScrapped = qtyScrapped.Split('~');
            string[] strreasonCode = reasonCode.Split('~');
            for (int icnt = 0; icnt < strreasonCode.Length; icnt++)
            {
                MoveUpdate moveUpdate = new MoveUpdate(job, suffix, oper, deviceId, transDate, qtyCompleted,
                                  strqtyScrapped[icnt], qtyMoved, uom, strreasonCode[icnt], operComplete, closeJob, lot,
                                 loc, whse, site, userInitials,
                                addItemLocRecord, allowIfCycleCountExists,
                                addPermanentItemWhseLocLink, generateSerials, SessionID, containerNum, issueToParentInput, NextOper); //the constructor handles initializing the derived class.

                moveUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103
                moveUpdate.SetContext(this.Context); //set the context- This method is in the base class. JH:20140103
                moveUpdate.PostingFlag = postingFlag;
                moveUpdate.UpdateUserInitial(userInitials, out InfoBar);
                moveUpdate.TransNum = TransNum;
                retval = moveUpdate.PerformUpdate(out InfoBar);
                if (moveUpdate.returnUpdateItem != null)
                {
                    TransNum = moveUpdate.returnUpdateItem.Properties.ElementAt(0).Value;
                }
                if (retval != 0)
                    break;
            }
            return retval;
        }
        public int MoveUpdate(string job, string suffix, string oper, string deviceId, string transDate, string qtyCompleted,
                          string qtyScrapped, string qtyMoved, string uom, string reasonCode, bool operComplete, bool closeJob, string lot,
                          string loc, string whse, string site, string userInitials,
                          bool addItemLocRecord, bool allowIfCycleCountExists,
                          bool addPermanentItemWhseLocLink, bool generateSerials, string SessionID, out string InfoBar, string containerNum, bool issueToParentInput, string postingFlag, ref string TransNum, string NextOper)
        {
            if (TransNum == null || TransNum.Equals(""))
            {
                TransNum = "";
            }
            transDate += " " + System.DateTime.Now.ToString(WMTimePattern); // FTDEV-9195 - TODO: This needs to be re-done to accept time sent from the front end. The front end doesn't currently send time, so we're using the current time on the CSI backend to make each trandate time combination unique to the transaction, per the requirement in the Jira.
            MoveUpdate moveUpdate = new MoveUpdate(job, suffix, oper, deviceId, transDate, qtyCompleted,
                              qtyScrapped, qtyMoved, uom, reasonCode, operComplete, closeJob, lot,
                             loc, whse, site, userInitials,
                            addItemLocRecord, allowIfCycleCountExists,
                            addPermanentItemWhseLocLink, generateSerials, SessionID, containerNum, issueToParentInput, NextOper); //the constructor handles initializing the derived class.

            moveUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103
            moveUpdate.SetContext(this.Context); //set the context- This method is in the base class. JH:20140103
            moveUpdate.PostingFlag = postingFlag;
            moveUpdate.UpdateUserInitial(userInitials, out InfoBar);
            moveUpdate.TransNum = TransNum;
            retval = moveUpdate.PerformUpdate(out InfoBar);
            if (moveUpdate.returnUpdateItem != null)
            {
                TransNum = moveUpdate.returnUpdateItem.Properties.ElementAt(0).Value;
            }
            return retval;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int JobMoveUpdate(string job, string suffix, string oper, string deviceId, string transDate,
            string qtyCompleted, string qtyScrapped, string qtyMoved, string uom, string reasonCode, bool operComplete,
            bool closeJob, string lot, string loc, string whse, string site, string userInitials, bool addItemLocRecord,
            bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink, bool generateSerials, string SessionID,
            out string InfoBar, string containerNum, bool issueToParentInput, string postingFlag, ref string TransNum,
            string employee, bool reverserQty, string scrapDataXML, string backflushLotsDataXML,
            string backflushSerialsDataXML, string endItemSerialsDataXML, string coproductDataXML)
        {
            string emptyXmlObject = "<LoadCollection Name=\"Empty\" LoadCap=\"0\"><PropertyList><lot /></PropertyList><LoadType>FIRST</LoadType><RecordCap>-1</RecordCap><Filter /><OrderBy /><PostQueryCmd /><Items /><MoreItems>false</MoreItems></LoadCollection>";
            if (TransNum == null || TransNum.Equals(""))
            {
                TransNum = "";
            }
            if (String.IsNullOrEmpty(scrapDataXML))
            {
                scrapDataXML = emptyXmlObject;
            }
            if (String.IsNullOrEmpty(backflushLotsDataXML))
            {
                backflushLotsDataXML = emptyXmlObject;
            }
            if (String.IsNullOrEmpty(backflushSerialsDataXML))
            {
                backflushSerialsDataXML = emptyXmlObject;
            }
            if (String.IsNullOrEmpty(endItemSerialsDataXML))
            {
                endItemSerialsDataXML = emptyXmlObject;
            }
            if (String.IsNullOrEmpty(coproductDataXML))
            {
                coproductDataXML = emptyXmlObject;
            }
            JobMoveUpdate jobMoveUpdate = new JobMoveUpdate(
                job, suffix, oper, deviceId, transDate, qtyCompleted, qtyScrapped, qtyMoved, uom, reasonCode,
                operComplete, closeJob, lot, loc, whse, site, userInitials, addItemLocRecord, allowIfCycleCountExists,
                addPermanentItemWhseLocLink, generateSerials, SessionID, containerNum, issueToParentInput, employee,
                reverserQty, scrapDataXML, backflushLotsDataXML, backflushSerialsDataXML, endItemSerialsDataXML, coproductDataXML);

            jobMoveUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103
            jobMoveUpdate.SetContext(this.Context); //set the context- This method is in the base class. JH:20140103
            jobMoveUpdate.PostingFlag = postingFlag;
            jobMoveUpdate.UpdateUserInitial(userInitials, out _);
            jobMoveUpdate.TransNum = TransNum;
            retval = jobMoveUpdate.PerformUpdate(out InfoBar);
            if (jobMoveUpdate.returnUpdateItem != null)
            {
                TransNum = jobMoveUpdate.returnUpdateItem.Properties.ElementAt(0).Value;
            }
            return retval;
        }


        public int PSUpdate(string item, string prodschedule, string workcenter,
                                      string operation, string site, string whse, string qty, string uom, string loc, string lot, string employee,
                                      string shift, string vendorLot, bool generateSerials, bool generateLot, bool addItemLocRecord,
                                      bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink,
                                      string qtyRej, string reasonCode,
                                      string SessionID, out string InfoBar, string containerNum, string docNum, string userInitial = "")
        {
            return PSUpdateWithTransRestrict(item, prodschedule, workcenter, operation,
                                      site, whse, qty, uom, loc, lot, employee,
                                      shift, vendorLot, generateSerials, generateLot,
                                      addItemLocRecord, allowIfCycleCountExists,
                                      addPermanentItemWhseLocLink, qtyRej, reasonCode, SessionID, out InfoBar, containerNum, docNum,
                                      userInitial, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }
        public int PSUpdateWithTransRestrict(string item, string prodschedule, string workcenter,
                                      string operation, string site, string whse, string qty, string uom, string loc, string lot, string employee,
                                      string shift, string vendorLot, bool generateSerials, bool generateLot, bool addItemLocRecord,
                                      bool allowIfCycleCountExists, bool addPermanentItemWhseLocLink,
                                      string qtyRej, string reasonCode,
                                      string SessionID, out string InfoBar, string containerNum, string docNum, string userInitial = "",
                                      string LotMfgDate = "", string LotExpDate = "", string LotTrxRestrictCode = "", 
                                      string SerialMfgDate = "", string SerialExpDate = "", string SerialTrxRestrictCode = "")
        {
            PSUpdate PSUpdate = new PSUpdate(item, prodschedule, workcenter, operation,
                                      site, whse, qty, uom, loc, lot, employee,
                                      shift, vendorLot, generateSerials, generateLot,
                                      addItemLocRecord, allowIfCycleCountExists,
                                      addPermanentItemWhseLocLink, qtyRej, reasonCode, SessionID, containerNum, docNum,
                                      LotMfgDate,LotExpDate, LotTrxRestrictCode, SerialMfgDate, SerialExpDate, SerialTrxRestrictCode); //the constructor handles initializing the derived class.

            PSUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103
            PSUpdate.SetContext(this.Context);//set the context- This method is in the base class. JH:20140103
            PSUpdate.UpdateUserInitial(userInitial, out InfoBar);
            retval = PSUpdate.PerformUpdate(out InfoBar);

            return retval;
        }
        public int PSScrapUpdate(string item, string prodschedule, string workcenter,
                                      string operation, string site, string whse, string qty, string uom, string employee,
                                      string shift, string reasonCode,
                                      string SessionID, out string InfoBar, string userInitial = "")
        {
            PSScrapUpdate PSScrapUpdate = new PSScrapUpdate(item, prodschedule, workcenter, operation,
                                      site, whse, qty, uom, employee,
                                      shift, reasonCode, SessionID); //the constructor handles initializing the derived class.

            PSScrapUpdate.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103
            PSScrapUpdate.SetContext(this.Context);//set the context- This method is in the base class. JH:20140103
            PSScrapUpdate.UpdateUserInitial(userInitial, out InfoBar);
            retval = PSScrapUpdate.PerformUpdate(out InfoBar);
            return retval;
        }

        public int TASLJobUpload(string inputJobXML, out string InfoBar)
        {//Needed?
         //initalize();
            TASLJobUpload slUpdate = new TASLJobUpload(inputJobXML);
            slUpdate.SetContext(this.Context);
            slUpdate.Initialize();
            return slUpdate.PerformUpdate(out InfoBar);
            //InfoBar = "";
            //return 0;

        }

        public int LaborUpload(string inputJobXML, out string InfoBar)
        {
            LaborUpload laborUpdate = new LaborUpload(this.Context, inputJobXML);
            return laborUpdate.PerformUpdate(out InfoBar);
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int TASLLaborUpload(string inputJobXML, out string InfoBar)
        {
            TASLLaborUpload laborUpdate = new TASLLaborUpload(this.Context, inputJobXML);
            return laborUpdate.PerformUpdate(out InfoBar);
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTLaborUpload(string inputJobXML, string PreserveSessionData, out string InfoBar)
        {
            
            FTLaborUpload laborUpdate = new FTLaborUpload(this.Context, inputJobXML);
            return laborUpdate.PerformUpdate(PreserveSessionData, out InfoBar);
        }

        public int LaborCompleteOperUpload(string inputJobXML, out string InfoBar)
        {
           
            LaborUpdateJobCompleteOpeStatus laborCompleUpdate = new LaborUpdateJobCompleteOpeStatus(this.Context, inputJobXML);
            return laborCompleUpdate.PerformUpdate(out InfoBar);
        }

        public int WorkCenterLaborUpdate(string employee, string workCenter, string shift, string transDate,
                                     string startTime, string endTime, double totalHours, bool reportMachineTime, out string InfoBar)
        {

           
            WorkCenterLaborUpdate workCenterLaborUpdate = new WorkCenterLaborUpdate(employee, workCenter, shift, transDate, startTime, endTime, totalHours, reportMachineTime); //the constructor handles initializing the derived class.
            workCenterLaborUpdate.Initialize(); //Initilize the base class.  Setup any necessary base class variables. JH:20140103
            workCenterLaborUpdate.SetContext(this.Context); //set the context- This method is in the base class. JH:20140103
            retval = workCenterLaborUpdate.PerformUpdate(out InfoBar);
            return retval;

        }

        public int WorkCenterMachineUpdate(string employee, string workCenter, string shift, string transDate,
                                     string startTime, string endTime, double totalHours, out string InfoBar)
        {

           
            WorkCenterMachineUpdate workCenterMachineUpdate = new WorkCenterMachineUpdate(employee, workCenter, shift, transDate, startTime, endTime, totalHours); //the constructor handles initializing the derived class.
            workCenterMachineUpdate.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103
            workCenterMachineUpdate.SetContext(this.Context); //set the context- This method is in the base class. JH:20140103
            retval = workCenterMachineUpdate.PerformUpdate(out InfoBar);
            return retval;
        }



        public int ProjectMaterialIssueUpdate(string projNum, string task, string sequence, string qty, string item,
                                      string itemDesc, string site, string whse, string loc, string lot, string uom,
                                      string costCode, bool addItemLocRecord, bool allowIfCycleCountExists,
                                      bool addPermanentItemWhseLocLink, bool issueNewMaterial,
                                      string otherAcct,
                                      string otherAcctUnit1, string otherAcctUnit2,
                                      string otherAcctUnit3, string otherAcctUnit4,
                                      string nonInvCost, out string InfoBar, string SessionID, string containerNum, string docNum, string userInitial)
        {
           
            ProjectMaterialIssueUpdate projectMaterialIssueUpdate = new ProjectMaterialIssueUpdate(projNum, task, sequence, qty, item,
                                    itemDesc, site, whse, loc, lot, uom, costCode, addItemLocRecord, allowIfCycleCountExists,
                                    addPermanentItemWhseLocLink, issueNewMaterial, otherAcct, otherAcctUnit1, otherAcctUnit2,
                                    otherAcctUnit3, otherAcctUnit4, nonInvCost, SessionID, containerNum, docNum);

            projectMaterialIssueUpdate.Initialize();
            projectMaterialIssueUpdate.SetContext(this.Context);
            projectMaterialIssueUpdate.UpdateUserInitial(userInitial, out InfoBar);

            retval = projectMaterialIssueUpdate.PerformUpdate(out InfoBar);
            return retval;
            //}
        }




        public void EventTest(string message)
        {
            ReportProductionUpdate ReportProductionUpdate = new ReportProductionUpdate();
            ReportProductionUpdate.Context = this.Context;
            ReportProductionUpdate.MessageTest(message);
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

        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTClearSessionTablesSp(Guid? SessionID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTClearSessionTablesExt = new FTTTClearSessionTablesFactory().Create(appDb);

                int Severity = iFTTTClearSessionTablesExt.FTTTClearSessionTablesSp(SessionID);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTGenerateOutputAndTidySp(Guid? SessionID,
                                               byte? PreserveSession,
                                               ref string OutputXmlString,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTGenerateOutputAndTidyExt = new FTTTGenerateOutputAndTidyFactory().Create(appDb);

                int Severity = iFTTTGenerateOutputAndTidyExt.FTTTGenerateOutputAndTidySp(SessionID,
                                                                                         PreserveSession,
                                                                                         ref OutputXmlString,
                                                                                         ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTInitializeSp(string ERPString,
                                    ref Guid? ReturnSessionID,
                                    ref int? ReturnHeaderRowCount,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTInitializeExt = new FTTTInitializeFactory().Create(appDb);

                int Severity = iFTTTInitializeExt.FTTTInitializeSp(ERPString,
                                                                   ref ReturnSessionID,
                                                                   ref ReturnHeaderRowCount,
                                                                   ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTInsertJobSp(Guid? SessionID,
                                   int? HeaderRow,
                                   ref string start_dateStr,
                                   ref string end_dateStr,
                                   ref string emp_num,
                                   ref int? NumOfRecords)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTInsertJobExt = new FTTTInsertJobFactory().Create(appDb);

                int Severity = iFTTTInsertJobExt.FTTTInsertJobSp(SessionID,
                                                                 HeaderRow,
                                                                 ref start_dateStr,
                                                                 ref end_dateStr,
                                                                 ref emp_num,
                                                                 ref NumOfRecords);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FTTTProcessBadRecordSp(Guid? SessionID,
                                          decimal? TransNum,
                                          string ErrorMsg,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iFTTTProcessBadRecordExt = new FTTTProcessBadRecordFactory().Create(appDb);

                int Severity = iFTTTProcessBadRecordExt.FTTTProcessBadRecordSp(SessionID,
                                                                               TransNum,
                                                                               ErrorMsg,
                                                                               ref Infobar);

                return Severity;
            }
        }
    }
}
