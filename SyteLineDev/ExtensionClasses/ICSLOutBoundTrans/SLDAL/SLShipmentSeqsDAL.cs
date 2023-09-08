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
    class SLShipmentSeqsDAL : IDALBase
    {
        #region Properties

        public string CoItem { get; set; }
        public string CoItemItemSerialTracked { get; set; }
        public string CoItemItemUM { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string DerItem { get; set; }

        public string DerItemUM { get; set; }
        public string DerPacked { get; set; }
        public string InWorkflow { get; set; }
        public string Loc { get; set; }
        public string Lot { get; set; }
        public string NoteExistsFlag { get; set; }

        public string PackageId { get; set; }
        public string PickListId { get; set; }
        public string QtyPicked { get; set; }
        public string QtyShipped { get; set; }
        public string RecordDate { get; set; }
        public string RefLineSuf { get; set; }

        public string RefNum { get; set; }
        public string RefRelease { get; set; }
        public string RefType { get; set; }
        public string RowPointer { get; set; }
        public string ShipmentId { get; set; }
        public string ShipmentLine { get; set; }

        public string ShipmentSeq { get; set; }
        public string UbSelect { get; set; }
        public string UpdatedBy { get; set; }
        #endregion
        #region MethodSpecific

        public string ProcessId { get; set; }
        public string PackageType { get; set; }
        public string RateCode { get; set; }
        public string NMFC { get; set; }
        public string Weight { get; set; }
        public string Hazard { get; set; }
        public string MarksExcept { get; set; }
        public string Description { get; set; }
        public string QtyPackages { get; set; }
        public string QtyPerPackage { get; set; }
        public string WeightUM { get; set; }
        public string Packer { get; set; }
        public string ShipLoc { get; set; }

        #endregion


        /// <summary>
        /// Public property that provides a list of valid properties for the IDO
        /// </summary>
        public override string propertylist
        {
            get
            {
                string DALPropertyList = "";
                DALPropertyList = DALPropertyList + "CoItem,CoItemItemSerialTracked,CoItemItemUM,CreateDate,CreatedBy,DerItem,";
                DALPropertyList = DALPropertyList + "DerItemUM,DerPacked,InWorkflow,Loc,Lot,NoteExistsFlag,";
                DALPropertyList = DALPropertyList + "PackageId,PickListId,QtyPicked,QtyShipped,RecordDate,RefLineSuf,";
                DALPropertyList = DALPropertyList + "RefNum,RefRelease,RefType,RowPointer,ShipmentId,ShipmentLine,";
                DALPropertyList = DALPropertyList + "ShipmentSeq,UbSelect,UpdatedBy";
                return DALPropertyList;
            }
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
       

        public SLShipmentSeqsDAL(IIDOExtensionClassContext Context)
        {
            base.SetContext(Context);
            base.initialize();
            _idoName = "SLShipmentSeqs";
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

            if ((CoItem != "") & (CoItem != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "CoItem like '" + CoItem + "'";
            }
            if ((CoItemItemSerialTracked != "") & (CoItemItemSerialTracked != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "CoItemItemSerialTracked like '" + CoItemItemSerialTracked + "'";
            }
            if ((CoItemItemUM != "") & (CoItemItemUM != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "CoItemItemUM like '" + CoItemItemUM + "'";
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
            if ((DerItem != "") & (DerItem != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "DerItem like '" + DerItem + "'";
            }

            #endregion

            #region Set2

            if ((DerItemUM != "") & (DerItemUM != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "DerItemUM like '" + DerItemUM + "'";
            }
            if ((DerPacked != "") & (DerPacked != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "DerPacked like '" + DerPacked + "'";
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
            if ((Lot != "") & (Lot != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Lot like '" + Lot + "'";
            }
            if ((NoteExistsFlag != "") & (NoteExistsFlag != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "NoteExistsFlag like '" + NoteExistsFlag + "'";
            }

            #endregion

            #region Set3

            if ((PackageId != "") & (PackageId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "PackageId like '" + PackageId + "'";
            }
            if ((PickListId != "") & (PickListId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "PickListId like '" + PickListId + "'";
            }
            if ((QtyPicked != "") & (QtyPicked != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "QtyPicked like '" + QtyPicked + "'";
            }
            if ((QtyShipped != "") & (QtyShipped != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "QtyShipped like '" + QtyShipped + "'";
            }
            if ((RecordDate != "") & (RecordDate != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RecordDate like '" + RecordDate + "'";
            }
            if ((RefLineSuf != "") & (RefLineSuf != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RefLineSuf like '" + RefLineSuf + "'";
            }

            #endregion

            #region Set4

            if ((RefNum != "") & (RefNum != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RefNum like '" + RefNum + "'";
            }
            if ((RefRelease != "") & (RefRelease != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RefRelease like '" + RefRelease + "'";
            }
            if ((RefType != "") & (RefType != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RefType like '" + RefType + "'";
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
            if ((ShipmentLine != "") & (ShipmentLine != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ShipmentLine like '" + ShipmentLine + "'";
            }

            #endregion

            #region Set5

            if ((ShipmentSeq != "") & (ShipmentSeq != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ShipmentSeq like '" + ShipmentSeq + "'";
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

            #endregion

            return retval;

        }


        public virtual string InvokeIDOMethod_GeneratePackageSerialSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GeneratePackageSerialSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ProcessId,
                                                PackageId,
                                                PackageType,
                                                RateCode,
                                                NMFC,
                                                Weight,
                                                Hazard,
                                                MarksExcept,
                                                Description,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {

                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "GeneratePackageSerialSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "GeneratePackageSerialSp", inputValues);
            }

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
            IDOMethodParamCount = GetIDOMethodParameterCount("SLShipmentPackages", "GenerateTmpShipSeqPackageSp");
            if (Hazard == "") { Hazard = "0"; }

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
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {

                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = SLShipmentPackages method = " + "GenerateTmpShipSeqPackageSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO("SLShipmentPackages", "GenerateTmpShipSeqPackageSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_GeneratePackageSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            //Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            //IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GeneratePackageSp");


            //based on the number of parameters on the ido/method create the input values.
            //switch (IDOMethodParamCount)
            //{
            //    case 3:
            //    case 0:
                    inputValues = new object[]{
                                                ProcessId,
                                                QtyPerPackage,
                                                ""
                                                };

            //        break;
            //    default:

            //        inputValues = new object[]{
            //                                    ProcessId,
            //                                    QtyPackages,
            //                                    QtyPerPackage,
            //                                    PackageId,
            //                                    PackageType,
            //                                    RateCode,
            //                                    NMFC,
            //                                    Weight,                                                
            //                                    Hazard,
            //                                    MarksExcept,
            //                                    Description, 
            //                                    ""
            //                                    };
            //        break;
            //}

            //CallingParamCount = inputValues.Length;
            //if (IDOMethodParamCount != CallingParamCount)
            //{

            //    message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "GeneratePackageSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
            //    WriteError(message);
            //}
            //else
            //{
                InvokeResponse = InvokeIDO(_idoName, "GeneratePackageSp", inputValues);
            //}

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_PackConfirmationCompleteSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "PackConfirmationCompleteSp");

            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ShipmentId,
                                                ShipLoc,
                                                QtyPackages,
                                                Weight,
                                                WeightUM,
                                                Packer,
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {

                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "PackConfirmationCompleteSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "PackConfirmationCompleteSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        /// <summary>
        /// This method is used to create the temp shipment sequence records when packing a item.
        /// Currently the IDO accepts a packageid but will not generate the temp records.
        /// </summary>
        /// <returns></returns>
        public virtual string InvokeIDOMethod_GenerateTmpShipSeqSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GenerateTmpShipSeqSp");

            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{
                                                ProcessId,
                                                UbSelect,
                                                ShipmentId,
                                                ShipmentLine,
                                                ShipmentSeq,
                                                QtyPackages,
                                                QtyPerPackage,
                                                Loc,
                                                Lot,
                                                QtyPicked,
                                                QtyShipped,
                                                PackageId,                                                 
                                                ""
                                                };
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {

                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "GenerateTmpShipSeqSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "GenerateTmpShipSeqSp", inputValues);
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
            if (CoItem != null) { _updateItem.Properties.Add("CoItem", CoItem, true); }
            if (CoItemItemSerialTracked != null) { _updateItem.Properties.Add("CoItemItemSerialTracked", CoItemItemSerialTracked, true); }
            if (CoItemItemUM != null) { _updateItem.Properties.Add("CoItemItemUM", CoItemItemUM, true); }
            if (CreateDate != null) { _updateItem.Properties.Add("CreateDate", CreateDate, true); }
            if (CreatedBy != null) { _updateItem.Properties.Add("CreatedBy", CreatedBy, true); }
            if (DerItem != null) { _updateItem.Properties.Add("DerItem", DerItem, true); }

            if (DerItemUM != null) { _updateItem.Properties.Add("DerItemUM", DerItemUM, true); }
            if (DerPacked != null) { _updateItem.Properties.Add("DerPacked", DerPacked, true); }
            if (InWorkflow != null) { _updateItem.Properties.Add("InWorkflow", InWorkflow, true); }
            if (Loc != null) { _updateItem.Properties.Add("Loc", Loc, true); }
            if (Lot != null) { _updateItem.Properties.Add("Lot", Lot, true); }
            if (NoteExistsFlag != null) { _updateItem.Properties.Add("NoteExistsFlag", NoteExistsFlag, true); }

            if (PackageId != null) { _updateItem.Properties.Add("PackageId", PackageId, true); }
            if (PickListId != null) { _updateItem.Properties.Add("PickListId", PickListId, true); }
            if (QtyPicked != null) { _updateItem.Properties.Add("QtyPicked", QtyPicked, true); }
            if (QtyShipped != null) { _updateItem.Properties.Add("QtyShipped", QtyShipped, true); }
            if (RecordDate != null) { _updateItem.Properties.Add("RecordDate", RecordDate, true); }
            if (RefLineSuf != null) { _updateItem.Properties.Add("RefLineSuf", RefLineSuf, true); }

            if (RefNum != null) { _updateItem.Properties.Add("RefNum", RefNum, true); }
            if (RefRelease != null) { _updateItem.Properties.Add("RefRelease", RefRelease, true); }
            if (RefType != null) { _updateItem.Properties.Add("RefType", RefType, true); }
            if (ShipmentId != null) { _updateItem.Properties.Add("ShipmentId", ShipmentId, true); }
            if (ShipmentLine != null) { _updateItem.Properties.Add("ShipmentLine", ShipmentLine, true); }

            if (ShipmentSeq != null) { _updateItem.Properties.Add("ShipmentSeq", ShipmentSeq, true); }
            if (UbSelect != null) { _updateItem.Properties.Add("UbSelect", UbSelect, true); }
            if (UpdatedBy != null) { _updateItem.Properties.Add("UpdatedBy", UpdatedBy, true); }


            updateRequestData.Items.Add(_updateItem);

            try
            {
                UpdateResponse = this.ExecuteUpdateCollection(updateRequestData);
                //Console.WriteLine(UpdateResponse.ToXml());
            }
            catch (Exception ee)
            {
                retVal = "Update Failed " + ee.Message;
                //Console.WriteLine(ee.Message);
                MessageLogging("SLShipmentSeqsDAL.Update : " + ee.Message, msgLevel.l4_error, 1200002);
                
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
                retVal = "Update Failed " + ee.Message;
                //Console.WriteLine(ee.Message);
                MessageLogging("SLShipmentSeqsDAL.Delete: " + ee.Message, msgLevel.l1_information, 1200002);
                return retVal;
            }
            return retVal;

        }

        public override string ResetProperties()
        {// unused properties must be initalized/reset null because we might want to filter on ''.
            string retVal = "";

            CoItem = null; CoItemItemSerialTracked = null; CoItemItemUM = null; CreateDate = null; CreatedBy = null; DerItem = null;
            DerItemUM = null; DerPacked = null; InWorkflow = null; Loc = null; Lot = null; NoteExistsFlag = null;
            PackageId = null; PickListId = null; QtyPicked = null; QtyShipped = null; RecordDate = null; RefLineSuf = null;
            RefNum = null; RefRelease = null; RefType = null; RowPointer = null; ShipmentId = null; ShipmentLine = null;
            ShipmentSeq = null; UbSelect = null; UpdatedBy = null;

            #region MethodSpecific

            ProcessId = null; PackageType = null; RateCode = null; NMFC = null; Weight = null; Hazard = null; MarksExcept = null;
            Description = null; QtyPackages = null; QtyPerPackage = null; WeightUM = null; Packer = null; ShipLoc = null;

            #endregion

            return retVal;
        }

    }
}