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


namespace InforCollect.ERP.SL.ICSLOutBoundTrans.SLDAL
{
    class SLPickListsDAL : IDALBase
    {
        #region Properties
        public string Addr0Name { get; set; }
        public string AddrName { get; set; }
        public string Authorizer { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string CustNum { get; set; }
        public string CustSeq { get; set; }
        public string DerStatusFormatted { get; set; }
        public string InWorkflow { get; set; }
        public string Loc { get; set; }

        public string NoteExistsFlag { get; set; }
        public string PackLoc { get; set; }
        public string PickDate { get; set; }
        public string Picker { get; set; }
        public string PickListId { get; set; }
        public string Printed { get; set; }
        public string RecordDate { get; set; }
        public string RowPointer { get; set; }
        public string ShipTo { get; set; }
        public string Status { get; set; }

        public string UbGroup { get; set; }
        public string UbSelect { get; set; }
        public string UpdatedBy { get; set; }
        public string Whse { get; set; }

        #region MethodSpecific
        public string ProcessId { get; set; }
        public string ShipLoc { get; set; }
        public string Packages { get; set; }
        public string Weight { get; set; }
        public string WeightUm { get; set; }


        #endregion

        #endregion

        public override string propertylist
        {
            get
            {
                string DALPropertyList = "";
                DALPropertyList = DALPropertyList + "Addr0Name,AddrName,Authorizer,CreateDate,CreatedBy,CustNum,CustSeq, ";
                DALPropertyList = DALPropertyList + "DerStatusFormatted,InWorkflow,Loc,NoteExistsFlag,PackLoc,PickDate, ";
                DALPropertyList = DALPropertyList + "Picker,PickListId,Printed,RecordDate,RowPointer,ShipTo, ";
                DALPropertyList = DALPropertyList + "Status,UbGroup,UbSelect,UpdatedBy,Whse";
                return DALPropertyList;
            }
        }

        public SLPickListsDAL(IIDOExtensionClassContext Context)
        {
            base.SetContext(Context);
            base.initialize();
            _idoName = "SLPickLists";
        }


        public override LoadCollectionRequestData GetQueryRquest(string filter = "", int recordCap = -1, string orderby = "PickListId,Whse,PackLoc", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
        {
            LoadCollectionRequestData retVal = null;
            retVal = base.GetQueryRquest(filter, recordCap, orderby, returnProperties, standardFilterincludesCustomFilter);
            return retVal;
        }

        /// <summary>
        /// derived Method to query the IDO to get a sub set of records.  The standard way to call this method is with no paramters and to set the related property with the filter value.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="recordCap"></param>
        /// <param name="orderby"></param>
        /// <param name="returnProperties"></param>
        /// <returns></returns>
        public override string QueryRecords(string filter = "", int recordCap = -1, string orderby = "PickListId,Whse,PackLoc", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
        {
            string retVal = "";

            requestData = GetQueryRquest(filter, recordCap, orderby, returnProperties, standardFilterincludesCustomFilter);
            LoadCollectionResponse = ExcuteQueryRequest(requestData);
            return retVal;
        }

        protected override string constructfilter()
        {
            string retval = "";

            #region Set1
            if ((Addr0Name != "") & (Addr0Name != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Addr0Name like '" + Addr0Name + "'";
            }
            if ((AddrName != "") & (AddrName != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "AddrName like '" + AddrName + "'";
            }
            if ((Authorizer != "") & (Authorizer != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Authorizer like '" + Authorizer + "'";
            }
            if ((CreateDate != "") & (CreateDate != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "CreateDate like '" + CreateDate + "'";
            }
            if ((CreatedBy != "") & (CreatedBy != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "CreatedBy like '" + CreatedBy + "'";
            }

            if ((CustNum != "") & (CustNum != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "CustNum like '" + CustNum + "'";
            }
            if ((CustSeq != "") & (CustSeq != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "CustSeq like '" + CustSeq + "'";
            }
            if ((DerStatusFormatted != "") & (DerStatusFormatted != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "DerStatusFormatted like '" + DerStatusFormatted + "'";
            }
            if ((InWorkflow != "") & (InWorkflow != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "InWorkflow like '" + InWorkflow + "'";
            }
            if ((Loc != "") & (Loc != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Loc like '" + Loc + "'";
            }
            #endregion
            #region Set2
            if ((NoteExistsFlag != "") & (NoteExistsFlag != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "NoteExistsFlag like '" + NoteExistsFlag + "'";
            }
            if ((PackLoc != "") & (PackLoc != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "PackLoc like '" + PackLoc + "'";
            }
            if ((PickDate != "") & (PickDate != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "PickDate like '" + PickDate + "'";
            }
            if ((Picker != "") & (Picker != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Picker like '" + Picker + "'";
            }
            if ((PickListId != "") & (PickListId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "PickListId like '" + PickListId + "'";
            }

            if ((Printed != "") & (Printed != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Printed like '" + Printed + "'";
            }
            if ((RecordDate != "") & (RecordDate != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RecordDate like '" + RecordDate + "'";
            }
            if ((RowPointer != "") & (RowPointer != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RowPointer like '" + RowPointer + "'";
            }
            if ((ShipTo != "") & (ShipTo != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ShipTo like '" + ShipTo + "'";
            }
            if ((Status != "") & (Status != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Status like '" + Status + "'";
            }
            #endregion
            #region Set3
            if ((UbGroup != "") & (UbGroup != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbGroup like '" + UbGroup + "'";
            }
            if ((UbSelect != "") & (UbSelect != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbSelect like '" + UbSelect + "'";
            }
            if ((UpdatedBy != "") & (UpdatedBy != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UpdatedBy like '" + UpdatedBy + "'";
            }
            if ((Whse != "") & (Whse != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Whse like '" + Whse + "'";
            }
            #endregion
            return retval;

        }


        public virtual string InvokeIDOMethod_GenerateShipmentSP()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GenerateShipmentSP");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                case 7:
                    inputValues = new object[]{ ProcessId, ShipLoc, Packages, Weight, WeightUm, "", "" };
                    break; 
                default:
                    inputValues = new object[]{ ProcessId, ShipLoc, Packages, Weight, WeightUm, "" };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "GenerateShipmentSP" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                try
                {
                    InvokeResponse = InvokeIDO(_idoName, "GenerateShipmentSP", inputValues);
                }
                catch (Exception ex)
                {
                    if(ex.InnerException!=null)
                    {
                        message =  "Create Shipment Failed : \r\n" + ex.InnerException.Message;
                        ResetProperties(); //clear the properties and rest for the next run.
                        return message;
                    }
                }
               
                if (!(InvokeResponse.ReturnValue.Equals("0")))
                {
                    return InvokeResponse.Parameters.ElementAt(5).ToString();
                }
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }
        public virtual string InvokeIDOMethod_PackGenerateShipmentSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "PackGenerateShipmentSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ProcessId, 
                                                ShipLoc,                                                
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "PackGenerateShipmentSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                try
                {
                    InvokeResponse = InvokeIDO(_idoName, "PackGenerateShipmentSp", inputValues);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                }
               
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public override string Update()
        {
            string retVal = "";
            updateRequestData.IDOName = IdoName;
            updateRequestData.RefreshAfterUpdate = true;

            _updateItem.Action = UpdateAction.Update;
            _updateItem.Properties.Add("RowPointer", RowPointer, false);
            if (Addr0Name != null) { _updateItem.Properties.Add("Addr0Name", Addr0Name, true); }
            if (AddrName != null) { _updateItem.Properties.Add("AddrName", AddrName, true); }
            if (Authorizer != null) { _updateItem.Properties.Add("Authorizer", Authorizer, true); }
            if (CreateDate != null) { _updateItem.Properties.Add("CreateDate", CreateDate, true); }
            if (CreatedBy != null) { _updateItem.Properties.Add("CreatedBy", CreatedBy, true); }
            if (CustNum != null) { _updateItem.Properties.Add("CustNum", CustNum, true); }
            if (CustSeq != null) { _updateItem.Properties.Add("CustSeq", CustSeq, true); }

            if (DerStatusFormatted != null) { _updateItem.Properties.Add("DerStatusFormatted", DerStatusFormatted, true); }
            if (InWorkflow != null) { _updateItem.Properties.Add("InWorkflow", InWorkflow, true); }
            if (Loc != null) { _updateItem.Properties.Add("Loc", Loc, true); }
            if (NoteExistsFlag != null) { _updateItem.Properties.Add("NoteExistsFlag", NoteExistsFlag, true); }
            if (PackLoc != null) { _updateItem.Properties.Add("PackLoc", PackLoc, true); }
            if (PickDate != null) { _updateItem.Properties.Add("PickDate", PickDate, true); }

            if (Picker != null) { _updateItem.Properties.Add("Picker", Picker, true); }
            if (PickListId != null) { _updateItem.Properties.Add("PickListId", PickListId, false); }
            if (Printed != null) { _updateItem.Properties.Add("Printed", Printed, true); }
            if (RecordDate != null) { _updateItem.Properties.Add("RecordDate", RecordDate, false); }
            if (ShipTo != null) { _updateItem.Properties.Add("ShipTo", ShipTo, true); }

            if (Status != null) { _updateItem.Properties.Add("Status", Status, true); }
            if (UbGroup != null) { _updateItem.Properties.Add("UbGroup", UbGroup, true); }
            if (UbSelect != null) { _updateItem.Properties.Add("UbSelect", UbSelect, true); }
            if (UpdatedBy != null) { _updateItem.Properties.Add("UpdatedBy", UpdatedBy, true); }
            if (ShipTo != null) { _updateItem.Properties.Add("ShipTo", ShipTo, true); }

            updateRequestData.Items.Add(_updateItem);

            UpdateResponse = this.ExecuteUpdateCollection(updateRequestData);

            if (UpdateResponse == null)
            {
                return "Update Failed";
            }
            //Console.WriteLine(UpdateResponse.ToXml());
            MessageLogging("SLPickListsDAL.Update : " + UpdateResponse.ToXml(), msgLevel.l1_information, 1200002);
            ResetProperties();
            return retVal;

        }

        public override string Delete()
        {
            string retVal = "";
            updateRequestData.IDOName = IdoName;
            updateRequestData.RefreshAfterUpdate = false;


            _updateItem.Action = UpdateAction.Delete;

            _updateItem.ItemNumber = 1;
            //_updateItem.ItemID = Item;
            //if (Selected != null) { _updateItem.Properties.Add("_ItemId", Item, false); }
            //else
            //{ _updateItem.Properties.Add("RowPointer", RowPointer, false); }
            _updateItem.Properties.Add("RowPointer", RowPointer, false);
            updateRequestData.Items.Add(_updateItem);

            UpdateResponse = this.ExecuteUpdateCollection(updateRequestData);

            if (UpdateResponse == null)
            {
                return "Update Failed";
            }
            //Console.WriteLine(UpdateResponse.ToXml());

            return retVal;

        }

        public override string ResetProperties()
        {// unused properties must be initalized/reset null because we might want to filter on ''.
            string retVal = "";

            Addr0Name = null; AddrName = null; Authorizer = null; CreateDate = null; CreatedBy = null; CustNum = null; CustSeq = null; DerStatusFormatted = null; InWorkflow = null; Loc = null;
            NoteExistsFlag = null; PackLoc = null; PickDate = null; Picker = null; PickListId = null; Printed = null; RecordDate = null; RowPointer = null; ShipTo = null; Status = null;
            UbGroup = null; UbSelect = null; UpdatedBy = null; Whse = null;

            ProcessId = null; ShipLoc = null; Packages = null; Weight = null; WeightUm = null;

            return retVal;
        }

    }
}
