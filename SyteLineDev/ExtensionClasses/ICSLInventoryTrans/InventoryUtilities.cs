using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Xml.Linq;
using System.Xml;


namespace InforCollect.ERP.SL.ICSLInventoryTrans
{
    class InventoryUtilities : ICSLCommonLibrary
    {

      /*  public void ClearSerailsBySessionID(string SessionID)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "TABLE!tmp_ser";
            requestData.PropertyList.SetProperties("RowPointer,RecordDate");
            requestData.Filter = "SessionID = '" + SessionID + "'";
            requestData.RecordCap = -1;
            requestData.OrderBy = "ser_num";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            if (responseData.Items.Count == 0)
            {
                return;
            }

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "TABLE!tmp_ser"; 

            for (int i = 0; i < responseData.Items.Count; i++)
            {
                IDOUpdateItem serialItem = new IDOUpdateItem();
                serialItem.Action = UpdateAction.Delete;
                serialItem.ItemNumber = i;
                serialItem.Properties.Add("RowPointer", responseData[i,"RowPointer"].ToString());
                serialItem.Properties.Add("RecordDate", responseData[i,"RecordDate"].ToString());
                updateRequestData.Items.Add(serialItem);
            }

            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            }
            catch (Exception e)
            {
            }


        } */

        public bool ObsSlowSp(string Item,bool AllowIfSlowMoving, out string ErrorMessage)
        {
            ErrorMessage = "";
            object[] InputParams = new object[] {Item,(AllowIfSlowMoving?"0":"1"),"0","0","1","","","",""};
            InvokeResponseData invokeResponseDataStep1 = InvokeIDO("SLItems", "ObsSlowSp", InputParams);
            
            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                return true;
            }

            ErrorMessage = invokeResponseDataStep1.Parameters.ElementAt(5).ToString() ;
            return false;
        }

        public bool ValidateImportID(string ImportID, out string ErrorMessage)
        {
            ErrorMessage = "";
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLTaxFreeImports";
            requestData.PropertyList.SetProperties("ImportDocId");
            requestData.RecordCap = 1;
            requestData.OrderBy = "ImportDocId";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            if (responseData.Items.Count == 0)
            {
                //mIsNotAValid
                ErrorMessage = "Import ID: " + ImportID + " Is Not Valid";
                return false;
            }
            return true;
        }

        public bool ValidateContainer(string ContainerNum,string Whse, String Loc, out string ErrorMessage)
        {
            ErrorMessage = "";

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLContainers";
            requestData.PropertyList.SetProperties("ContainerNum");
            requestData.RecordCap = 1;
            requestData.OrderBy = "SLContainers";
            requestData.Filter = "Whse = '" + Whse + "' AND Loc = '" + Loc + "' AND CHARINDEX(RefType, ISNULL('','IKJO'))>0 AND ContainerNum = '"+ContainerNum+"'";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            if (responseData.Items.Count == 0)
            {
                //mIsNotAValid
                ErrorMessage = "Container Num: " + ContainerNum + " Is Not Valid";
                return false;
            }
            return true;
        }
        /*
        public bool ValidateContainerExist(string ContainerNum, string Whse, String Loc,bool containerLocMismatch, out string ErrorMessage)
        {
            ErrorMessage = "";

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLContainers";
            requestData.PropertyList.SetProperties("ContainerNum,Whse,Loc");
            requestData.RecordCap = 1;
           
            //requestData.Filter = "Whse = '" + Whse + "' AND Loc = '" + Loc + "' AND CHARINDEX(RefType, ISNULL('','IKJO'))>0 AND ContainerNum = '" + ContainerNum + "'";
            requestData.Filter = "ContainerNum = '" + ContainerNum + "'";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            if (responseData.Items.Count == 0)
            {
                // Container does not exists   
                return false;
            }
            else
            { 
                // Container exists in the system
                if ((!(Whse.Trim().Equals(responseData[0, "Whse"].ToString())) || (!Loc.Trim().Equals(responseData[0, "Loc"].ToString()))))
                {
                    containerLocMismatch = true;
                }
                else
                {
                    containerLocMismatch = false;
                }
                return true;
            }
             
        }
        public bool PerformCreateContainer(string containerNum, string whse, string loc, out string errorMessage)
        {
            errorMessage = "";
            object[] inputValues = new object[]{
                                                containerNum,
                                                whse,
                                                loc,
                                                ""
                                                };

            InvokeResponseData invokeResponseData = this.InvokeIDO("SLContainers", "ContainerAddSp", inputValues);
            if (!(invokeResponseData.ReturnValue.Equals("0")))
            {
                errorMessage = invokeResponseData.Parameters.ElementAt(3).ToString();
                return false;
            }

            return true;
        }

        public bool checkAdjReasonCodes(string reasonCode,string transactionType,string item,string containerFlag,out string accountCode,
            out string accountUnit1, out string accountUnit2, out string accountUnit3, out string accountUnit4, out string errorMessage)
        {
            accountCode = accountUnit1 = accountUnit2 = accountUnit3 = accountUnit4 = errorMessage = "";
            LoadCollectionResponseData reasonValidateResponseData = GetReasonCodeDetails(reasonCode, transactionType);
            if (reasonValidateResponseData.Items.Count == 0)
            {
                errorMessage = "Reason Code : " + reasonCode + " Not Found";
                return false;
            }
            InvokeResponseData reasonCodeResData = null;
            object[] reasonCodeValues; //added for SL9 Qualification.  JH:20130708
            int paramcount = 0; //added for SL9 Qualification.  JH:20130708
            paramcount = GetIDOMethodParameterCount("SLReasons", "ReasonGetInvAdjAcctSp");
            switch (paramcount)
            {
                case 16: //added for SL9 Qualification.  JH:20130708
                    reasonCodeValues = new object[] { reasonCode, 
                                                      transactionType, 
                                                      item, 
                                                      "", 
                                                      "", 
                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                      "", //10

                                                      "",
                                                      "",
                                                      "",
                                                      "",
                                                     containerFlag,
                                                      ""
                                                        };
                    break;
                case 14:
                default: //the default case is 14 
                    reasonCodeValues = new object[] { reasonCode, 
                                                      "MISC ISSUE", 
                                                      item, 
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
                                                      ""};
                    break;
            }

            reasonCodeResData = this.Context.Commands.Invoke("SLReasons", "ReasonGetInvAdjAcctSp", reasonCodeValues);
            if (!(reasonCodeResData.ReturnValue.Equals("0")))
            {
                errorMessage = reasonCodeResData.Parameters.ElementAt(13).ToString();
                return false;
            }
            else
            { 
                accountCode = reasonCodeResData.Parameters.ElementAt(3).ToString();
                accountUnit1 = reasonCodeResData.Parameters.ElementAt(4).ToString();
                accountUnit2 = reasonCodeResData.Parameters.ElementAt(5).ToString();
                accountUnit3 =reasonCodeResData.Parameters.ElementAt(6).ToString();
                accountUnit4 = reasonCodeResData.Parameters.ElementAt(7).ToString();
            }
            return true;
        } */


    }
}
