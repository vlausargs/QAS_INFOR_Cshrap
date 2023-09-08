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
    class SLShipmentPackagesDAL : IDALBase
    {
        
   
   
#region Properties

     public string CreateDate{ get; set; }
     public string CreatedBy{ get; set; }
     public string DerPacked{ get; set; }
     public string DerRefPackaged{ get; set; }
     public string DerTrackingNumber{ get; set; }
     public string Description{ get; set; }

     public string Hazard{ get; set; }
     public string InWorkflow{ get; set; }
     public string MarksExcept{ get; set; }
     public string NMFC	{ get; set; }
     public string NoteExistsFlag{ get; set; }
     public string PackageId{ get; set; }

     public string PackageType{ get; set; }
     public string RateCode	{ get; set; }
     public string RecordDate{ get; set; }
     public string RefPackageId{ get; set; }
     public string RowPointer{ get; set; }
     public string ShipmentId{ get; set; }

     public string UbConsigneeName{ get; set; }
     public string UbCustItem{ get; set; }
     public string UbCustNum{ get; set; }
     public string UbCustSeq{ get; set; }
     public string UbItem{ get; set; }
     public string UbItemDescription{ get; set; }

     public string UbLabelBy{ get; set; }
     public string UbLocation{ get; set; }
     public string UbLot{ get; set; }
     public string UbManufacturerId{ get; set; }
     public string UbManufacturerItem{ get; set; }
     public string UbManufacturerItemDesc{ get; set; }

     public string UbManufacturerName{ get; set; }
     public string UbNumberOfLabels{ get; set; }
     public string UbPackagesExist{ get; set; }
     public string UbQty{ get; set; }
     public string UbQtyPerLabel{ get; set; }
     public string UbSelect{ get; set; }

     public string UbSite{ get; set; }
     public string UbUM{ get; set; }
     public string UbWhse{ get; set; }
     public string UpdatedBy{ get; set; }
     public string Weight{ get; set; }
#endregion
     #region MethodSpecific
     public string ProcessId { get; set; }
        public string ShipmentID { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingURL { get; set; }
        public string UbTemplatePath { get; set; }
        public string UbOutputPath { get; set; }
    #endregion


        /// <summary>
        /// Public property that provides a list of valid properties for the IDO
        /// </summary>
        public override string propertylist
        {
            get
            {
                string DALPropertyList = "";
                DALPropertyList = DALPropertyList + "CreateDate,CreatedBy,DerPacked,DerRefPackaged,DerTrackingNumber,Description,";
                DALPropertyList = DALPropertyList + "Hazard,InWorkflow,MarksExcept,NMFC,NoteExistsFlag,PackageId,";
                DALPropertyList = DALPropertyList + "PackageType,RateCode,RecordDate,RefPackageId,RowPointer,ShipmentId,";
                DALPropertyList = DALPropertyList + "UbConsigneeName,UbCustItem,UbCustNum,UbCustSeq,UbItem,UbItemDescription,";
                DALPropertyList = DALPropertyList + "UbLabelBy,UbLocation,UbLot,UbManufacturerId,UbManufacturerItem,UbManufacturerItemDesc,";
                DALPropertyList = DALPropertyList + "UbManufacturerName,UbNumberOfLabels,UbPackagesExist,UbQty,UbQtyPerLabel,UbSelect,";
                DALPropertyList = DALPropertyList + "UbSite,UbUM,UbWhse,UpdatedBy,Weight";	
                return DALPropertyList;
            }
        }
         public SLShipmentPackagesDAL(IIDOExtensionClassContext Context)
        {
            base.SetContext(Context);
            base.initialize();
            _idoName = "SLShipmentPackages";  
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
        public override LoadCollectionRequestData GetQueryRquest(string filter = "", int recordCap = -1, string orderby = "ShipmentId, PackageId", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
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
        public override string QueryRecords(string filter = "", int recordCap = -1, string orderby = "ShipmentId, PackageId", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
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
            if ((DerPacked != "") & (DerPacked != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "DerPacked like '" + DerPacked + "'";
            }
            if ((DerRefPackaged != "") & (DerRefPackaged != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "DerRefPackaged like '" + DerRefPackaged + "'";
            }
            if ((DerTrackingNumber != "") & (DerTrackingNumber != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "DerTrackingNumber like '" + DerTrackingNumber + "'";
            }
            if ((Description != "") & (Description != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Description like '" + Description + "'";
            }
            #endregion

            #region Set2
            if ((Hazard != "") & (Hazard != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Hazard like '" + Hazard + "'";
            }
            if ((InWorkflow != "") & (InWorkflow != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "InWorkflow like '" + InWorkflow + "'";
            }
            if ((MarksExcept != "") & (MarksExcept != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "MarksExcept like '" + MarksExcept + "'";
            }
            if ((NMFC != "") & (NMFC != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "NMFC like '" + NMFC + "'";
            }
            if ((NoteExistsFlag != "") & (NoteExistsFlag != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "NoteExistsFlag like '" + NoteExistsFlag + "'";
            }
            if ((PackageId != "") & (PackageId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "PackageId like '" + PackageId + "'";
            }
            #endregion

            #region Set3
            if ((PackageType != "") & (PackageType != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "PackageType like '" + PackageType + "'";
            }
            if ((RateCode != "") & (RateCode != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RateCode like '" + RateCode + "'";
            }
            if ((RecordDate != "") & (RecordDate != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RecordDate like '" + RecordDate + "'";
            }
            if ((RefPackageId != "") & (RefPackageId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RefPackageId like '" + RefPackageId + "'";
            }
            if ((RowPointer != "") & (RowPointer != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RowPointer like '" + RowPointer + "'";
            }
            if ((ShipmentId != "") & (ShipmentId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ShipmentId like '" + ShipmentId + "'";
            }
            #endregion

            #region Set4
            if ((UbConsigneeName != "") & (UbConsigneeName != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbConsigneeName like '" + UbConsigneeName + "'";
            }
            if ((UbCustItem != "") & (UbCustItem != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbCustItem like '" + UbCustItem + "'";
            }
            if ((UbCustNum != "") & (UbCustNum != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbCustNum like '" + UbCustNum + "'";
            }
            if ((UbCustSeq != "") & (UbCustSeq != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbCustSeq like '" + UbCustSeq + "'";
            }
            if ((UbItem != "") & (UbItem != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbItem like '" + UbItem + "'";
            }
            if ((UbItemDescription != "") & (UbItemDescription != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbItemDescription like '" + UbItemDescription + "'";
            }
            #endregion

            #region Set5
            if ((UbLabelBy != "") & (UbLabelBy != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbLabelBy like '" + UbLabelBy + "'";
            }
            if ((UbLocation != "") & (UbLocation != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbLocation like '" + UbLocation + "'";
            }
            if ((UbLot != "") & (UbLot != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbLot like '" + UbLot + "'";
            }
            if ((UbManufacturerId != "") & (UbManufacturerId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbManufacturerId like '" + UbManufacturerId + "'";
            }
            if ((UbManufacturerItem != "") & (UbManufacturerItem != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbManufacturerItem like '" + UbManufacturerItem + "'";
            }
            if ((UbManufacturerItemDesc != "") & (UbManufacturerItemDesc != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbManufacturerItemDesc like '" + UbManufacturerItemDesc + "'";
            }
            #endregion

            #region Set6
            if ((UbManufacturerName != "") & (UbManufacturerName != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbManufacturerName like '" + UbManufacturerName + "'";
            }
            if ((UbNumberOfLabels != "") & (UbNumberOfLabels != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbNumberOfLabels like '" + UbNumberOfLabels + "'";
            }
            if ((UbPackagesExist != "") & (UbPackagesExist != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbPackagesExist like '" + UbPackagesExist + "'";
            }
            if ((UbQty != "") & (UbQty != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbQty like '" + UbQty + "'";
            }
            if ((UbQtyPerLabel != "") & (UbQtyPerLabel != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbQtyPerLabel like '" + UbQtyPerLabel + "'";
            }
            if ((UbSelect != "") & (UbSelect != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbSelect like '" + UbSelect + "'";
            }
            #endregion

            #region Set7
            if ((UbSite != "") & (UbSite != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbSite like '" + UbSite + "'";
            }
            if ((UbUM != "") & (UbUM != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbUM like '" + UbUM + "'";
            }
            if ((UbWhse != "") & (UbWhse != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UbWhsem like '" + UbWhse + "'";
            }
            if ((UpdatedBy != "") & (UpdatedBy != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UpdatedBy like '" + UpdatedBy + "'";
            }
            if ((Weight != "") & (Weight != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Weight like '" + Weight + "'";
            }
          
            #endregion
            
            return retval;

        }


        public virtual string InvokeIDOMethod_CLM_PackageLabelsSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "CLM_PackageLabelsSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:
                    
                    inputValues = new object[]{
                                                ShipmentID,
                                                UbLabelBy,
                                                UbSite
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "CLM_PackageLabelsSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "CLM_PackageLabelsSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_GeneratePackagePackageSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            //Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            //IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GeneratePackagePackageSp");


            //based on the number of parameters on the ido/method create the input values.
            //switch (IDOMethodParamCount)
            //{
            //    default:

                    inputValues = new object[]{
                                                ProcessId,
                                                PackageId,
                                                ""
                                                };
            //        break;
            //}

            //CallingParamCount = inputValues.Length;
            //if (IDOMethodParamCount != CallingParamCount)
            //{
               
            //    message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "GeneratePackagePackageSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
            //    WriteError(message);
            //}
            //else
            //{
                InvokeResponse = InvokeIDO(_idoName, "GeneratePackagePackageSp", inputValues);
            //}
            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_GenerateTmpShipSeqPackageSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GenerateTmpShipSeqPackageSp");
            if (Hazard == "" || Hazard == null || Hazard == "null"){ Hazard = "0"; } //hazard can not be null or "" JH:20121114

            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ProcessId,
                                                UbSelect,
                                                ShipmentId,
                                                PackageId,
                                                PackageType,
                                                RateCode,
                                                NMFC,
                                                Weight,
                                                Hazard,
                                                Description,
                                                MarksExcept,
                                                RefPackageId,                                                
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            InvokeResponse = InvokeIDO(_idoName, "GenerateTmpShipSeqPackageSp", inputValues);
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
                                                ShipmentID,
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

        public virtual string InvokeIDOMethod_LabelPathsExistSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "LabelPathsExistSp");
           switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                UbTemplatePath,
                                                UbOutputPath
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "LabelPathsExistSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "LabelPathsExistSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_PackagesExistSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "PackagesExistSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ShipmentID,
                                                UbPackagesExist
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "PackagesExistSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "PackagesExistSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_ValidateShipmentPackageSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "ValidateShipmentPackageSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ShipmentID,
                                                PackageId,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "ValidateShipmentPackageSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "ValidateShipmentPackageSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public override string Update()
        {
            string retVal = "";
            updateRequestData.IDOName = IdoName;
            updateRequestData.RefreshAfterUpdate = false;

            _updateItem.Action = UpdateAction.Update;
            _updateItem.Properties.Add("RowPointer", RowPointer, false);
            if (CreateDate != null) { _updateItem.Properties.Add("CreateDate", CreateDate, true); }
            if (CreatedBy != null) { _updateItem.Properties.Add("CreatedBy", CreatedBy, true); }
            if (DerPacked != null) { _updateItem.Properties.Add("DerPacked", DerPacked, true); }
            if (DerRefPackaged != null) { _updateItem.Properties.Add("DerRefPackaged", DerRefPackaged, true); }
            if (DerTrackingNumber != null) { _updateItem.Properties.Add("DerTrackingNumber", DerTrackingNumber, true); }
            if (Description != null) { _updateItem.Properties.Add("Description", Description, true); }

            if (Hazard != null) { _updateItem.Properties.Add("Hazard", Hazard, true); }
            if (InWorkflow != null) { _updateItem.Properties.Add("InWorkflow", InWorkflow, true); }
            if (MarksExcept != null) { _updateItem.Properties.Add("MarksExcept", MarksExcept, true); }
            if (NMFC != null) { _updateItem.Properties.Add("NMFC", NMFC, true); }
            if (NoteExistsFlag != null) { _updateItem.Properties.Add("NoteExistsFlag", NoteExistsFlag, true); }
            if (PackageId != null) { _updateItem.Properties.Add("PackageId", PackageId, true); }

            if (PackageType != null) { _updateItem.Properties.Add("PackageType", PackageType, true); }
            if (RateCode != null) { _updateItem.Properties.Add("RateCode", RateCode, true); }
            if (RecordDate != null) { _updateItem.Properties.Add("RecordDate", RecordDate, true); }
            if (RefPackageId != null) { _updateItem.Properties.Add("RefPackageId", RefPackageId, true); }
            if (ShipmentId != null) { _updateItem.Properties.Add("ShipmentId", ShipmentId, true); }

            if (UbConsigneeName != null) { _updateItem.Properties.Add("UbConsigneeName", UbConsigneeName, true); }
            if (UbCustItem != null) { _updateItem.Properties.Add("UbCustItem", UbCustItem, true); }
            if (UbCustNum != null) { _updateItem.Properties.Add("UbCustNum", UbCustNum, true); }
            if (UbCustSeq != null) { _updateItem.Properties.Add("UbCustSeq", UbCustSeq, true); }
            if (UbItem != null) { _updateItem.Properties.Add("UbItem", UbItem, true); }
            if (UbItemDescription != null) { _updateItem.Properties.Add("UbItemDescription", UbItemDescription, true); }

            if (UbLabelBy != null) { _updateItem.Properties.Add("UbLabelBy", UbLabelBy, true); }
            if (UbLocation != null) { _updateItem.Properties.Add("UbLocation", UbLocation, true); }
            if (UbLot != null) { _updateItem.Properties.Add("UbLot", UbLot, true); }
            if (UbManufacturerId != null) { _updateItem.Properties.Add("UbManufacturerId", UbManufacturerId, true); }
            if (UbManufacturerItem != null) { _updateItem.Properties.Add("UbManufacturerItem", UbManufacturerItem, true); }
            if (UbManufacturerItemDesc != null) { _updateItem.Properties.Add("UbManufacturerItemDesc", UbManufacturerItemDesc, true); }

            if (UbManufacturerName != null) { _updateItem.Properties.Add("UbManufacturerName", UbManufacturerName, true); }
            if (UbNumberOfLabels != null) { _updateItem.Properties.Add("UbNumberOfLabels", UbNumberOfLabels, true); }
            if (UbPackagesExist != null) { _updateItem.Properties.Add("UbPackagesExist", UbPackagesExist, true); }
            if (UbQty != null) { _updateItem.Properties.Add("UbQty", UbQty, true); }
            if (UbQtyPerLabel != null) { _updateItem.Properties.Add("UbQtyPerLabel", UbQtyPerLabel, true); }
            if (UbSelect != null) { _updateItem.Properties.Add("UbSelect", UbSelect, true); }

            if (UbSite != null) { _updateItem.Properties.Add("UbSite", UbSite, true); }
            if (UbUM != null) { _updateItem.Properties.Add("UbUM", UbUM, true); }
            if (UbWhse != null) { _updateItem.Properties.Add("UbWhse", UbWhse, true); }
            if (UpdatedBy != null) { _updateItem.Properties.Add("UpdatedBy", UpdatedBy, true); }
            if (Weight != null) { _updateItem.Properties.Add("Weight", Weight, true); }



            updateRequestData.Items.Add(_updateItem);

            try
            {
                UpdateResponse = this.ExecuteUpdateCollection(updateRequestData);
                //Console.WriteLine(UpdateResponse.ToXml());
            }
            catch (Exception ee)
            {
                retVal = "Update Failed " + ee.Message ;
                //Console.WriteLine(ee.Message);
                MessageLogging("SLShipmentPackagesDAL.Update : " + ee.Message, msgLevel.l4_error, 1200002);
              
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

            try
            {
                UpdateResponse = this.ExecuteUpdateCollection(updateRequestData);
                //Console.WriteLine(UpdateResponse.ToXml());
            }
            catch (Exception ee)
            {
                retVal =  "Update Failed " + ee.Message ;
                //Console.WriteLine(ee.Message);
                MessageLogging("SLShipmentPackagesDAL.Delete : " + ee.Message, msgLevel.l4_error, 1200002);
                return retVal;
            }
            return retVal;

        }

        public override string  ResetProperties()
        {// unused properties must be initalized/reset null because we might want to filter on ''.
            string retVal = "";
            ProcessId = null;
            CreateDate	= null;CreatedBy = null;DerPacked = null;DerRefPackaged	= null;DerTrackingNumber = null;Description	= null;
            Hazard	= null;InWorkflow = null;MarksExcept = null;NMFC = null;NoteExistsFlag	= null;PackageId = null;
            PackageType	= null;RateCode = null;RecordDate = null;RefPackageId	= null;RowPointer = null;ShipmentId	= null;
            UbConsigneeName	= null;UbCustItem	= null;UbCustNum = null;UbCustSeq = null;UbItem	= null;UbItemDescription = null;
            UbLabelBy	= null;UbLocation	= null;UbLot = null;UbManufacturerId = null;UbManufacturerItem = null;UbManufacturerItemDesc = null;
            UbManufacturerName	= null;UbNumberOfLabels = null;UbPackagesExist	= null;UbQty = null;UbQtyPerLabel = null;UbSelect = null;
            UbSite	= null;UbUM = null;UbWhse	= null;UpdatedBy = null;Weight = null;

            #region MethodSpecific
                ProcessId = null; ShipmentID = null; TrackingNumber = null; TrackingURL = null; UbTemplatePath = null; UbOutputPath = null;
            #endregion

            return retVal;
        }
        
    }
}
