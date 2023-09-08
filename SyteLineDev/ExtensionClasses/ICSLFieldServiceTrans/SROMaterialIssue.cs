using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLFieldServiceTrans
{
    class SROMaterialIssue : FieldServiceUtilities
    {

        //input  vairables

        private string partnerId;
        private string sroNum;
        private long sroLine;
        private long sroOper;
        private string item;
        private string transType;
        private string transDate;
        private decimal qtyConv;
        private string uom;
        private string whse;
        private string loc;
        private string lot;
        private decimal priceConv;
        private string billCode;
        private string noteContent;
        private string rowPointer;
        private long transNum;
        private byte autoPost;
        private string custItem;
        private string prompt;
        private string promptButtons;
        private string matlDescription;
        private string SerialsAsXML = "";
        private string docNum = "";
        private string ReasonCode = "";
        //local variables
        private string errorMessage = "";
        private List<string> SerialList = null;

        public SROMaterialIssue(string partnerId, string sroNum, long sroLine, long sroOper, string item, string transType, string transDate, decimal qtyConv, string uom,
                                string whse, string loc, string lot, decimal priceConv, string billCode, string noteContent, string rowPointer, long transNum, byte autoPost,
                                string custItem, string prompt, string promptButtons, string matlDescription, string SerialsAsXML, string docNum, string ReasonCode)
        {

            this.partnerId = partnerId;
            this.sroNum = sroNum;
            this.sroLine = sroLine;
            this.sroOper = sroOper;
            this.item = item;
            this.transType = transType;
            this.transDate = transDate;
            this.qtyConv = qtyConv;
            this.uom = uom;
            this.whse = whse;
            this.loc = loc;
            this.lot = lot;
            this.priceConv = priceConv;
            this.billCode = billCode;
            this.noteContent = noteContent;
            this.rowPointer = rowPointer;
            this.transNum = transNum;
            this.autoPost = autoPost;
            this.custItem = custItem;
            this.prompt = prompt;
            this.promptButtons = promptButtons;
            this.matlDescription = matlDescription;
            this.SerialsAsXML = SerialsAsXML;
            this.docNum = docNum;
            this.ReasonCode = ReasonCode;
        }

        public void initialize()
        {
            partnerId = "";
            sroNum = "";
            sroLine = 0;
            sroOper = 0;
            item = "";
            transType = "";
            transDate = "";
            qtyConv = 0;
            uom = "";
            whse = "";
            loc = "";
            lot = "";
            priceConv = 0;
            billCode = "";
            noteContent = "";
            rowPointer = "";
            transNum = 0;
            autoPost = 0;
            custItem = "";
            prompt = "";
            promptButtons = "";
            matlDescription = "";
            SerialList = null;
            docNum = "";
            ReasonCode = "";
        }

        public bool formatInputs()
        {
            if (partnerId == null || partnerId.Trim().Equals(""))
            {
                errorMessage = "PartnerId input mandatory";
                return false;
            }

            if (sroNum == null || sroNum.Trim().Equals(""))
            {
                errorMessage = "SRO Number input mandatory";
                return false;
            }

            if (sroLine == 0)
            {
                errorMessage = "SRO Line input mandatory";
                return false;
            }

            if (sroOper == 0)
            {
                errorMessage = "SRO Operation input mandatory";
                return false;
            }

            if (item == null || item.Trim().Equals(""))
            {
                errorMessage = "Item input mandatory";
                return false;
            }
            if (transType == null || transType.Trim().Equals(""))
            {
                errorMessage = "Trans Type input mandatory";
                return false;
            }

            if (qtyConv == 0)
            {
                errorMessage = "Qty input mandatory";
                return false;
            }

            //if (billCode == null || billCode.Trim().Equals(""))
            //{
            //    errorMessage = "billCode input mandatory";
            //    return false;
            //}

            if (whse == null || whse.Trim().Equals(""))
            {
                errorMessage = "Whse input mandatory";
                return false;
            }

            if (loc == null || loc.Trim().Equals(""))
            {
                errorMessage = "Loc input mandatory";
                return false;
            }

            if (uom == null || uom.Trim().Equals(""))
            {
                errorMessage = "UOM input mandatory";
                return false;
            }

            if (transType.Trim().ToUpper().Equals("H") && (ReasonCode == null || ReasonCode.Trim().Equals("")))
            {
                //errorMessage = "ReasonCode input mandatory";
                //return false;
            }

            return true;
        }
        public bool validateInputs()
        {
            partnerId = GetExpandedString(partnerId, "FSPartnerType", null); //formatDataByIDOAndPropertyName("FSSROMatls", "PartnerId", partnerId);
            sroNum = formatDataByIDOAndPropertyName("FSSROs", "SroNum", sroNum);
            LoadCollectionResponseData partnerResponseData = GetPartnerDetails(partnerId);
            if (partnerResponseData.Items.Count == 0)
            {
                errorMessage = "PartnerId Details Not Found";
                return false;
            }
            //Ramu - 20201110.so
            ////LoadCollectionResponseData SroResponseData = GetSRODetails(sroNum); 
            ////if (SroResponseData.Items.Count == 0)
            ////{
            ////    errorMessage = "Service Order Details Not Found";
            ////    return false;
            ////}


            ////LoadCollectionResponseData SroLineResponseData = GetSROLineDetails(sroNum, sroLine);
            ////if (SroLineResponseData.Items.Count == 0)
            ////{
            ////    errorMessage = "Line Details Not Found";
            ////    return false;
            ////}
            ////Ramu - 20201110.so
            LoadCollectionResponseData SroOperResponseData = GetSROOperDetails(sroNum, sroLine, sroOper);
            if (SroOperResponseData.Items.Count == 0)
            {
                errorMessage = "SroOper Details Not Found";
                return false;
            }
            else //Ramu - 20201110.sn
            {
                //SROSroStat,SROLineStat,Stat
                var sroStaus = SroOperResponseData[0, "SROSroStat"].Value;
                var sroLineStaus = SroOperResponseData[0, "SROLineStat"].Value;
                var sroOperStaus = SroOperResponseData[0, "Stat"].Value;
                if (!sroStaus.Equals("O"))
                {
                    errorMessage = "Invalid Order Status";
                    return false;
                }
                if (!sroLineStaus.Equals("O"))
                {
                    errorMessage = "Invalid Line Status";
                    return false;
                }
                if (!sroOperStaus.Equals("O"))
                {
                    errorMessage = "Invalid Operation Status";
                    return false;
                }
            } //Ramu - 20201110.en

            LoadCollectionResponseData SroFieldItemResponseData = GetItemDetails(formatItem(item));
            if (SroFieldItemResponseData.PropertyList.Count == 0)
            {
                errorMessage = "Item Details Not Found";
                return false;
            }

            if (string.IsNullOrEmpty(custItem) == false)
            {
                LoadCollectionResponseData SroCustItemResponseData = GetSROCustItemDetails(sroNum,item, custItem);

                if (SroCustItemResponseData.Items.Count == 0)
                {
                    errorMessage = "CustItem Details Not Found";
                    return false;
                }
            }

            if (string.IsNullOrEmpty(loc) == false)
            {

                LoadCollectionResponseData SroItemLocResponseData = GetSROItemLocDetails(item, whse, loc);

                if (SroItemLocResponseData.Items.Count == 0)
                {
                    errorMessage = "Location Details Not Found";
                    return false;
                }
            }

            if (string.IsNullOrEmpty(lot) == false)
            {
                //lot = formatDataByIDOAndPropertyName("SLTrnacts", "UbFromLot", lot);

                if (ValidateSRoItemLot(whse, item, loc, lot, ref errorMessage) == false)
                {
                    return false;
                }

            }
            //GetReasonCodeDetails(string ReasonCode, string ReasonClass)
            if (string.IsNullOrEmpty(ReasonCode) == false)
            {
                LoadCollectionResponseData SroReasonCodeResponseData = GetReasonCodeDetails(ReasonCode, "CO RETURN");
                if (SroReasonCodeResponseData.Items.Count == 0)
                {
                    errorMessage = "ReasonCode Details Not Found";
                    return false;
                }
            }

            return true;
        }


        public int PerformUpdate(out string infobar)
        {
            infobar = "";
            if (SerialsAsXML != null && !(SerialsAsXML.Equals("")))
            {
                SerialList = this.GetSerialList(this.SerialsAsXML);
            }
            //1 format inputs
            if (formatInputs() == false)
            {
                infobar = errorMessage;
                return 1;
            }

            //2 validate Inputs
            if (validateInputs() == false)
            {
                infobar = errorMessage;
                return 2;
            }

            //4 Perform Updates
            if (PerformMaterialissue() == false)
            {
                infobar = errorMessage;
                return 4;
            }

            return 0;
        }

        #region private methods

        private bool PerformMaterialissue()
        {
            try
            {
                // start Get the Service DC parameters * /
                LoadCollectionRequestData requestData = new LoadCollectionRequestData();
                requestData.IDOName = "FSParms";
                requestData.PropertyList.SetProperties("DcPostMatl,DcPostLabor");
                string filterString = "";
                requestData.Filter = filterString;
                requestData.RecordCap = 1;
                // requestData.OrderBy = "";
                LoadCollectionResponseData responseData = this.Context.Commands.LoadCollection(requestData);

                if (responseData.Items.Count > 0)
                {
                    if (responseData[0, "DcPostMatl"].Value == "1")
                    {
                        autoPost = 1;
                    }
                    else
                    {
                        autoPost = 0;
                    }
                }
                // End Get the Service DC parameters * /
                string infobar = null;
                object[] MaterialFieldVlaues = new object[] {partnerId,sroNum,sroLine,sroOper,item,transType,
                                                        transDate,qtyConv,uom,whse,loc,lot,priceConv,
                                                        billCode,noteContent,rowPointer,transNum,autoPost,
                                                        infobar,custItem,prompt,promptButtons,matlDescription,docNum};
                
                InvokeResponseData invokeResponseDataStep = this.Context.Commands.Invoke("FSSROMatls", "SSSFSSROMatlDCSaveSp", MaterialFieldVlaues);
                if (!(invokeResponseDataStep.ReturnValue.Equals("0")))
                {
                    errorMessage = invokeResponseDataStep.Parameters.ElementAt(18).ToString();
                    return false;
                }
                else
                {
                    transNum = Convert.ToInt64(invokeResponseDataStep.Parameters.ElementAt(16).ToString(), CultureInfo.InvariantCulture); // FTDEV-9247
                    rowPointer = invokeResponseDataStep.Parameters.ElementAt(15).ToString();

                    //Ramu - 20200609.sn
                    if (transType.Equals("H") && (!ReasonCode.Trim().Equals("")))
                    {
                        string wmShortDateTimePattern = "yyyy-MM-dd";
                        //string wmDateTimePattern = "yyyy-MM-dd HH:mm:ss.fff";
                        //string fmtReportDate = DateTime.Parse(transDate).ToString(wmShortDateTimePattern);
                        string strippedTransDate = "";
                        strippedTransDate = transDate.Replace(" ", "");
                        strippedTransDate = strippedTransDate.Replace("/", "");
                        strippedTransDate = strippedTransDate.Replace("-", "");

                        string fmtReportDate = DateTime.ParseExact(strippedTransDate, "yyyyMMdd", CultureInfo.CurrentCulture).ToString(wmShortDateTimePattern);
                        LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                        requestData1.IDOName = "FSSROMatls";
                        requestData1.PropertyList.SetProperties("TransType, TransNum, RecordDate, RowPointer");
                        //string filterString1 = "RowPointer = '" + rowPointer + "'";
                        requestData1.Filter = "RowPointer = '" + rowPointer + "' and TransDate = '" + fmtReportDate + "'";
                        requestData1.Filter += " and TransType = 'H' and TransNum = " + transNum ;
                   
                        requestData1.RecordCap = 1;
                        // requestData.OrderBy = "";
                        LoadCollectionResponseData responseData1 = this.Context.Commands.LoadCollection(requestData1);

                        if (responseData1.Items.Count > 0)
                        {
                            //update FSSROMatl with reason code
                            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                            updateRequestData.IDOName = "FSSROMatls";
                            updateRequestData.RefreshAfterUpdate = true;

                            IDOUpdateItem updateItem = new IDOUpdateItem();
                            updateItem.Action = UpdateAction.Update;
                            updateItem.Properties.Add("RowPointer", responseData1[0, "RowPointer"].Value, false);
                            updateItem.Properties.Add("RecordDate", responseData1[0, "RecordDate"].Value, false);
                            //updateItem.Properties.Add("ReasonCode", "INN");
                            updateItem.Properties.Add("ReasonCode", ReasonCode);
                            updateRequestData.Items.Add(updateItem);

                            UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                            //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
                            MessageLogging("FSSROMatl Update Reason: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                        }
                        
                    }
                    //Ramu - 20200609.en
                }

                // Serials
                if (SerialList != null && !(SerialList.Equals("")))
                {
                    //Upadate Serial Collection

                    UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                    updateRequestData.IDOName = "FSP.FSSROSerials";
                    updateRequestData.RefreshAfterUpdate = true;


                    if (SerialList != null)
                    {
                        for (int i = 0; i < SerialList.Count(); i++)
                        {
                            IDOUpdateItem serialItem = new IDOUpdateItem();
                            serialItem.Action = UpdateAction.Insert;
                            serialItem.ItemNumber = i;
                            serialItem.Properties.Add("SerNum", formatDataByIDOAndPropertyName("FSSROSerials", "SerNum", SerialList.ElementAt(i).ToString()));
                            serialItem.Properties.Add("SroNum", sroNum);
                            serialItem.Properties.Add("SroLine", sroLine);
                            serialItem.Properties.Add("SroOper", sroOper);
                            serialItem.Properties.Add("TransNum", transNum);
                            serialItem.Properties.Add("Type", "A");
                            serialItem.Properties.Add("Item", item);
                            updateRequestData.Items.Add(serialItem);

                        }
                    }

                    UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                    //changed Console writeline to use the message logging system in the ICSlbase class.  JH:20140108
                    MessageLogging("SROMaterialIssueUpdate: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                    ClearSerailsBySessionID(this.SerialsAsXML);                    
                }
                if (autoPost == 1)
                {
                    object[] PostMaterialFieldVlaues = new object[] { rowPointer, 0, "P", "" };
                    InvokeResponseData invokeResponsePostData = null;
                    try
                    {
                        invokeResponsePostData = this.Context.Commands.Invoke("FSSROMatls", "SSSFSSroTransPostMatlSp", PostMaterialFieldVlaues);

                    }
                    catch (Exception ex)
                    {
                        //Ramu - 20201110.sn  -- logic to rollback the failed, unposted transactional record
                        {
                            string wmShortDateTimePattern = "yyyy-MM-dd";

                            string strippedTransDate = "";
                            strippedTransDate = transDate.Replace(" ", "");
                            strippedTransDate = strippedTransDate.Replace("/", "");
                            strippedTransDate = strippedTransDate.Replace("-", "");

                            string fmtReportDate = DateTime.ParseExact(strippedTransDate, "yyyyMMdd", CultureInfo.CurrentCulture).ToString(wmShortDateTimePattern);
                            LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                            requestData1.IDOName = "FSSROMatls";
                            requestData1.PropertyList.SetProperties("TransType, TransNum, RecordDate, RowPointer");

                            requestData1.Filter = "RowPointer = '" + rowPointer + "' and TransDate = '" + fmtReportDate + "'";
                            requestData1.Filter += " and TransNum = " + transNum;

                            requestData1.RecordCap = 1;

                            LoadCollectionResponseData responseData1 = this.Context.Commands.LoadCollection(requestData1);

                            if (responseData1.Items.Count > 0)
                            {

                                UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                                updateRequestData.IDOName = "FSSROMatls";
                                updateRequestData.RefreshAfterUpdate = true;

                                IDOUpdateItem updateItem = new IDOUpdateItem();
                                updateItem.Action = UpdateAction.Delete;
                                updateItem.Properties.Add("RowPointer", responseData1[0, "RowPointer"].Value, false);
                                updateItem.Properties.Add("RecordDate", responseData1[0, "RecordDate"].Value, false);

                                updateRequestData.Items.Add(updateItem);

                                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                                MessageLogging("FSSROMatl Deletion on Posting failure: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                            }

                        }
                        //Ramu - 20201110.en
                        throw ex;
                    }

                    //InvokeResponseData invokeResponsePostData = this.Context.Commands.Invoke("FSSROMatls", "SSSFSSroTransPostMatlSp", PostMaterialFieldVlaues);
                    
                    if (invokeResponsePostData != null && invokeResponsePostData.ReturnValue != null)
                    {
                        if (!(invokeResponsePostData.ReturnValue.Equals("0")))
                        {
                            //Ramu - 20201110.sn  -- logic to rollback the failed, unposted transactional record
                            {
                                string wmShortDateTimePattern = "yyyy-MM-dd";
                                
                                string strippedTransDate = "";
                                strippedTransDate = transDate.Replace(" ", "");
                                strippedTransDate = strippedTransDate.Replace("/", "");
                                strippedTransDate = strippedTransDate.Replace("-", "");

                                string fmtReportDate = DateTime.ParseExact(strippedTransDate, "yyyyMMdd", CultureInfo.CurrentCulture).ToString(wmShortDateTimePattern);
                                LoadCollectionRequestData requestData1 = new LoadCollectionRequestData();
                                requestData1.IDOName = "FSSROMatls";
                                requestData1.PropertyList.SetProperties("TransType, TransNum, RecordDate, RowPointer");
                                
                                requestData1.Filter = "RowPointer = '" + rowPointer + "' and TransDate = '" + fmtReportDate + "'";
                                requestData1.Filter += " and TransNum = " + transNum;

                                requestData1.RecordCap = 1;
                                
                                LoadCollectionResponseData responseData1 = this.Context.Commands.LoadCollection(requestData1);

                                if (responseData1.Items.Count > 0)
                                {
                                    
                                    UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
                                    updateRequestData.IDOName = "FSSROMatls";
                                    updateRequestData.RefreshAfterUpdate = true;

                                    IDOUpdateItem updateItem = new IDOUpdateItem();
                                    updateItem.Action = UpdateAction.Delete;
                                    updateItem.Properties.Add("RowPointer", responseData1[0, "RowPointer"].Value, false);
                                    updateItem.Properties.Add("RecordDate", responseData1[0, "RecordDate"].Value, false);
                                    
                                    updateRequestData.Items.Add(updateItem);

                                    UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                                    MessageLogging("FSSROMatl Deletion on Posting failure: " + updateResponseData.ToXml(), msgLevel.l1_information, 1200002);
                                }

                            }
                            //Ramu - 20201110.en

                            errorMessage = invokeResponsePostData.Parameters.ElementAt(3).ToString();
                            return false;                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

                if (errorMessage.StartsWith("Exception has been"))
                {
                    errorMessage = Mongoose.Core.Common.MGException.ExtractMessages(ex); 
                    return false;
                    //throw ex;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

        #endregion
    }
}
