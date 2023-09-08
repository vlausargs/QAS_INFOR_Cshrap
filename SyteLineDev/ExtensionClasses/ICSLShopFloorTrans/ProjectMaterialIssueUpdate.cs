using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class ProjectMaterialIssueUpdate : ShopFloorUtilities
    {
        #region Variables
        //Input Variables.
        private string projNum = "";
        private string task = "";
        private string sequence = "";
        private string qty = "";
        private string item = "";
        private string itemDesc = "";
        private string site = "";
        private string whse = "";
        private string loc = "";
        private string lot = "";

        private string uom = "";
        private string costCode = "";
        private bool addItemLocRecord = true;
        private bool allowIfCycleCountExists = false;
        private bool addPermanentItemWhseLocLink = false;
        private bool issueNewMaterial = false;
        private bool createNewLot = false;
        private string SessionID = "";
        //format - <serials><serial>xxx</serial><serial>xxys</serial></serials>

        private string otherAcct = "";                           // For Non invenoty item issue
        private string otherAcctUnit1 = "";
        private string otherAcctUnit2 = "";
        private string otherAcctUnit3 = "";
        private string otherAcctUnit4 = "";
        private string nonInvCost = "";
        private bool isNonInventoryItem = false;
        private string containerNum = "";
        private string docNum = "";

        /******************************/

        //Local Varialbles

        private bool itemLotTracked = false;
        private bool itemSerialTracked = false;
        private bool insertItemLocRecord = false;
        private LoadCollectionResponseData OrderCollectionResponseData = null;
        private LoadCollectionResponseData ProjectTaskMaterialResponseData = null;
        private InvokeResponseData QtyInvokeResponseData = null;
        private string ITEM_CONV_FACTOR = "";
        private string ItemDesc = "";


        private bool serialNeedToBeFormated = false;
        private List<string> SerialList = null;
        private string errorMessage = "";

        #endregion

        //constructor

        public ProjectMaterialIssueUpdate(string projNum, string task, string sequence, string qty, string item,
                                      string itemDesc, string site, string whse, string loc, string lot, string uom,
                                      string costCode, bool addItemLocRecord, bool allowIfCycleCountExists,
                                      bool addPermanentItemWhseLocLink, bool issueNewMaterial,
                                      string otherAcct,
                                      string otherAcctUnit1, string otherAcctUnit2,
                                      string otherAcctUnit3, string otherAcctUnit4,
                                      string nonInvCost, string SessionID, string containerNum, string docNum)
        {//MSF 171589 added joblot and jobserial  jh:20141220
            initialize(); //initalize the derived class
            this.projNum = projNum;
            this.task = task;

            this.sequence = sequence;
            this.qty = qty;
            this.item = item;
            this.itemDesc = itemDesc;
            this.site = site;
            this.whse = whse;
            this.loc = loc;
            this.lot = lot;
            this.uom = uom;
            this.costCode = costCode;
            this.addItemLocRecord = addItemLocRecord;
            this.allowIfCycleCountExists = allowIfCycleCountExists;
            this.addPermanentItemWhseLocLink = addPermanentItemWhseLocLink;
            this.issueNewMaterial = issueNewMaterial;

            this.otherAcct = otherAcct;
            this.otherAcctUnit1 = otherAcctUnit1;
            this.otherAcctUnit2 = otherAcctUnit2;
            this.otherAcctUnit3 = otherAcctUnit3;
            this.otherAcctUnit4 = otherAcctUnit4;
            this.nonInvCost = nonInvCost;
            this.SessionID = SessionID;
            this.containerNum = containerNum;  // Added for Container functionality
            this.docNum = docNum;
        }


        public void initialize()
        {
            this.Initialize();//Initilize the base class.  Setup any necessary base class variables. JH:20140103
            projNum = "";
            task = "";

            sequence = "";
            site = "";
            whse = "";
            item = "";
            itemDesc = "";
            qty = "";
            loc = "";
            lot = "";
            uom = "";
            addItemLocRecord = true;
            allowIfCycleCountExists = false;
            addPermanentItemWhseLocLink = false;
            issueNewMaterial = false;
            this.otherAcct = "";
            this.otherAcctUnit1 = "";
            this.otherAcctUnit2 = "";
            this.otherAcctUnit3 = "";
            this.otherAcctUnit4 = "";
            this.nonInvCost = "";
            this.isNonInventoryItem = false;
            //Local variables initialization
            itemLotTracked = false;
            itemSerialTracked = false;
            insertItemLocRecord = false;
            OrderCollectionResponseData = null;
            ProjectTaskMaterialResponseData = null;
            QtyInvokeResponseData = null;
            ITEM_CONV_FACTOR = "";
            ItemDesc = "";
            containerNum = "";
            docNum = "";
            createNewLot = false;
        }

        public bool formatInputs()
        {
            LoadCollectionResponseData responseData = null;
            projNum = formatDataByIDOAndPropertyName("SLProjs", "ProjNum", projNum);
            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            if (!((containerNum == null) || containerNum.Trim().Equals("")))
            {
                if (IsStringContainsNumericValue(containerNum))
                    containerNum = formatDataByIDOAndPropertyName("SLContainers", "ContainerNum", containerNum);
            }

            if (projNum == null || projNum.Trim().Equals(""))
            {
                errorMessage = "Project Input is mandatory";
                return false;
            }
            task = formatDataByIDOAndPropertyName("SLProjTasks", "TaskNum", task);
            if (task == null || task.Trim().Equals(""))
            {
                errorMessage = "Task Input is mandatory";
                return false;
            }
            if (containerNum == null || containerNum.Trim() == "")
            {
                if (!issueNewMaterial)
                {
                    sequence = formatDataByIDOAndPropertyName("SLProjMatls", "Seq", sequence);
                    if (sequence == null || sequence.Trim().Equals(""))
                    {
                        errorMessage = "sequence Input is mandatory";
                        return false;
                    }
                }

                if (qty == null || qty.Trim().Equals(""))
                {
                    errorMessage = "Qty input mandatory";
                    return false;
                }
                // item = formatDataByIDOAndPropertyName("SLRsvdInvs", "Item", item);
                item = formatDataByIDOAndPropertyName("SLItems", "Item", item.ToUpper());
                if (item == null || item.Trim().Equals(""))
                {
                    errorMessage = "Item input mandatory";
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
                responseData = GetItemDetails(item);
                if (responseData.Items.Count > 0)
                {
                    isNonInventoryItem = false;
                }
                else
                {
                    isNonInventoryItem = true;
                }
                loc = formatDataByIDOAndPropertyName("SLRsvdInvs", "Loc", loc);
                if (loc == null || loc.Trim().Equals(""))
                {
                    if (isNonInventoryItem == false)
                    {
                        errorMessage = constructErrorMessage("Loc input mandatory", "SLAPKPR009", null);
                        return false;
                    }
                }

                lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);


                if (uom == null || uom.Trim().Equals(""))
                {
                    errorMessage = "Uom input mandatory";
                    return false;
                }

                try
                {
                    if (isNonInventoryItem)
                    {

                        if (otherAcct == null || otherAcct.Trim().Equals(""))
                        {
                            errorMessage = constructErrorMessage("otherAcct input mandatory", "SLAXXXX012", null);
                            return false;
                        }

                        //Console.WriteLine("materialcost = " + this.nonInvCost);
                    }
                }
                catch (Exception)
                {
                }
            }

            return true;
        }

        public bool validateInputs()
        {
            string itemUM = "";
            //Project  Validation

            if (ValidateProj() == false)
            {
                return false;
            }

            //Validate Project/task/Item combination

            if (ValidateProjKeyInputs() == false)
            {
                return false;
            }

            //Validate Inputs
            if (containerNum == null || containerNum.Trim() == "")
            {
                if (issueNewMaterial == false)
                {
                    if (VerifyInputs() == false)
                    {
                        return false;
                    }
                }
                if (checkIfItemLotExists() == false)
                {
                    createNewLot = true;
                }

                MessageLogging("Project Task Item issue: in ValidateInputs Method, after issueMaterial = false check", msgLevel.l1_information, 1200002);

                //Validate From Site
                LoadCollectionResponseData responseData = GetSiteDetails(site);
                if (responseData.PropertyList.Count == 0)
                {

                    errorMessage = constructErrorMessage("Site Details Not Found", "SLAXXXX025", null);
                    //errorMessage = "Site Details Not Found";
                    return false;
                }

                //Check Issueing  Warehouse
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

                MessageLogging("Project Task Item Issue: in ValidateInputs Method, after whse validation", msgLevel.l1_information, 1200002);

                //Check Item Details
                if (isNonInventoryItem == false)
                {
                    //Check Item Details  -- only do this if it is an Inventory item
                    responseData = GetItemDetails(formatItem(item));
                    if (responseData.Items.Count == 0)
                    {
                        errorMessage = "Item Details Not Found";
                        return false;
                    }

                    itemLotTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "LotTracked"));
                    itemSerialTracked = GetBool(GetPropertyValue(responseData.PropertyList, responseData.Items, "SerialTracked"));
                    ItemDesc = GetPropertyValue(responseData, "Description");
                    itemUM = GetPropertyValue(responseData.PropertyList, responseData.Items, "UM");
                    MessageLogging("Project Task Item Issue: in ValidateInputs Method, after item validation", msgLevel.l1_information, 1200002);
                    //Console.WriteLine("In PickForProductionUpdateDaoImpl.cs, in ValidateInputs Method, after item validation");
                    if (validWhseItemRecordExists(whse, item, allowIfCycleCountExists, out errorMessage) == false)
                    {
                        return false;
                    }
                    responseData = GetLocationDetails(loc);
                    if (checkLocationDetails(item, whse, site, loc, out errorMessage) == false)
                    {
                        if (addItemLocRecord == false)
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
                    if (insertItemLocRecord == false)
                    {
                        if (ValidateLocation() == false)
                        {
                            return false;
                        }

                        if (ValidateProjmatlValidateLocSp() == false)
                        {
                            return false;
                        }

                        //Check Lot
                        if (checkLot(item, lot, itemLotTracked, out errorMessage) == false)
                        {
                            return false;
                        }
                        if (itemLotTracked == true)
                        {
                            if (ValidateSvallotSp() == false)
                            {
                                return false;
                            }
                        }
                    }
                    //UOM Checks
                    string convertedQty = GetItemConvertedQtyToBaseUnit(item, qty, uom, "", out errorMessage);
                    if (convertedQty == null)
                    {
                        return false;
                    }
                    qty = convertedQty;
                    uom = itemUM;


                }
                //Validate Qty

                if (ValidateQty() == false)
                {
                    return false;
                }
            }

            return true;

        }

        private bool checkIfItemLotExists()
        {
            object[] inputValues = new object[] { whse,
                                                  item,
                                                  loc,
                                                  lot,
                                                  "rcv",
                                                  "0",
                                                  "Project Material",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""};

            InvokeResponseData responseDataStep = this.InvokeIDO("SLTrnacts", "SvallotSp", inputValues);
            if (!(responseDataStep.ReturnValue.Equals("0")))
            {
                return false;
            }

            if (responseDataStep.Parameters.ElementAt(7) != null && !(responseDataStep.Parameters.ElementAt(7).ToString().Trim().Equals("")))
            {
                return false;
            }
            return true;
        }
        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            try
            {
                if (SessionID != null && !(SessionID.Equals("")))
                {
                    SerialList = this.GetSerialList(this.SessionID);
                }

                //2 Format Inputs
                if (formatInputs() == false)
                {
                    infobar = errorMessage;
                    return 1;
                }

                MessageLogging("Project Task Item Issue: in ValidateInputs Method, after Format Inputs", msgLevel.l1_information, 1200002);

                //3 validate Inputs
                if (validateInputs() == false)
                {
                    infobar = errorMessage;
                    return 2;
                }
                MessageLogging("Project Task Item Issue: in ValidateInputs Method, after validate Inputs", msgLevel.l1_information, 1200002);
                //Console.WriteLine("in Pick For Production UpdateDaoImpl, after validate Inputs");
                //Validate Serials

                if (ValidateSerials(SerialList) == false && itemSerialTracked && (containerNum == null || containerNum.Trim() == ""))
                {
                    infobar = errorMessage;
                    return 2;
                }

                //4 Perform Updates

                if (PerformIssue() == false)
                {
                    infobar = errorMessage;
                    return 3;

                }

                infobar = errorMessage;
                return 0;
            }
            catch (Exception)
            {
                infobar = constructErrorMessage("Failed to perform project material issue", "SLAXXXX099", null); ;
                return 16;
            }
        }


        private Boolean PerformIssue()
        {
            try {
                //1 Date Check
                //changed the local variable this.wmShortDatePattern to use the related property in the ICSlbase class.  JH:20140108
                object[] dateCheckValues = new object[] { //System.DateTime.Now.ToShortDateString(), 
                                                      System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                      "Transaction Date",
                                                      "@%update",
                                                      "",
                                                      "",
                                                      "" };

                InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLPeriods", "DateChkSp", dateCheckValues);
                if (!(invokeResponseDataStep1.ReturnValue.Equals("0")))
                {
                    errorMessage = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                    return false;
                }



                if (containerNum != null && containerNum.Trim() != "")
                {
                    if (ProjmatlTransactionByContainerSp() == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (createNewLot == true)
                    {
                        performAddLot(item, lot, "0", "0", "", "1", site, out errorMessage);
                    }
                    //added to handle when the item location record needs to be added  JH:20121121  
                    if (this.insertItemLocRecord == true)
                    {
                        if (addLocItemRecord(item, whse, site, loc, addPermanentItemWhseLocLink, out errorMessage) == false)
                        {
                            return false;
                        }
                    }

                    if (ProcessProjmatlTransactionSetVarsSp("S") == false)
                    {
                        return false;
                    }


                    //Console.WriteLine("after ApsSyncImmediateSetVarsSp method ");

                    // SLMSSerials.SetMethodSp - To store the values
                    object[] serialsMethod = new object[] { "SLProjMatls.ProjmatlTransactionSp" };

                    InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLSerials", "SetMethodSP", serialsMethod);
                    if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
                    {
                        errorMessage = "Transaction failed";
                        return false;
                    }

                    //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108            
                    //  MessageLogging("Project Task Item Issue: after SetMethodSP method", msgLevel.l1_information, 1200002);
                    //Console.WriteLine("after SetMethodSP method ");

                    //Serials

                    UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                    updateRequestData.IDOName = "SLSerials";
                    updateRequestData.RefreshAfterUpdate = true;
                    updateRequestData.CustomInsert = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";
                    updateRequestData.CustomUpdate = "SerialSaveSp(SerNum,,UbRefStr,MESSAGE,NULL,NULL,NULL)";

                    if (SerialList != null)
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
                                serialItem.Properties.Add("UbRefStr", GetPropertyValue(ProjectTaskMaterialResponseData, "RowPointer"), false);
                            }
                            serialItem.Properties.Add("UbSelect", "1");
                            updateRequestData.Items.Add(serialItem);

                        }
                    }

                    UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);

                    MessageLogging("Project Task Item Issue: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);


                    if (ProcessProjmatlTransactionSetVarsSp("U") == false)
                    {
                        //return errorMessage;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            return true;

        }


        private bool ProcessProjmatlTransactionSetVarsSp(string type)
        {
            //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
            MessageLogging("Project Task Item Issue: ProcessJobMatlTransSetVarsSp", msgLevel.l1_information, 1200002);
            //Console.WriteLine("ProcessJobMatlTransSetVarsSp");

            //   If issueNewMaterial = yes then it will allways add the item to the Job's BOM as a non-required item.
            //   If the issueNewmaterial = no then the transaction will try to issue the material to the sequence that is passed in.
            object[] inputValues = new object[]{
                                                type,
                                                projNum,
                                                task,
                                                sequence,
                                                item.Trim(),
                                                ItemDesc, // Item Description
                                                qty,
                                                qty,  //Conversion logic may need to bring in sdommata
                                                uom,
                                                whse,
                                                costCode,
                                                (this.isNonInventoryItem?"":loc.Trim()) ,
                                                (this.isNonInventoryItem?"":lot) ,
                                                System.DateTime.Now.ToString(WMShortDatePattern),   // Trans date
                                                "I" ,   // Trans type  as I
                                                (this.isNonInventoryItem?otherAcct:""),                                                   // Non-Inventory Item.
                                                (this.isNonInventoryItem?otherAcctUnit1:""),                                              // Non-Inventory Item.
                                                (this.isNonInventoryItem?otherAcctUnit2:""),                                              // Non-Inventory Item.
                                                (this.isNonInventoryItem?otherAcctUnit3:""),                                              // Non-Inventory Item.
                                                (this.isNonInventoryItem?otherAcctUnit4:""),                                              // Non-Inventory Item.  
                                                (this.isNonInventoryItem?this.nonInvCost:QtyInvokeResponseData.Parameters.ElementAt(17).ToString()),  //Material Cost 
                                                issueNewMaterial?1:0,
                                                "",
                                                "",
                                                "",   // Doc Id
                                                docNum
                                                };

            InvokeResponseData responseData = InvokeIDO("SLProjMatls", "ProjmatlTransactionSetVarsSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(23).ToString();
                return false;
            }

            return true;
        }

        private bool ProjmatlTransactionByContainerSp()
        {
            //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
            MessageLogging("Project Task Item Issue: ProjmatlTransactionByContainerSp", msgLevel.l1_information, 1200002);

            //   If issueNewMaterial = yes then it will allways add the item to the Job's BOM as a non-required item.
            //   If the issueNewmaterial = no then the transaction will try to issue the material to the sequence that is passed in.
            object[] inputValues = new object[]{
                                                containerNum,
                                                projNum,
                                                task,
                                                whse,
                                                System.DateTime.Now.ToString(WMShortDatePattern),   // Trans date
                                                "",
                                                "",
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLProjMatls", "ProjmatlTransactionByContainerSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                errorMessage = responseData.Parameters.ElementAt(7).ToString();
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


        private bool ValidateProj()
        {
            OrderCollectionResponseData = GetProjectDetails(projNum);
            if (OrderCollectionResponseData == null || OrderCollectionResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Project Not Found", "SLAXXXX063", null);
                return false;
            }


            return true;
        }
        private bool ValidateProjKeyInputs()
        {
            OrderCollectionResponseData = GetProjectTaskDetails(projNum, task);
            if (OrderCollectionResponseData == null || OrderCollectionResponseData.Items.Count == 0)
            {
                errorMessage = constructErrorMessage("Project Task Not Found", "SLAXXXX063", null);
                return false;
            }


            // Validate Proj, Task, Item 
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLProjMatls";
            requestData.PropertyList.SetProperties("Item , ItemDesc , Seq ");

            requestData.Filter = $"ProjNum  = '{projNum}' and TaskNum  ='{task}' and Item ='{item}' and Seq='{sequence}'";

            requestData.RecordCap = 1;
            requestData.OrderBy = "ProjNum,TaskNum";
            ProjectTaskMaterialResponseData = ExcuteQueryRequest(requestData);
            if (ProjectTaskMaterialResponseData == null || ProjectTaskMaterialResponseData.Items.Count == 0)
            {
                if (issueNewMaterial || !string.IsNullOrEmpty(containerNum))
                {
                    sequence = "0";
                }
                else
                {
                    errorMessage = "Project Task Item Sequence Details Not Found";
                    return false;
                }
            }
            return true;
        }
        private bool VerifyInputs()
        {

            MessageLogging("Project Task Item verification verification", msgLevel.l1_information, 1200002);
            //Console.WriteLine("In PickForProductionUpdateDaoImpl.cs, in VerifyInputs Method, after Whse verification");

            if (!(GetPropertyValue(ProjectTaskMaterialResponseData, "Item").ToUpper().Trim().Equals(item.ToUpper().Trim())))
            {
                IDictionary<string, string> substitutorDictionary = new Dictionary<string, string>();
                substitutorDictionary.Add("{item}", item);
                substitutorDictionary.Add("{sub1}", GetPropertyValue(ProjectTaskMaterialResponseData, "Item"));
                errorMessage = constructErrorMessage("Item not matching Project Task Item {sub1}  {item}", "SLMIXXXXX06", substitutorDictionary);
                //errorMessage = "Item not matching Order {sub1}  {item}";
                return false;
            }
            //}
            MessageLogging("Project Task Item, after Item verification", msgLevel.l1_information, 1200002);
            //Console.WriteLine("In PickForProductionUpdateDaoImpl.cs, in VerifyInputs Method, after Item verification");
            return true;
        }
        private bool GetumcfSp()
        {
            object[] inputParams = new object[]{
                                                uom,
                                                item,
                                                "",
                                                "",
                                                ITEM_CONV_FACTOR,
                                                "",
                                                site
                                                };
            InvokeResponseData responseData = InvokeIDO("SLUMConvs", "GetumcfSp", inputParams);

            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(6).ToString();
                return false;
            }
            ITEM_CONV_FACTOR = responseData.Parameters.ElementAt(4).ToString();
            return true;
        }

        private bool ItemQtyDetlSp()
        {
            //Delete the current Inventory
            object[] deleteInvValues = new object[] { site,
                                                      "G",
                                                      "R",
                                                      whse,
                                                      item,
                                                      loc,
                                                      lot,
                                                      qty,
                                                      0,
                                                      "iss",
                                                      "",
                                                      0,
                                                      0,
                                                      0,
                                                      "",
                                                      0,
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "" };

            InvokeResponseData invokeResponseDataStep2 = this.Context.Commands.Invoke("SLItemLocs", "ItemQtyDetlSp", deleteInvValues);
            if (!(invokeResponseDataStep2.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseDataStep2.Parameters.ElementAt(19).ToString();
                return false;
            }
            return true;

        }

        private bool ValidateLocation()
        {

            object[] inputValues = new object[]{

                                                item,
                                                whse,
                                                site,
                                                loc,
                                                0,
                                                "",
                                                "",
                                                "",
                                                };
            InvokeResponseData responseData = InvokeIDO("SLTrnacts", "TrnShipLocValidSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(7).ToString();
                return false;
            }
            return true;
        }

        private bool ValidateProjmatlValidateLocSp()
        {

            object[] inputValues = new object[]{

                                                item,
                                                projNum,
                                                task,
                                                sequence,
                                                whse,
                                                loc,
                                                ITEM_CONV_FACTOR,
                                                lot,
                                                qty,
                                                qty,  //10
                                                qty,
                                                qty,
                                                "",   //infobar                              
                                                ""    // Import Doc id
                                                };
            InvokeResponseData responseData = InvokeIDO("SLProjMatls", "ProjmatlValidateLocSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(12).ToString();
                return false;
            }
            return true;
        }

        private bool ValidateSvallotSp()
        {

            object[] inputValues = new object[]{

                                                whse,
                                                item,
                                                loc,
                                                lot,
                                                "ISS",
                                                0,
                                                "Project Resource Transactions",
                                                "",
                                                "",
                                                "",   //10
                                                "",
                                                "",   //infobar                              
                                                "",
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLTrnacts", "SvallotSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(11).ToString();
                return false;
            }
            return true;
        }

        public bool ValidateQty()
        {

            if (GetumcfSp() == false)
            {
                return false;
            }
            if (ValidateQty1() == false)
            {
                return false;
            }

            if (containerNum == null || containerNum == "")
            {
                if (ItemQtyDetlSp() == false)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateQty1()
        {
            MessageLogging("Project Task Item Issue: in VerifyInputs Method, in ValidateQty1 Method, start", msgLevel.l1_information, 1200002);

            object[] inputParams = null;
            int paramcount = 0;
            paramcount = GetIDOMethodParameterCount("SLProjMatls", "PmatlValidateMatlQtySp");
            MessageLogging("Project Task Item Issue: SLProjMatls.PmatlValidateMatlQtySp param count = " + paramcount, msgLevel.l1_information, 1200002);

            inputParams = new object[]{//25
                                                qty,
                                                whse,
                                                item,
                                                loc,
                                                lot,     //5
                                                ITEM_CONV_FACTOR,
                                                0,
                                                0,  // Required Qty maybe from projtaskmaterial load collection
                                                0,
                                                qty,   //10
                                                "",
                                                "",
                                                "",
                                                "",       // Doc Id   
                                                projNum, //15
                                                task,
                                                sequence,
                                                "",
                                                "",
                                                "",    //20
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""    //25  
                                               };



            QtyInvokeResponseData = InvokeIDO("SLProjMatls", "PmatlValidateMatlQtySp", inputParams);

            if (!(QtyInvokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = QtyInvokeResponseData.Parameters.ElementAt(12).ToString();
                return false;
            }
            return true;
        }
        public bool CheckSerialForReturn(string serial)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLSerials";
            requestData.PropertyList.SetProperties("SerNum, Stat");
            string filterString = "SerNum = '" + serial + "' and Item ='" + formatItem(item) + "' ";
            if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
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
                MessageLogging("Project Task Item Issue: reexecuting query for serial number with trimmed", msgLevel.l1_information, 1200002);
                //Console.WriteLine("reexecuting query for serial number with trimmed");

                filterString = "SerNum = '" + serial.Trim() + "' and Item ='" + formatItem(item) + "' ";

                //Todo - need to determine the correct serial status.
                /*if (Convert.ToDouble(qty, CultureInfo.InvariantCulture) > 0) // FTDEV-9247
                {
                    filterString += " and Stat = 'I' ";
                }
                else
                {
                    filterString += " and Stat = 'O' ";
                }
                 */

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
    }
}