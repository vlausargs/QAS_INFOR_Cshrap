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
    class PickPackShipPickListConfirmUpdate : OutBoundUtilities
    {
        //Input Variables.
        string picklistID = "";
        string picker = "";
        string packLocation = "";
        string errorMessage = ""; //added to keep track of the local error message.  On a error this 
        //  will be passed back to the calling method.  JH:20131217
        
        private ICSLOutBoundTrans.SLDAL.SLPickListsDAL DAL;
        


        public PickPackShipPickListConfirmUpdate(string picklistID,string picker, string packLocation)
        {
            initialize();

            this.picklistID = picklistID;
            this.picker = picker;
            this.packLocation = packLocation;
            errorMessage = "";
        }

        public void initialize()
        {
            //Input variables initialization
            picklistID = "";
            picker="";
            packLocation = "";
        }


        public bool formatInputs()
        {
           
            if (picklistID == "")
            {
                errorMessage = "picklistID input mandatory" ;
                return false;
            }
            return true;
        }

        private bool validateInputs()
        {
            bool retVal = true;

            return retVal;
        }
        public int PerformUpdate(out string Infobar)
       // public string processMessage()
        {
            Infobar = "";  
            if (formatInputs( ) == false)
            {
                Infobar = errorMessage;
                return 1;
            }

            validateInputs( );

            if (performUpdate() == false)
            {
                Infobar = errorMessage;
                return 3;
            }            
            return 0;
        }

        private bool performUpdate()
        {
            //bool retVal = true;
            //string msg = "";

            DAL = new ICSLOutBoundTrans.SLDAL.SLPickListsDAL(this.Context);

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLPickLists";
            requestData.PropertyList.SetProperties("PickListId,RecordDate, RowPointer, Status,Whse,PackLoc");

            string filterString = "PickListId = '" + this.picklistID + "'";
            requestData.Filter = filterString;
            requestData.RecordCap = 0;
            requestData.OrderBy = "PickListId";
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);


            /*LoadCollectionResponseData DALResponseData = null;

            LoadCollectionRequestData DALRequest = null;

            DAL.PickListId = picklistID;

            DALRequest = DAL.GetQueryRquest();

            DALResponseData = ExcuteQueryRequest (DALRequest);

            if (DALResponseData.Items.Count == 0)
            {
                constructErrorMessage("Pick list details not found", "PPSS0002", null);
                return false;
            }

            if (DALResponseData[0, "Status"].Value != "O")
            {//error
                errorMessage = constructErrorMessage("Pick list does not have a status of Open.", "PPS00011", null);
                return false;
            }*/

            if (responseData.Items.Count == 0)
            {
                constructErrorMessage("Pick list details not found", "PPSS0002", null);
                return false;
            }

            if (responseData[0, "Status"].Value != "O")
            {//error
                errorMessage = constructErrorMessage("Pick list does not have a status of Open.", "PPS00011", null);
                return false;
            }

            //DAL.RowPointer = GetPropertyValue(DALResponseData, "RowPointer");
            //DAL.RecordDate = GetPropertyValue(DALResponseData, "RecordDate");
            /*DAL.RowPointer = responseData[0, "RowPointer"].Value;
            DAL.RecordDate = responseData[0, "RecordDate"].Value;
            DAL.Status = "P";
            DAL.Picker = "Scanner";

            msg = DAL.Update();
            if (msg != "")
            {
                errorMessage = msg;
                return false;
            }

            return retVal;*/

            LoadCollectionRequestData requestRefData = new LoadCollectionRequestData
            {
                IDOName = "SLPickListRefs",
                Filter = $"PickListId = '{this.picklistID}' AND QtyPicked=0",
                RecordCap = 0,
                OrderBy = "PickListId"
            };
            requestRefData.PropertyList.SetProperties("PickListId,RecordDate, RowPointer, QtyPicked");
            
            LoadCollectionResponseData responseRefData = ExcuteQueryRequest(requestRefData);
            if (responseRefData == null)
            {
                errorMessage = constructErrorMessage("Update Failed", string.Empty, null);
                return false;
            }

            UpdateCollectionRequestData updateRefRequestData = new UpdateCollectionRequestData
            {
                IDOName = "SLPickListRefs",
                RefreshAfterUpdate = false
            };

            for (int j = 0; j < responseRefData.Items.Count; j++)
            {
                IDOUpdateItem _updateRefItem = new IDOUpdateItem
                {
                    ItemID = responseRefData.Items[j].ItemID,
                    Action = UpdateAction.Delete
                };
                _updateRefItem.Properties.Add("RowPointer", responseRefData[j, "RowPointer"].Value, false);
                updateRefRequestData.Items.Add(_updateRefItem);
            }

            try
            {
                UpdateCollectionResponseData updateRefResponseData = this.Context.Commands.UpdateCollection(updateRefRequestData);
                if (updateRefResponseData == null)
                {
                    errorMessage = constructErrorMessage("Update Failed", string.Empty, null);
                    return false;
                }
            }
            catch (Exception ee)
            {
                errorMessage = constructErrorMessage("Update Failed " + ee.Message, string.Empty, null);
                return false;
            }

            UpdateCollectionRequestData updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName = "SLPickLists";
            updateRequestData.RefreshAfterUpdate = false;

            IDOUpdateItem _updateItem = new IDOUpdateItem();
            _updateItem.ItemID = responseData.Items[0].ItemID;
            _updateItem.Action = UpdateAction.Update;

            _updateItem.Properties.Add("RowPointer", responseData[0,"RowPointer"].Value, false);
            _updateItem.Properties.Add("Status", "P", true);
             _updateItem.Properties.Add("Whse", responseData[0,"Whse"].Value, false);
             _updateItem.Properties.Add("PackLoc", this.packLocation, true);
             _updateItem.Properties.Add("Picker", this.picker, true);
            updateRequestData.Items.Add(_updateItem);

            try
            {
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                if (updateResponseData == null)
                {
                    errorMessage = "Update Failed";
                    return false;
                }
            }
            catch (Exception ee)
            {
                errorMessage = constructErrorMessage("Update Failed " + ee.Message, "", null);
                return false;

            }


            return true;

        }
    }
}