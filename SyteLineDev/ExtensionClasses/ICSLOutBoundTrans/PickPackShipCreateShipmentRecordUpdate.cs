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
    class PickPackShipCreateShipmentRecordUpdate : OutBoundUtilities
    {
      
        //original picklist information to identify the record.
        string picklistID = "";
        string packer = "";
        string packagecount = ""; //optional value to set the number of packages
        string weight = ""; //optional value to set the weight of the shipment
        string weightum = ""; //optional value to set the weight unit of measure

        //data used to identify the record in the tmp table.
        string ProcessGUID = "";
        string sessionID = "";        
        private ICSLOutBoundTrans.SLDAL.SLPickListsDAL DAL;
        private ICSLOutBoundTrans.SLDAL.SLShipmentsDAL ShipmentDAL;
        private ICSLOutBoundTrans.SLDAL.SLTmpPickListLocsDAL TmpPickListLocsDAL;

        private string errorMessage = "";

        public PickPackShipCreateShipmentRecordUpdate(string picklistID, string packer, string packagecount,
                                                      string weight, string weightum, string sessionID)
        {
            initialize();
            this.picklistID = picklistID;
            this.packer = packer;
            this.packagecount = packagecount;
            this.weight = weight;
            this.weightum = weightum;

            this.sessionID = sessionID;            
        }


        public void initialize()
        {
            //Input variables initialization
            picklistID = "";
            packer = "";
            packagecount = "";
            weight = "";
            weightum = "";
            sessionID = "";           

        }

        public bool formatInputs()
        {
          
            if (picklistID == "")
            {//this is required.
                errorMessage = constructErrorMessage("picklistID input mandatory", "PPSCSR0001", null);
                return false;
            }
            picklistID = picklistID.Trim();
            return true;
        }

        public bool validateInputs()
        {
            bool retVal = true;
            return retVal;
        }


        public int PerformUpdate(out string InfoBar)
        {
            InfoBar = "";
            DAL = new ICSLOutBoundTrans.SLDAL.SLPickListsDAL(this.Context);
            ShipmentDAL = new ICSLOutBoundTrans.SLDAL.SLShipmentsDAL(this.Context);
            TmpPickListLocsDAL =  new ICSLOutBoundTrans.SLDAL.SLTmpPickListLocsDAL(this.Context);

            
           
            if (formatInputs() == false)
            {
                InfoBar = errorMessage;
                return 1;
            }

            validateInputs( );

            if (preformUpdate() == false)
            {
                InfoBar = errorMessage;
                return 3;
            }
           // retVal = createSuccessUpdateResponse(null);            
            return 0;
        }

        private bool preformUpdate()
        {
            bool retVal = true;
            string msg = "";
            LoadCollectionResponseData DALResponseData = null;

            GenerateGUID(ref ProcessGUID,ref errorMessage);

            //load the pick list data.
            DAL.PickListId = picklistID;
            msg = DAL.QueryRecords(recordCap: 1);
            if (msg == "")
            {
                DALResponseData = DAL.LoadCollectionResponse;
            }
            else
            {//error. most likely the pick list was not found.
                errorMessage = constructErrorMessage("Pick list details not found", "PPS00010", null);
                return false;
            }

            if (DALResponseData.Items.Count > 0)
            {
                if (DALResponseData[0, "Status"].Value != "P")
                {//error
                    errorMessage = constructErrorMessage("Pick list does not have a status of picked.", "PPS00011", null);
                    return false;
                }
                ShipmentDAL.ProcessId = ProcessGUID;
                ShipmentDAL.PickListId = picklistID;
                ShipmentDAL.CustNum = DALResponseData[0, "CustNum"].Value;
                ShipmentDAL.CustSeq = DALResponseData[0, "CustSeq"].Value;
                ShipmentDAL.Whse = DALResponseData[0, "Whse"].Value;  //should be the user's warehouse = picklist whse.            
                if (packer == "")
                {
                    ShipmentDAL.Packer = DALResponseData[0, "Authorizer"].Value;  //should be user name rather than sl user number/id
                }
                else { ShipmentDAL.Packer = packer; }
                msg = ShipmentDAL.InvokeIDOMethod_GeneratePickListTmpSp();
            }
            else
            {//no pick list error.
            }
            if (msg != "")
            {//error. 
                //msg = errorMessage;
                errorMessage = msg;
                return false;
            }
            DAL.ProcessId = ProcessGUID;
            if (DAL.ShipLoc == null || DAL.ShipLoc =="")
            {
                DAL.ShipLoc = GetInvParamValue("ShipLoc");
            } //should provide.
            DAL.Packages = packagecount;
            DAL.Weight = weight;
            DAL.WeightUm = weightum;
            msg = DAL.InvokeIDOMethod_GenerateShipmentSP();//returns failure message               
            if (msg != "")
            {//error. 
                //msg = errorMessage;
                errorMessage = msg;
                return false;
            }
            TmpPickListLocsDAL.ProcessID = ProcessGUID;
            TmpPickListLocsDAL.InvokeIDOMethod_PurgeTmpPickListLocSerialSp(); //Make sure we cleanup after our self.
            return retVal;
        }
        
    }
}