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


namespace InforCollect.ERP.SL.ICSLInventoryCountTrans
{
    class InventoryCountUtilities : ICSLCommonLibrary
    {

        new public void ClearSerailsBySessionID(string SessionID)
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
                serialItem.Properties.Add("RowPointer", responseData[i, "RowPointer"].ToString());
                serialItem.Properties.Add("RecordDate", responseData[i, "RecordDate"].ToString());
                updateRequestData.Items.Add(serialItem);
            }

            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            }
            catch (Exception)
            {
            }


        }

        public bool ObsSlowSp(string Item, bool AllowIfSlowMoving, out string ErrorMessage)
        {
            ErrorMessage = "";
            object[] InputParams = new object[] { Item, (AllowIfSlowMoving ? "0" : "1"), "0", "0", "1", "", "", "", "" };
            InvokeResponseData invokeResponseDataStep1 = InvokeIDO("SLItems", "ObsSlowSp", InputParams);

            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                return true;
            }

            ErrorMessage = invokeResponseDataStep1.Parameters.ElementAt(5).ToString();
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


        public bool checkLocationDetails(string item, string whse, string site, string loc,ref string InfoBar)
        {
            InfoBar = "";
            object[] step1Params = new object[] { item, whse, site, loc, "", "", "", "" };

            InvokeResponseData invokeResponseDataStep1 = this.InvokeIDO("SLTrnacts", "TrnShipLocValidSp", step1Params);
            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                if (invokeResponseDataStep1.Parameters.ElementAt(4).ToString().Equals("1"))
                {
                    InfoBar = constructErrorMessage(invokeResponseDataStep1.Parameters.ElementAt(5).ToString(), "-2", null);
                    return false;
                }
                return true;
            }

            InfoBar = constructErrorMessage(invokeResponseDataStep1.Parameters.ElementAt(7).ToString(), "-3", null);
            return false;
        }

        public string GetItemConvertedQtyToBaseUnit(string item, string qty, string uom, string vendorNum, ref string InfoBar)
        {
            InfoBar = "";
            object[] step1Params = new object[] { uom, item, vendorNum, "", "1", qty, "", "" };
            InvokeResponseData invokeResponseDataStep1 = this.InvokeIDO("SLUMs", "UMConvQtySp", step1Params);
            if (invokeResponseDataStep1.ReturnValue.Equals("0"))
            {
                return invokeResponseDataStep1.Parameters.ElementAt(6).ToString();
            }
            InfoBar = constructErrorMessage(invokeResponseDataStep1.Parameters.ElementAt(7).ToString(), "-1", null);
            return null;
        }

        
    }
}
