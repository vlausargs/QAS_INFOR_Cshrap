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
    class SLShipmentSeqSerialsDAL : IDALBase
    {
   #region Properties
      
    public string CoItem{ get; set; }	
    public string CoItemItemUM{ get; set; }	
    public string CoNum{ get; set; }	
    public string CreateDate{ get; set; }	
    public string CreatedBy{ get; set; }	
    public string DerItem{ get; set; }	

    public string DerItemUM	{ get; set; }	
    public string DerPacked	{ get; set; }	
    public string InWorkflow{ get; set; }	
    public string Lot{ get; set; }	
    public string NoteExistsFlag{ get; set; }	
    public string PackageId{ get; set; }	

    public string PickListId{ get; set; }	
    public string RecordDate{ get; set; }	
    public string RefLineSuffix{ get; set; }	
    public string RefNum{ get; set; }	
    public string RefRelease{ get; set; }	
    public string RefType{ get; set; }	

    public string RowPointer{ get; set; }	
    public string SerNum{ get; set; }	
    public string ShipmentId { get; set; }	
    public string ShipmentLine	{ get; set; }	
    public string ShipmentSeq{ get; set; }	
    public string Shipped{ get; set; }	
    
    public string UpdatedBy{ get; set; }

  #region MethodSpecific
    public string ProcessId { get; set; }
    public string UbSelect { get; set; }
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
            DALPropertyList = DALPropertyList + "CoItem,CoItemItemUM,CoNum,CreateDate,CreatedBy,DerItem,";
            DALPropertyList = DALPropertyList + "DerItemUM,DerPacked,InWorkflow,Lot,NoteExistsFlag,PackageId,";
            DALPropertyList = DALPropertyList + "PickListId,RecordDate,RefLineSuffix,RefNum,RefRelease,RefType,";
            DALPropertyList = DALPropertyList + "RowPointer,SerNum,ShipmentId,ShipmentLine,ShipmentSeq,Shipped,UbSelect,UpdatedBy";
            return DALPropertyList;
        }
    }
    public SLShipmentSeqSerialsDAL(IIDOExtensionClassContext Context)
        {
            base.SetContext(Context);
            base.initialize();
            _idoName = "SLShipmentSeqSerials";
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
    public override LoadCollectionRequestData GetQueryRquest(string filter = "", int recordCap = -1, string orderby = "ShipmentId, PickListId", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
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

    public override string QueryRecords(string filter = "", int recordCap = -1, string orderby = "ShipmentId, PickListId", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
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
        if ((CoItem != "") & (CoItem != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "CoItem like '" + CoItem + "'";
        }
        if ((CoItemItemUM != "") & (CoItemItemUM != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "CoItemItemUM like '" + CoItemItemUM + "'";
        }
        if ((CoNum != "") & (CoNum != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "CoNum like '" + CoNum + "'";
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
        if ((PackageId != "") & (PackageId != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "PackageId like '" + PackageId + "'";
        }
        #endregion
        #region Set3
        if ((PickListId != "") & (PickListId != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "PickListId like '" + PickListId + "'";
        }
        if ((RecordDate != "") & (RecordDate != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "RecordDate like '" + RecordDate + "'";
        }
        if ((RefLineSuffix != "") & (RefLineSuffix != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "RefLineSuffix like '" + RefLineSuffix + "'";
        }
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
        #endregion
        #region Set4
        if ((RowPointer != "") & (RowPointer != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "RowPointer like '" + RowPointer + "'";
        }
        if ((SerNum != "") & (SerNum != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "SerNum like '" + SerNum + "'";
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
        if ((ShipmentSeq != "") & (ShipmentSeq != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "ShipmentSeq like '" + ShipmentSeq + "'";
        }
        if ((Shipped != "") & (Shipped != null))
        {
            if (retval != "") { retval = retval + " and "; }
            retval = retval + "Shipped like '" + Shipped + "'";
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

    public virtual string InvokeIDOMethod_GenerateTmpShipSeqSerialSp()
    {
        string message = "";
        object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



        Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
        IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "GenerateTmpShipSeqSerialSp");

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
                                                SerNum,                                                                                                
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
            InvokeResponse = InvokeIDO(_idoName, "GenerateTmpShipSeqSerialSp", inputValues);
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
        if (CoItemItemUM != null) { _updateItem.Properties.Add("CoItemItemUM", CoItemItemUM, true); }
        if (CoNum != null) { _updateItem.Properties.Add("CoNum", CoNum, true); }
        if (CreateDate != null) { _updateItem.Properties.Add("CreateDate", CreateDate, true); }
        if (CreatedBy != null) { _updateItem.Properties.Add("CreatedBy", CreatedBy, true); }
        if (DerItem != null) { _updateItem.Properties.Add("DerItem", DerItem, true); }

        if (DerItemUM != null) { _updateItem.Properties.Add("DerItemUM", DerItemUM, true); }
        if (DerPacked != null) { _updateItem.Properties.Add("DerPacked", DerPacked, true); }
        if (InWorkflow != null) { _updateItem.Properties.Add("InWorkflow", InWorkflow, true); }
        if (Lot != null) { _updateItem.Properties.Add("Lot", Lot, true); }
        if (NoteExistsFlag != null) { _updateItem.Properties.Add("NoteExistsFlag", NoteExistsFlag, true); }
        if (PackageId != null) { _updateItem.Properties.Add("PackageId", PackageId, true); }

        if (PickListId != null) { _updateItem.Properties.Add("PickListId", PickListId, true); }
        if (RecordDate != null) { _updateItem.Properties.Add("RecordDate", RecordDate, true); }
        if (RefLineSuffix != null) { _updateItem.Properties.Add("RefLineSuffix", RefLineSuffix, true); }
        if (RefNum != null) { _updateItem.Properties.Add("RefNum", RefNum, true); }
        if (RefRelease != null) { _updateItem.Properties.Add("RefRelease", RefRelease, true); }
        if (RefType != null) { _updateItem.Properties.Add("RefType", RefType, true); }

        if (SerNum != null) { _updateItem.Properties.Add("SerNum", SerNum, true); }
        if (ShipmentId != null) { _updateItem.Properties.Add("ShipmentId", ShipmentId, true); }
        if (ShipmentLine != null) { _updateItem.Properties.Add("ShipmentLine", ShipmentLine, true); }
        if (ShipmentSeq != null) { _updateItem.Properties.Add("ShipmentSeq", ShipmentSeq, true); }
        if (Shipped != null) { _updateItem.Properties.Add("Shipped", Shipped, true); }
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
            retVal =  "Update Failed " + ee.Message ;
            //Console.WriteLine(ee.Message);
            MessageLogging("SLShipmentSeqsSerialsDAL.Update: " + ee.Message, msgLevel.l4_error, 1200004);
            
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
            MessageLogging("SLShipmentSeqsSerialsDAL.Delete: " + ee.Message, msgLevel.l4_error, 1200004);
            return retVal;
        }
        return retVal;

    }

    public override string ResetProperties()
    {// unused properties must be initalized/reset null because we might want to filter on ''.
        string retVal = "";

        CoItem = null; CoItemItemUM = null; CoNum = null; CreateDate = null; CreatedBy = null; DerItem = null;
        DerItemUM = null; DerPacked = null; InWorkflow = null; Lot = null; NoteExistsFlag = null; PackageId = null;
        PickListId = null; RecordDate = null; RefLineSuffix = null; RefNum = null; RefRelease = null; RefType = null;
        RowPointer = null; SerNum = null; ShipmentId = null; ShipmentLine = null; ShipmentSeq = null; Shipped = null; UbSelect = null; UpdatedBy = null;

        return retVal;
    }

    }
}
