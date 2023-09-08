using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    public class JobMaterialRapidEntryUpdate : ShopFloorUtilities
    {
        #region Input and Local Variables
        //Input Variables.     
        private string job = "";
        private string suffix = "";
        private string whse = "";
        private string operation = "";
        private string rowNumber = "";
        private string sequence = "";
        private string qty = "";
        private string item = "";
        private string loc = "";
        private string lot = "";
        private string uom = "";
        private string SessionID = "";

        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private bool issueNewMaterial = false;
        private string materialXml = "";

        private string BACK_FLUSH = "0";
        private string EXT_BY_SCRAP = "1";

        private string docNum = "";
        private string jobSerial = "";
        private string jobLot = "";
        private List<string> SerialList = null;
        private string errorMessage = "";
        private string site = "";
        private bool serialNeedToBeFormated = false;

        private InvokeResponseData OrderInvokeResponseData = null;
        private LoadCollectionResponseData OrderCollectionResponseData = null;
        private LoadCollectionResponseData OrderOperSeqResponseData = null;
        private InvokeResponseData QtyInvokeResponseData = null;
        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private DateTime _siteDateTime;
        /******************************/
        #endregion
        public DateTime SiteDateTime
        {
            get { return _siteDateTime; }
            set { _siteDateTime = value; }
        }
        #region Flow Methods
        public JobMaterialRapidEntryUpdate(string job, string suffix, string whse, string site, string materialXML, bool addItemLocRecord, bool allowIfCycleCountExists,
                                            bool addPermanentItemWhseLocLink, string docNum, string JobLot = "", string JobSerial = "")
        {
            initialize(); //initalize the derived class
            this.job = job;
            this.suffix = suffix;
            this.whse = whse;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.site = site;
            this.docNum = docNum;
            this.jobSerial = JobSerial;
            this.jobLot = JobLot;
            this.materialXml = materialXML;
        }
        public void initialize()
        {
            this.Initialize();//Initilize the base class.
            job = "";
            suffix = "";
            whse = "";
            addItemLocRecord = true;
            allowIfCycleCountExists = false;
            addPermanentItemWhseLocLink = false;
            issueNewMaterial = false;
            materialXml = "";
            site = "";
            jobSerial = "";
            jobLot = "";
            this.docNum = "";
        }
        private Boolean PerformIssue()
        {
            try
            {
                //added to handle when the item location record needs to be added  JH:20121121  
                if (this.insertItemLocRecord == true)
                {
                    if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
                    {
                        return false;
                    }
                }
                //Process Checks
                if (ValidateJobmatlSeqSp() == false)
                {
                    return false;
                }
                if (JobMaterialIssueValidationSp() == false)
                {
                    return false;
                }
                if (itemSerialTracked)
                {
                    return PerformSerailUpdate();
                }
                else
                {
                    return PerformNonSerailUpdate();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
        private bool ProcessJobMatlTransSetVarsSp(string type)
        {
            //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
            MessageLogging("JobMaterialIssueUpdate: ProcessJobMatlTransSetVarsSp", msgLevel.l1_information, 1200002);
            //Console.WriteLine("ProcessJobMatlTransSetVarsSp");

            //   If issueNewMaterial = yes then it will allways add the item to the Job's BOM as a non-required item.
            //   If the issueNewmaterial = no then the transaction will try to issue the material to the sequence that is passed in.
            object[] inputValues = new object[]{
                                                type,
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                (this.itemSerialTracked?"1":"0"),
                                                BACK_FLUSH,
                                                "0", //added to allow the scanner to process the data as a byproduct. 0 = normal JH:20121116                                                
                                                uom,
                                                item,
                                                "",//ItemDesc,
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"JbrWc")),  //i5735361/MSF152580  if issueNewMaterial = yes then this is null
                                                whse,
                                                loc,
                                                lot,
                                                _siteDateTime.ToString(WMLongDateTimePattern), // FTDEV-9195 - Adding Time to the date/time string passed into CSI
                                                QtyInvokeResponseData.Parameters.ElementAt(17).ToString(),  //Material Cost 
                                                QtyInvokeResponseData.Parameters.ElementAt(19).ToString(),  //Labor Cost  
                                                QtyInvokeResponseData.Parameters.ElementAt(21).ToString(),  //Fovhd Cost  
                                                QtyInvokeResponseData.Parameters.ElementAt(23).ToString(),  //Vovhd Cost  
                                                QtyInvokeResponseData.Parameters.ElementAt(25).ToString(),  //Out Cost    
                                                QtyInvokeResponseData.Parameters.ElementAt(17).ToString(),  //Issue of Non-Inventory Item.
                                                QtyInvokeResponseData.Parameters.ElementAt(36).ToString(),  //Plan Cost  
                                                qty, //when processing as a byproduct should be a negative qty.  because we only allow the user to enter positive values on the scanner.  
                                                "",                                                   // Non-Inventory Item.
                                                "",                                              // Non-Inventory Item.
                                                "",                                              // Non-Inventory Item.
                                                "",                                              // Non-Inventory Item.
                                                "",
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"RowPointer")),
                                                "I",
                                                "",
                                                "0",
                                                "0",
                                                "",
                                                "",
                                                jobLot,
                                                jobSerial,
                                                "",
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"RecordDate")),
                                                "",
                                                docNum
                                                };

            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "ProcessJobMatlTransSetVarsSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(34).ToString();
                return false;
            }

            return true;
        }
        private bool PerformSerailUpdate()
        {

            if (ProcessJobMatlTransSetVarsSp("S") == false)
            {
                return false;
            }

            object[] serialsMethod = new object[] { "SLJobTrans.ProcessJobMatlTransSp" };


            InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLSerials", "SetMethodSP", serialsMethod);
            if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
            {
                errorMessage = "Transaction failed";
                return false;
            }

            //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108            
            MessageLogging("JobMaterialIssueUpdate: after SetMethodSP method", msgLevel.l1_information, 1200002);
            //Console.WriteLine("after SetMethodSP method ");

            //Serials
            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLSerials";
            updateRequestData.RefreshAfterUpdate = true;
            updateRequestData.CustomInsert = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";
            updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";

            if (SerialList != null && SerialList.Count > 0)
            {
                for (int i = 0; i < SerialList.Count(); i++)
                {
                    IDOUpdateItem serialItem = new IDOUpdateItem();
                    serialItem.Action = UpdateAction.Update;
                    serialItem.ItemNumber = i;
                    if (serialNeedToBeFormated)
                    {
                        serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SerialList.ElementAt(i).ToString()));
                    }
                    else
                    {
                        serialItem.Properties.Add("SerNum", SerialList.ElementAt(i).ToString().Trim(), false);
                    }

                    if (issueNewMaterial)
                    {
                        serialItem.Properties.Add("UbRefStr", "", false);
                    }
                    else
                    {
                        serialItem.Properties.Add("UbRefStr", GetPropertyValue(OrderOperSeqResponseData, "RowPointer"), false);
                    }
                    serialItem.Properties.Add("UbSelect", "1");
                    updateRequestData.Items.Add(serialItem);

                }
            }

            if (updateRequestData != null && updateRequestData.Items.Count > 0)
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
                MessageLogging("JobMaterialIssueUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                //Console.WriteLine(updateResponseData.ToXml());
            }

            if (ProcessJobMatlTransSetVarsSp("U") == false)
            {
                //return errorMessage;
                return false;
            }
            return true;

        }
        private bool PerformNonSerailUpdate()
        {

            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                (this.itemSerialTracked?"1":"0"),
                                                BACK_FLUSH,
                                                "0", //added to allow the scanner to process the data as a byproduct 
                                                  uom,
                                                item,
                                                "",//ItemDesc,//need to change
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"JbrWc")),
                                                whse,
                                                string.IsNullOrEmpty(loc)?"":loc,
                                                string.IsNullOrEmpty(lot)?"":lot,
                                                _siteDateTime,
                                                QtyInvokeResponseData.Parameters.ElementAt(17).ToString(),  //Material Cost 
                                                QtyInvokeResponseData.Parameters.ElementAt(19).ToString(),  //Labor Cost  
                                                QtyInvokeResponseData.Parameters.ElementAt(21).ToString(),  //Fovhd Cost  
                                                QtyInvokeResponseData.Parameters.ElementAt(23).ToString(),  //Vovhd Cost  
                                                QtyInvokeResponseData.Parameters.ElementAt(25).ToString(),  //Out Cost    
                                                QtyInvokeResponseData.Parameters.ElementAt(17).ToString(),  //Issue of Non-Inventory Item.
                                                QtyInvokeResponseData.Parameters.ElementAt(36).ToString(),  //Plan Cost  
                                                qty, //when processing as a byproduct should be a negative qty.  because we only allow the user to enter positive values on the scanner.  
                                                "",                                                   // Non-Inventory Item.
                                                "",                                              // Non-Inventory Item.
                                                "",                                              // Non-Inventory Item.
                                                "",                                              // Non-Inventory Item.
                                                 "",
                                                 (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"RowPointer")),
                                                "I",
                                                "",
                                                "0",
                                                "0",
                                                "",
                                                "",
                                                string.IsNullOrEmpty(jobLot)?"":jobLot,
                                                string.IsNullOrEmpty(jobSerial)?"":jobSerial,
                                               "",
                                                (this.issueNewMaterial?"":GetPropertyValue(OrderOperSeqResponseData,"RecordDate")),
                                                "",
                                                docNum
                                               };
            InvokeResponseData responseData = InvokeIDO("SLJobTrans", "ProcessJobMatlTransSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(33).ToString();
                return false;
            }

            return true;

        }
        private bool ValidateJobmatlSeqSp()
        {
            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                uom,
                                                item,
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLJobMatls", "ValidateJobmatlSeqSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(6).ToString();
                return false;
            }
            return true;
        }
        private bool JobMaterialIssueValidationSp()
        {
            object[] inputValues = new object[]{
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                item,
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLJobMatls", "JobMaterialIssueValidationSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(5).ToString();
                return false;
            }
            return true;
        }
        private bool ValidateJobKeyInputs()
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLJobmatls";
            requestData.PropertyList.SetProperties("RowPointer, RecordDate, Job, Suffix, OperNum, Sequence, Item,ItmDescription,ItmLotTracked,ItmSerialTracked,DerWhse,JbrWc,DerQty, DerReqQty, DerQtyPicked, DerQtyToPick, DerUM, CostConv, DerByProduct, DerItemSerialTracked, DerPlanCostConv, DerQtyConv, DerWC, FovhdCostConv, MatlCostConv,LbrCostConv, OutCostConv, RefLineSuf");
            string filterString = "";
            if (issueNewMaterial)
            {
                filterString = "Job = '" + job + "' and Suffix ='" + suffix + "' and OperNum ='" + operation + "' and Item ='" + formatItem(item) + "'";
            }
            else
            {
                filterString = "Job = '" + job + "' and Suffix ='" + suffix + "' and OperNum ='" + operation + "' and Sequence ='" + sequence + "'";
            }

            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "Job";
            OrderOperSeqResponseData = ExcuteQueryRequest(requestData);
            if (OrderOperSeqResponseData == null || OrderOperSeqResponseData.Items.Count == 0)
            {
                if (issueNewMaterial)
                {
                    sequence = "0";
                }
                else
                {
                    errorMessage = "Job/Suffix/Operation/Sequence Details Not Found";
                    return false;
                }
            }
            else
            {
                if (issueNewMaterial)
                {

                    LoadCollectionRequestData requestDataNew = new LoadCollectionRequestData();
                    requestDataNew.IDOName = "SLJobmatls";
                    requestDataNew.PropertyList.SetProperties("JobItem,UbSelect,OperNum,Sequence,Item,Description,DerQtyConv,UM,DerLoc,DerLot,DerCostCode,Job,Suffix,UbImportDocId,MatlCostConv,LbrCostConv,FovhdCostConv,VovhdCostConv,OutCostConv,UbAcct,DerQtyOnHandConv,DerReqQtyConv,DerQtyIssuedConv,DerPlanCostConv,ACost,UbAcctUnit1,UbAcctUnit2,UbAcctUnit3,UbAcctUnit4,UbTargetQty,UbSelectedQty,UbGenerateQty,UbRangeQty,OrdType,Backflush,DerWC,ScrapFact,MatlQty,MatlQtyConv,DerItemExist,DerReqQty,QtyIssued,DerQty,DerItemUMConvFactor,MatlCost,LbrCost,FovhdCost,VovhdCost,OutCost,DerPlanCost,DerItemLotTracked,DerItemSerialTracked,DerItemIssueBy,UbDelTempSer,UbWhse,RowPointer,DerQtyOnHand,Units,QtyReleased,Cost,CostConv,DerItemUM,AMatlCost,ALbrCost,AFovhdCost,AVovhdCost,AOutCost,ItmMatlCost,ItmLbrCost,ItmFovhdCost,ItmVovhdCost,ItmOutCost,DerPoVendNum,RefType,RefNum,UbAcctAccessUnit1,UbAcctAccessUnit2,UbAcctAccessUnit3,UbAcctAccessUnit4,UbTransDate,RefLineSuf,RefRelease,DerByProduct,DerItemTaxFreeMatl,WcOutside, RecordDate");
                    requestDataNew.Filter = "Job = '" + job + "' and Suffix = '" + suffix + "' and OperNum ='" + operation + "' and Item ='" + formatItem(item) + "'";
                    requestDataNew.RecordCap = -1;
                    requestDataNew.OrderBy = "Job";
                    CustomLoadMethod customLoadMethod = new CustomLoadMethod();

                    customLoadMethod.Name = "GetJobMatlsSp";
                    customLoadMethod.Parameters.Add(site);
                    customLoadMethod.Parameters.Add(job);
                    customLoadMethod.Parameters.Add(suffix);
                    customLoadMethod.Parameters.Add(operation);
                    customLoadMethod.Parameters.Add("");
                    customLoadMethod.Parameters.Add(item);
                    customLoadMethod.Parameters.Add("");
                    customLoadMethod.Parameters.Add("1");
                    customLoadMethod.Parameters.Add(whse);
                    customLoadMethod.Parameters.Add("");
                    customLoadMethod.Parameters.Add("");                //container num
                    customLoadMethod.Parameters.Add("");                //inforBar
                    requestDataNew.CustomLoadMethod = customLoadMethod;

                    LoadCollectionResponseData responseDataNew = ExcuteQueryRequest(requestDataNew);
                    if (responseDataNew == null || responseDataNew.Items.Count > 0)
                    {
                        decimal openQty = Convert.ToDecimal(responseDataNew[0, "DerQty"].ToString(), CultureInfo.InvariantCulture); // FTDEV-9247

                        MessageLogging("JobMaterialIssueUpdate: " + "Open Qty = " + openQty + "  responseDataNew[0, DerReqQty] : " + responseDataNew[0, "DerReqQty"].ToString(), msgLevel.l1_information, 1200002);
                        //Console.WriteLine("Open Qty = " + openQty + "  responseDataNew[0, DerReqQty] : " + responseDataNew[0, "DerReqQty"].ToString());


                        if (openQty > 0)
                        {
                            IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                            substitutorDictionary.Add("openQty", openQty.ToString());
                            //errorMessage = "There is already a line open for this Job/Suffix/Operation/Item with Open Qty: {openQty}";                            
                            errorMessage = constructErrorMessage("There is already a line open for this Job/Suffix/Operation/Item with Open Qty: {openQty}", "SLMIXXXXX04", substitutorDictionary);
                            return false;

                        }

                    }
                }
            }

            return true;
        }
        public int PerformUpdate(out string infobar, out string transStatus)
        {
            infobar = "";
            transStatus = string.Empty;
            string failedRowNumber = string.Empty;
            int failedCount = 0;
            if (!formatInputs())
            {
                infobar = errorMessage;
                return 1;
            }
            if (!ValidateInputs())
            {
                infobar = errorMessage;
                return 2;
            }
            object[] dateCheckValues = new object[] {
                                                      _siteDateTime.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                      "Transaction Date",
                                                      "@%update",
                                                      "",
                                                      "",
                                                      "" };

            InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLPeriods", "DateChkSp", dateCheckValues);
            if (!(invokeResponseDataStep1.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                return 3;
            }
            DataTable dt = null;
            using (System.IO.StringReader reader = new System.IO.StringReader(materialXml))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                dt = ds.Tables[0];
            }
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    rowNumber = dr["RowNumber"].ToString();
                    operation = dr["Operation"].ToString();
                    sequence = dr["Sequence"].ToString();
                    qty = dr["QtyIssue"].ToString();
                    item = dr["Material"].ToString();
                    loc = dr["Location"].ToString();
                    lot = dr["Lot"].ToString();
                    uom = dr["QtyUM"].ToString();
                    SessionID = dr["SessionID"].ToString();
                    issueNewMaterial = dr["NewRecord"].ToString() == "1" ? true : false;
                    itemLotTracked = dr["LotTrack"].ToString() == "1" ? true : false;
                    itemSerialTracked = dr["SerialTrack"].ToString() == "1" ? true : false;
                    if (!string.IsNullOrEmpty(lot))
                        lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);

                    if (ValidateJob() == false)
                    {
                        infobar += errorMessage;
                        failedCount++;
                        failedRowNumber = string.Concat(failedRowNumber, "~", rowNumber);
                        ClearVariables();
                        continue;
                    }
                    if (ValidateJobKeyInputs() == false)
                    {
                        infobar += errorMessage;
                        failedCount++;
                        failedRowNumber = string.Concat(failedRowNumber, "~", rowNumber);
                        ClearVariables();
                        continue;
                    }
                    if (ValidateLocation() == false)
                    {
                        infobar += errorMessage;
                        failedCount++;
                        failedRowNumber = string.Concat(failedRowNumber, "~", rowNumber);
                        ClearVariables();
                        continue;
                    }
                    if (checkLot(item, lot, itemLotTracked, out errorMessage) == false)
                    {
                        infobar += errorMessage;
                        failedCount++;
                        failedRowNumber = string.Concat(failedRowNumber, "~", rowNumber);
                        ClearVariables();
                        continue;
                    }
                    if (ValidateQty1() == false)
                    {
                        // return false;  To Avoid Warning message on adding New Item.
                    }
                    if (itemSerialTracked)
                    {
                        if (SessionID != null && !(SessionID.Equals("")))
                        {
                            SerialList = this.GetSerialList(this.SessionID);
                        }
                        if (ValidateSerials(SerialList) == false && issueNewMaterial == false)
                        {
                            infobar += errorMessage;
                            failedCount++;
                            failedRowNumber = string.Concat(failedRowNumber, "~", rowNumber);
                            ClearVariables();
                            continue;
                        }
                    }
                    if (PerformIssue() == false)
                    {
                        failedCount++;
                        infobar += errorMessage;
                        failedRowNumber = string.Concat(failedRowNumber, "~", rowNumber);
                        ClearVariables();
                        continue;
                    }
                    ClearVariables();
                }
                dt = null;                
                if (!string.IsNullOrEmpty(failedRowNumber))
                {
                    transStatus = failedRowNumber;
                    return 3;
                }
            }
            return 0;
        }
        #endregion

        #region Private Methods
        private bool formatInputs()
        {

            if (IsStringContainsNumericValue(job))
                job = formatDataByIDOAndPropertyName("SLJobs", "Job", job);
            if (job == null || job.Trim().Equals(""))
            {
                errorMessage = "Job Input is mandatory";
                return false;
            }
            suffix = formatDataByIDOAndPropertyName("SLJobs", "Suffix", suffix);
            if (suffix == null || suffix.Trim().Equals(""))
            {
                errorMessage = "Suffix Input is mandatory";
                return false;
            }
            if (site == null || site.Trim().Equals(""))
            {
                errorMessage = "Site input mandatory";
                return false;
            }
            whse = formatDataByIDOAndPropertyName("SLRsvdInvs", "Whse", whse);
            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = "Whse input mandatory";
                return false;
            }
            jobSerial = formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", jobSerial);
            return true;
        }
        private bool ValidateInputs()
        {
            LoadCollectionResponseData responseData = GetSiteDetails(site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = constructErrorMessage("Site Details Not Found", "SLAXXXX025", null);
                return false;
            }
            responseData = GetWhseDetailsBySite(whse, site);
            if (responseData.PropertyList.Count == 0)
            {
                errorMessage = "Whse Details Not Found";
                return false;
            }
            string physicalInventoryFlag = GetPropertyValue(responseData.PropertyList, responseData.Items, "PhyInvFlg");
            if (physicalInventoryFlag == null)
            {
                errorMessage = "Error Reading WhseAll record";
                return false;
            }
            if (!(physicalInventoryFlag.Equals("0")))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("whse", whse);
                errorMessage = constructErrorMessage("Physical Inventory is active in Warehouse : {whse}, Transaction not allowed", "SLMIxxxx001", substitutorDictionary);
                return false;
            }
            return true;
        }

        private void ClearVariables()
        {
            operation = string.Empty;
            sequence = string.Empty;
            qty = string.Empty;
            item = string.Empty;
            loc = string.Empty;
            lot = string.Empty;
            uom = string.Empty;
            rowNumber = string.Empty;
            SessionID = null;
            issueNewMaterial = false;
            itemLotTracked = false;
            itemSerialTracked = false;
        }
        #region Validate Job
        private bool ValidateLocation()
        {
            if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
            {
                if (addItemLocRecord == false)//added to handle when the item location record needs to be added  JH:20121121
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("site", site);
                    substitutorDictionary.Add("whse", whse);
                    substitutorDictionary.Add("item", item);
                    substitutorDictionary.Add("loc", loc);
                    errorMessage = constructErrorMessage("{site} / {whse} / {item} / {loc} combination does not exists, Transfer not allowed", "SLMIxxxx002", substitutorDictionary);
                    return false;
                }
                else
                {
                    insertItemLocRecord = true;
                }
            }
            object[] inputValues = new object[]{
                                                whse,
                                                item,
                                                loc,
                                                qty,
                                                site,
                                                "",
                                                "",
                                                "",
                                                "",
                                                0,
                                                uom
                                                };
            InvokeResponseData responseData = InvokeIDO("SYMIX.SLItemacts", "MiscIssueGetLocQtyOnHandSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(8).ToString();
                return false;
            }
            return true;

        }
        private bool ValidateSerials(List<string> SessionID)
        {

            if (SessionID != null && (!SessionID.Equals("")))
            {
                for (int i = 0; i < SessionID.Count(); i++)
                {

                    string serial = formatDataByIDOAndPropertyName("SLMSSerials", "SerNum", SessionID.ElementAt(i).ToString());
                    if (CheckSerialForReturn(serial) == false)
                    {
                        return false;
                    }

                }
                return true;
            }
            return false;
        }
        public bool CheckSerialForReturn(string serial)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLSerials";
            requestData.PropertyList.SetProperties("SerNum, Stat");
            string filterString = "SerNum = '" + serial + "' and Item ='" + formatItem(item) + "' ";
            if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) > 0)
            {
                filterString += " and Stat = 'I' ";
            }
            else
            {
                filterString += " and Stat = 'O' ";
            }
            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "SerNum";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            if (responseData.Items.Count == 0)
            {

                filterString = "SerNum = '" + serial.Trim() + "' and Item ='" + formatItem(item) + "' ";
                requestData.Filter = filterString;
                requestData.RecordCap = 0;
                requestData.OrderBy = "SerNum";
                responseData = ExcuteQueryRequest(requestData);
                if (responseData.Items.Count == 0)
                {
                    IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                    substitutorDictionary.Add("serial", serial);
                    //errorMessage = "Serial Number : {serial} Not Found" ;
                    errorMessage = constructErrorMessage("Serial Number : {serial} Not Found", "SLMIXXXXX07", substitutorDictionary);
                    return false;
                }
                else
                {
                    serialNeedToBeFormated = false;
                }
            }
            else
            {
                serialNeedToBeFormated = true;
            }
            return true;
        }
        private bool ValidateJob()
        {
            OrderCollectionResponseData = GetJobDetails(job, suffix);
            if (OrderCollectionResponseData == null || OrderCollectionResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Job/Suffix Details Not Found", "SLAXXXX063", null);
                return false;
            }
            object[] inputValues;
            inputValues = new object[]{
                                                "",
                                                job,
                                                job,
                                                suffix,
                                                suffix,
                                                operation,
                                                "",
                                                "",
                                                "",
                                                item,
                                                //1
                                                "",
                                                "",
                                                "",
                                                uom,
                                                whse,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                //2
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
                                                //3
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
                                                //4
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
            OrderInvokeResponseData = InvokeIDO("SLJobTrans", "JobtranJobValidSp", inputValues);

            if (!(OrderInvokeResponseData.ReturnValue.Equals("0")))
            {
                //errorMessage = constructErrorMessage(OrderInvokeResponseData.Parameters.ElementAt(32).ToString(), "-2", null);
                errorMessage = OrderInvokeResponseData.Parameters.ElementAt(32).ToString();
                return false;
            }

            return true;
        }
        #endregion
        public bool ValidateQty1()
        {

            object[] inputParams = null;
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLJobmatls", "GetJobmatlItemSp");
            inputParams = new object[]{
                                                item,
                                                uom,
                                                job,
                                                suffix,
                                                operation,
                                                sequence,
                                                whse,
                                                EXT_BY_SCRAP,
                                                "",
                                                "", //1
                                                "",
                                                uom,
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",//2
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                GetIDOInputBoolValue(itemSerialTracked),
                                                GetIDOInputBoolValue(itemLotTracked), //3
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "", //4
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",//5
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                site,
                                                "",
                                                "0",//jmtReturn
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


            QtyInvokeResponseData = InvokeIDO("SLJobmatls", "GetJobmatlItemSp", inputParams);

            if (!(QtyInvokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = QtyInvokeResponseData.Parameters.ElementAt(56).ToString();
                return false;
            }
            return true;
        }
        #endregion

    }
}
