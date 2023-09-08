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
    class SLShipmentsDAL : IDALBase
    {
        #region Properties

        public string CustNum { get; set; }
        public string CustSeq { get; set; }
        public string DerPickListId { get; set; }
        public string Packer { get; set; }
        public string PickupDate { get; set; }
        public string QtyPackages { get; set; }

        public string RecordDate { get; set; }
        public string RowPointer { get; set; }
        public string ShipCode { get; set; }
        public string ShipCodeDesc { get; set; }
        public string ShipDate { get; set; }
        public string ShipLoc { get; set; }

        public string ShipmentId { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get; set; }
        public string VehNum { get; set; }
        public string Weight { get; set; }
        public string WeightUM { get; set; }

        public string Whse { get; set; }
        public string InWorkflow { get; set; }
        public string NoteExistsFlag { get; set; }
        public string _ItemWarnings { get; set; }
        public string UbSelect { get; set; }
        public string ProNumber { get; set; }
        public string ParentContainerNum { get; set; }
        #region MethodSpecific
        public string Package { get; set; }
        public string OldShipment { get; set; }
        public string OldLine { get; set; }
        public string OldSeq { get; set; }
        public string CreateNewLine { get; set; }
        public string NewShipment { get; set; }
        public string NewLine { get; set; }
        public string Curdate { get; set; }
        public string IgnoreLCR { get; set; }
        public string IgnoreCount { get; set; }
        public string ProcessId { get; set; }
        public string Packages { get; set; }
        public string WeightUm { get; set; }
        public string PickListId { get; set; }
        public string Shipment { get; set; }
        public string TrackingURL { get; set; }

        #endregion

        #endregion

        /// <summary>
        /// Public property that provides a list of valid properties for the IDO
        /// </summary>
        public override string propertylist
        {
            get
            {
                string DALPropertyList = "";
                DALPropertyList = DALPropertyList + "CustNum,CustSeq,DerPickListId, Packer,PickupDate,QtyPackages,";
                DALPropertyList = DALPropertyList + "RecordDate,RowPointer,ShipCode,ShipCodeDesc,ShipDate,ShipLoc,";
                DALPropertyList = DALPropertyList + "ShipmentId,Status,TrackingNumber,VehNum,Weight,WeightUM,";
                DALPropertyList = DALPropertyList + "Whse,InWorkflow,NoteExistsFlag,UbSelect,ProNumber,ParentContainerNum";
                return DALPropertyList;
            }
        }

        public SLShipmentsDAL(IIDOExtensionClassContext Context)
        {
            base.SetContext(Context);
            base.initialize();
            _idoName = "SLShipments";
        }

        /// <summary>
        /// Method to create a request data object with the filter and IDO properties set.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="recordCap"></param>
        /// <param name="orderby"></param>
        /// <param name="returnProperties"></param>
        /// <param name="standardFilterincludesCustomFilter"></param>
        /// <returns></returns>
        public override LoadCollectionRequestData GetQueryRquest(string filter = "", int recordCap = -1, string orderby = "ShipmentId", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
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
        public override string QueryRecords(string filter = "", int recordCap = -1, string orderby = "ShipmentId", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
        {
            string retVal = "";

            requestData = GetQueryRquest(filter, recordCap, orderby, returnProperties, standardFilterincludesCustomFilter);
            LoadCollectionResponse = this.ExcuteQueryRequest(requestData);
            return retVal;
        }

        protected override string constructfilter()
        {
            string retval = "";

            #region Set1
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
            if ((DerPickListId != "") & (DerPickListId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "DerPickListId like '" + DerPickListId + "'";
            }
            if ((Packer != "") & (Packer != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Packer like '" + Packer + "'";
            }
            if ((PickupDate != "") & (PickupDate != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "PickupDate like '" + PickupDate + "'";
            }
            if ((QtyPackages != "") & (QtyPackages != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "QtyPackages like '" + QtyPackages + "'";
            }
            #endregion

            #region Set2
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
            if ((ShipCode != "") & (ShipCode != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ShipCode like '" + ShipCode + "'";
            }
            if ((ShipCodeDesc != "") & (ShipCodeDesc != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ShipCodeDesc like '" + ShipCodeDesc + "'";
            }
            if ((ShipDate != "") & (ShipDate != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ShipDate like '" + ShipDate + "'";
            }
            if ((ShipLoc != "") & (ShipLoc != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ShipLoc like '" + ShipLoc + "'";
            }
            #endregion

            #region Set3
            if ((ShipmentId != "") & (ShipmentId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ShipmentId like '" + ShipmentId + "'";
            }
            if ((Status != "") & (Status != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Status like '" + Status + "'";
            }
            if ((TrackingNumber != "") & (TrackingNumber != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "TrackingNumber like '" + TrackingNumber + "'";
            }
            if ((VehNum != "") & (VehNum != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "VehNum like '" + VehNum + "'";
            }
            if ((Weight != "") & (Weight != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Weight like '" + Weight + "'";
            }
            if ((WeightUM != "") & (WeightUM != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "WeightUM like '" + WeightUM + "'";
            }
            #endregion

            #region Set4
            if ((Whse != "") & (Whse != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Whse like '" + Whse + "'";
            }
            if ((InWorkflow != "") & (InWorkflow != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "InWorkflow like '" + InWorkflow + "'";
            }
            if ((NoteExistsFlag != "") & (NoteExistsFlag != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "NoteExistsFlag like '" + NoteExistsFlag + "'";
            }
            if ((UbSelect != "") & (UbSelect != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbSelect like '" + UbSelect + "'";
            }
            if ((ProNumber != "") & (ProNumber != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ProNumber like '" + ProNumber + "'";
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
                    inputValues = new object[]{ ProcessId, ShipLoc,Packages, Weight, WeightUm,"", "" };
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
                InvokeResponse = InvokeIDO(_idoName, "GenerateShipmentSP", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_GetShipmentInfoSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GetShipmentInfoSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ShipmentId,
                                                Status,
                                                CustNum,
                                                CustSeq,
                                                Whse,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "GetShipmentInfoSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "GetShipmentInfoSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_GetShipmentListSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GetShipmentListSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                PickListId,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "GetShipmentListSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "GetShipmentListSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_GetShipmentTrackingURLSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GetShipmentTrackingURLSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ShipmentId,
                                                TrackingNumber,
                                                TrackingURL
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "GetShipmentTrackingURLSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "GetShipmentTrackingURLSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_PickListValidateSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "PickListValidateSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                PickListId,
                                                CustNum,
                                                CustSeq,
                                                Whse,
                                                ShipLoc,
                                                "",
                                                "",
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "PickListValidateSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "PickListValidateSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_ShipConfirmationSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "ShipConfirmationSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ShipmentId,
                                                Curdate,
                                                IgnoreLCR,
                                                IgnoreCount,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "ShipConfirmationSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "ShipConfirmationSp", inputValues);
                if (!(InvokeResponse.ReturnValue.Equals("0")))
                {
                    return InvokeResponse.Parameters.ElementAt(4).ToString();
                }
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_ShipmentMergeSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "ShipmentMergeSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                OldShipment,
                                                NewShipment,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "ShipmentMergeSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "ShipmentMergeSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_ShipmentSplittingSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "ShipmentSplittingSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                Package,
                                                OldShipment,
                                                OldLine,
                                                OldSeq,
                                                CreateNewLine,
                                                NewShipment,
                                                NewLine,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "ShipmentSplittingSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "ShipmentSplittingSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_UpdateShipmentValueSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "UpdateShipmentValueSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                Shipment,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "UpdateShipmentValueSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "UpdateShipmentValueSp", inputValues);
                if (!(InvokeResponse.ReturnValue.Equals("0")))
                {
                    return InvokeResponse.Parameters.ElementAt(1).ToString();
                }

            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_GeneratePickListTmpSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GeneratePickListTmpSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                case 17:
                    inputValues = new object[]{
                                                ProcessId,
                                                "1",
                                                PickListId,
                                                CustNum,
                                                CustSeq,
                                                Whse,
                                                "", //group
                                                Packer,
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
                    break;
                case 10:
                    inputValues = new object[]{
                                                ProcessId,
                                                "1",
                                                PickListId,
                                                CustNum,
                                                CustSeq,
                                                Whse,
                                                "", //group
                                                Packer,
                                                "",
                                                ""
                                                };
                    break;

                default:

                    inputValues = new object[]{
                                                ProcessId,
                                                "1",
                                                PickListId,
                                                CustNum,
                                                CustSeq,
                                                Whse,
                                                "", //group
                                                Packer,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "GeneratePickListTmpSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "GeneratePickListTmpSp", inputValues);
                if (!(InvokeResponse.ReturnValue.Equals("0")))
                {
                    return InvokeResponse.Parameters.ElementAt(8).ToString();
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
            if (CustNum != null) { _updateItem.Properties.Add("CustNum", CustNum, true); }
            if (CustSeq != null) { _updateItem.Properties.Add("CustSeq", CustSeq, true); }
            if (DerPickListId != null) { _updateItem.Properties.Add("DerPickListId", DerPickListId, true); }
            if (Packer != null) { _updateItem.Properties.Add("Packer", Packer, true); }
            if (PickupDate != null) { _updateItem.Properties.Add("PickupDate", PickupDate, true); }
            if (QtyPackages != null) { _updateItem.Properties.Add("QtyPackages", QtyPackages, true); }

            if (RecordDate != null) { _updateItem.Properties.Add("RecordDate", RecordDate, true); }
            if (ShipCode != null) { _updateItem.Properties.Add("ShipCode", ShipCode, true); }
            if (ShipCodeDesc != null) { _updateItem.Properties.Add("ShipCodeDesc", ShipCodeDesc, true); }
            if (ShipDate != null) { _updateItem.Properties.Add("ShipDate", ShipDate, true); }
            if (ShipLoc != null) { _updateItem.Properties.Add("ShipLoc", ShipLoc, true); }
            if (ParentContainerNum != null) { _updateItem.Properties.Add("ParentContainerNum", ParentContainerNum, true); }

            
            if (ShipmentId != null) { _updateItem.Properties.Add("ShipmentId", ShipmentId, true); }
            if (Status != null) { _updateItem.Properties.Add("Status", Status, true); }
            if (TrackingNumber != null) { _updateItem.Properties.Add("TrackingNumber", TrackingNumber, true); }
            if (VehNum != null) { _updateItem.Properties.Add("VehNum", VehNum, true); }
            if (Weight != null) { _updateItem.Properties.Add("Weight", Weight, true); }
            if (WeightUM != null) { _updateItem.Properties.Add("WeightUM", WeightUM, true); }

            if (Whse != null) { _updateItem.Properties.Add("Whse", Whse, true); }
            if (InWorkflow != null) { _updateItem.Properties.Add("InWorkflow", InWorkflow, true); }
            if (NoteExistsFlag != null) { _updateItem.Properties.Add("NoteExistsFlag", NoteExistsFlag, true); }
            if (UbSelect != null) { _updateItem.Properties.Add("UbSelect", UbSelect, true); }
            if (ProNumber != null) { _updateItem.Properties.Add("ProNumber", ProNumber, true); }
            if (_ItemWarnings != null) { _updateItem.Properties.Add("_ItemWarnings", _ItemWarnings, true); }


            updateRequestData.Items.Add(_updateItem);

            UpdateResponse = this.ExecuteUpdateCollection(updateRequestData);

            if(UpdateResponse == null)
            {
                return "Update Failed ";
            }
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
                return "Update Failed ";
            }

            return retVal;

        }

        public override string ResetProperties()
        {// unused properties must be initalized/reset null because we might want to filter on ''.
            string retVal = "";

            CustNum = null; CustSeq = null; DerPickListId = null; Packer = null; PickupDate = null; QtyPackages = null;
            RecordDate = null; RowPointer = null; ShipCode = null; ShipCodeDesc = null; ShipDate = null; ShipLoc = null;
            ShipmentId = null; Status = null; TrackingNumber = null; VehNum = null; Weight = null; WeightUM = null; Whse = null;
            InWorkflow = null; NoteExistsFlag = null; _ItemWarnings = null; UbSelect = null; ProNumber = null; ParentContainerNum = null;

            #region MethodSpecific

            Package = null; OldShipment = null; OldLine = null; OldSeq = null; CreateNewLine = null; NewShipment = null;
            NewLine = null; Curdate = null; IgnoreLCR = null; IgnoreCount = null; ProcessId = null; Packages = null;
            WeightUm = null; PickListId = null; Shipment = null; TrackingURL = null;

            #endregion
            return retVal;
        }

    }
}
