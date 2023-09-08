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
    class SLTmpPickListLocsDAL : IDALBase
    {
        public SLTmpPickListLocsDAL(IIDOExtensionClassContext Context)
        {
            base.SetContext(Context);
            base.initialize();
            _idoName = "SLTmpPickListLocs";
        }
        #region Properties

        public string Description { get; set; }
        public string ExpDate { get; set; }
        public string Item { get; set; }
        public string Loc { get; set; }
        public string Lot { get; set; }
        public string LotTracked { get; set; }
        public string OrigLoc { get; set; }
        public string PickListId { get; set; }
        public string ProcessID { get; set; } //also the same as the session id
        public string QtyOnHand { get; set; }
        public string QtyPick { get; set; }
        public string QtyReserved { get; set; }
        public string QtyToPick { get; set; }
        public string Rank { get; set; }
        public string RefLineSuf { get; set; }
        public string RefNum { get; set; }
        public string RefRelease { get; set; }
        public string Reserved { get; set; }
        public string RowPointer { get; set; }
        public string Selected { get; set; }
        public string SerNum { get; set; }
        public string SerTracked { get; set; }
        public string UM { get; set; }
        public string ItemId { get; set; }
        public List<string> SerialList { get; set; }


        #endregion

        public override string propertylist
        {
            get
            {
                string DALPropertyList = "";
                DALPropertyList = DALPropertyList + "Description,ExpDate, Item,Loc,Lot,LotTracked,OrigLoc, PickListId, ProcessID, QtyOnHand";
                DALPropertyList = DALPropertyList + ", QtyPick, QtyReserved, QtyToPick, Rank, RefLineSuf, RefNum, RefRelease, Reserved, RowPointer, Selected, SerNum, SerTracked, UM";
                return DALPropertyList;
            }
        }

        public override LoadCollectionRequestData GetQueryRquest(string filter = "", int recordCap = -1, string orderby = "PickListId", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
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
        public override string QueryRecords(string filter = "", int recordCap = -1, string orderby = "PickListId", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
        {
            string retVal = "";

            requestData = GetQueryRquest(filter, recordCap, orderby, returnProperties, standardFilterincludesCustomFilter);
            LoadCollectionResponse = this.ExcuteQueryRequest(requestData); 
            ResetProperties(); //clear the properties and rest for the next run.
            return retVal;
        }

        protected override string constructfilter()
        {
            string retval = "";



            #region Set1
            if ((Description != "") & (Description != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Description like '" + Description + "'";
            }
            if ((ExpDate != "") & (ExpDate != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ExpDate like '" + ExpDate + "'";
            }
            if ((Item != "") & (Item != null))
            {
                if (retval != "") { retval = retval + " and "; }
                //retval = retval + "Item like '" + Item + "'";
                retval = retval + "Item = '" + Item + "'";
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
            if ((LotTracked != "") & (LotTracked != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "LotTracked like '" + LotTracked + "'";
            }
            if ((OrigLoc != "") & (OrigLoc != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "OrigLoc like '" + OrigLoc + "'";
            }
            if ((PickListId != "") & (PickListId != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "PickListId like '" + PickListId + "'";
            }
            if ((ProcessID != "") & (ProcessID != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "ProcessID like '" + ProcessID + "'";
            }

            if ((QtyOnHand != "") & (QtyOnHand != null))
            {
                if (retval != "") { retval = retval + " and "; }
               // retval = retval + "QtyOnHand like '" + QtyOnHand + "'";        --sdommata  10/21/2014  updated to handle Quantity field 
                retval = retval + "QtyOnHand = '" + QtyOnHand + "'";
            }
            /*if (retval == "")
            {
                retval = retval + "  ((QtyToPick - QtyPick)>0)";
            }
            else
            {
                retval = retval + " and ((QtyToPick - QtyPick)>0)";
            }*/

            #endregion

            #region Set2
            if ((QtyPick != "") & (QtyPick != null))
            {
                if (retval != "") { retval = retval + " and "; }
                //retval = retval + "QtyPick like '" + QtyPick + "'";            --sdommata  10/21/2014  updated to handle Quantity field 
                retval = retval + "QtyPick = '" + QtyPick + "'";
            }

            if ((QtyReserved != "") & (QtyReserved != null))
            {
                if (retval != "") { retval = retval + " and "; }
                // retval = retval + "QtyReserved like '" + QtyReserved + "'";        --sdommata  10/21/2014  updated to handle Quantity field 
                retval = retval + "QtyReserved = '" + QtyReserved + "'";
            }
            if ((QtyToPick != "") & (QtyToPick != null))
            {
                if (retval != "") { retval = retval + " and "; }
                //retval = retval + "QtyToPick like '" + QtyToPick + "'";            --sdommata  10/21/2014  updated to handle Quantity field 
                retval = retval + "QtyToPick = '" + QtyToPick + "'";
            }
            if ((Rank != "") & (Rank != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Rank like '" + Rank + "'";
            }
            if ((RefLineSuf != "") & (RefLineSuf != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RefLineSuf like '" + RefLineSuf + "'";
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
            if ((Reserved != "") & (Reserved != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Reserved like '" + Reserved + "'";
            }
            if ((RowPointer != "") & (RowPointer != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RowPointer like '" + RowPointer + "'";
            }
            if ((Selected != "") & (Selected != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "Selected like '" + Selected + "'";
            }
            if ((SerNum != "") & (SerNum != null))
            {
                if (retval != "") { retval += " and "; }
                retval = retval + "SerNum like '" + SerNum + "'";
            }

            if ((SerTracked != "") & (SerTracked != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "SerTracked like '" + SerTracked + "'";
            }

            if ((UM != "") & (UM != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "UM like '" + UM + "'";
            }
            #endregion

            return retval;
        }

        public override string ResetProperties()
        {// unused properties must be initalized/reset null because we might want to filter on ''.
            string retVal = "";

            Description = null; ExpDate = null; Item = null; Loc = null; Lot = null; LotTracked = null; OrigLoc = null; PickListId = null; ProcessID = null; QtyOnHand = null;
            QtyPick = null; QtyReserved = null; QtyToPick = null; Rank = null; RefLineSuf = null;
            RefNum = null; RefRelease = null; Reserved = null; RowPointer = null; Selected = null; SerNum = null; SerTracked = null; UM = null;

            return retVal;
        }

        public override string Update()
        {
                        
            string retVal = "";
            updateRequestData.IDOName = IdoName;
            updateRequestData.RefreshAfterUpdate = false;
            if (_updateItem == null)
            { _updateItem = new IDOUpdateItem(); } //for some reason this is new so create a new one.
            _updateItem.ItemID = ItemId;
            _updateItem.Action = UpdateAction.Update;
            _updateItem.Properties.Add("RowPointer", RowPointer, false);
            
            if (Selected != null) { _updateItem.Properties.Add("Selected", Selected, true); }
            if (Loc != null) { _updateItem.Properties.Add("Loc", Loc, true); }
            if (ProcessID != null) { _updateItem.Properties.Add("ProcessID", ProcessID, true); }

            if (Description != null) { _updateItem.Properties.Add("Description", Description, true); }
            if (ExpDate != null) { _updateItem.Properties.Add("ExpDate", ExpDate, true); }
            if (Item != null) { _updateItem.Properties.Add("Item", Item, true); }
            if (Lot != null) { _updateItem.Properties.Add("Lot", Lot, true); }
            if (LotTracked != null) { _updateItem.Properties.Add("LotTracked", LotTracked, true); }
            if (OrigLoc != null) { _updateItem.Properties.Add("OrigLoc", OrigLoc, true); }
            if (PickListId != null) { _updateItem.Properties.Add("PickListId", PickListId, true); }
            if (OrigLoc != null) { _updateItem.Properties.Add("OrigLoc", OrigLoc, true); }
            if (QtyOnHand != null) { _updateItem.Properties.Add("QtyOnHand", QtyOnHand, true); }
            if (QtyPick != null) { _updateItem.Properties.Add("QtyPick", QtyPick, true); }
            if (QtyReserved != null) { _updateItem.Properties.Add("QtyReserved", QtyReserved, true); }
            if (QtyToPick != null) { _updateItem.Properties.Add("QtyToPick", QtyToPick, true); }
            if (RefLineSuf != null) { _updateItem.Properties.Add("RefLineSuf", RefLineSuf, true); }
            if (RefNum != null) { _updateItem.Properties.Add("RefNum", RefNum, true); }
            if (Reserved != null) { _updateItem.Properties.Add("Reserved", Reserved, true); }
            if (Selected != null) { _updateItem.Properties.Add("Selected", Selected, true); }
            if (SerNum != null) { _updateItem.Properties.Add("SerNum", SerNum, true); }
            if (SerTracked != null) { _updateItem.Properties.Add("SerTracked", SerTracked, true); }
            if (UM != null) { _updateItem.Properties.Add("UM", UM, true); }


            updateRequestData.Items.Add(_updateItem);

            try
            {
                UpdateResponse = ExecuteUpdateCollection(updateRequestData);
                //Console.WriteLine(UpdateResponse.ToXml());
            }
            catch (Exception ee)
            {
                retVal = "Update Failed " + ee.Message;
                //Console.WriteLine(ee.Message);
                MessageLogging("SLTmpPickListLocsDAL.Update: " + ee.Message, msgLevel.l4_error, 1200004);
             
            }
            _updateItem = null;
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
            _updateItem.ItemID = Item;
            if (Selected != null) { _updateItem.Properties.Add("_ItemId", Item, false); }
            else
            { _updateItem.Properties.Add("RowPointer", RowPointer, false); }

            updateRequestData.Items.Add(_updateItem);

            try
            {
                UpdateResponse = this.ExecuteUpdateCollection(updateRequestData);
                //Console.WriteLine(UpdateResponse.ToXml());
            }
            catch (Exception ee)
            {
                
                //Console.WriteLine(ee.Message);
                MessageLogging("SLTmpPickListLocsDAL.Delete: " + ee.Message, msgLevel.l4_error, 1200004);
                return "Update Failed ";
            }
            return retVal;

        }
        /// <summary>
        /// This method copies all of the pick list records to the tmpPicklistlocs table and assignes the provided process id to each record.
        /// </summary>
        /// <remarks>
        /// For warehouse mobility the process id can be a guid generated by: GenerateGUID(ref ProcessGUID)
        /// If we generate the GUID then the calling method(s) must keep track of the Generated GUID!!
        /// </remarks>
        /// <returns></returns>
        public virtual string InvokeIDOMethod_PickConfirmationSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                ProcessID,
                                                PickListId,
                                                "1",
                                                ""
                                                };

            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "PickConfirmationSp");

            #region handle different versions of the IDO
            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:
                    /*
                    inputValues = new object[]{
                                                ProcessId,
                                                PickListId,
                                                "0",
                                                ""
                                                };
                     */
                    break;
            }
            #endregion
            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
              
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "CLM_PackWorkbenchPickRefs" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "PickConfirmationSp", inputValues);

            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_RecordDifference_PickConfirmationSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                ProcessID,
                                                PickListId,
                                                "0",
                                                ""
                                                };

            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "PickConfirmationSp");

            #region handle different versions of the IDO
            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:
                    /*
                    inputValues = new object[]{
                                                ProcessId,
                                                PickListId,
                                                "0",
                                                ""
                                                };
                     */
                    break;
            }
            #endregion
            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {

                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "CLM_PackWorkbenchPickRefs" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "PickConfirmationSp", inputValues);

            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        /// <summary>
        /// This method purges (deletes) all of the records from the TmpPickListLocs for a given porcessid.
        /// </summary>
        /// <returns></returns>
        public virtual string InvokeIDOMethod_PurgeTmpPickListLocSerialSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                ProcessID                                                
                                                };

            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "PurgeTmpPickListLocSerialSp");

            //based on the number of parameters on the ido/method create the input values.
            #region handle different versions of the ido
            switch (IDOMethodParamCount)
            {
                default:
                    /*
                    inputValues = new object[]{
                                                ProcessId,
                                                PickListId,
                                                "0",
                                                ""
                                                };
                     */
                    break;
            }
            #endregion
            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
               
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "CLM_PackWorkbenchPickRefs" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, "PurgeTmpPickListLocSerialSp", inputValues);
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }
        /// <summary>
        /// This method copies all of the pick list records to the Picklistlocs table and updated the qty picked.
        /// </summary>
        /// <remarks>
        /// For warehouse mobility the process id can be a guid generated by: GenerateGUID(ref ProcessGUID)
        /// If we generate the GUID then the calling method(s) must keep track of the Generated GUID!!
        /// </remarks>
        /// <returns></returns>
        public virtual string InvokeIDOMethod_PickConfirmationCompleteSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                ProcessID,
                                                PickListId,
                                                "1",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "PickConfirmationCompleteSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:
                    /*
                    inputValues = new object[]{
                                                ProcessId,
                                                PickListId,
                                                "0",
                                                ""
                                                };
                     */
                    break;
            }

            CallingParamCount = inputValues.Length;
            if (IDOMethodParamCount != CallingParamCount)
            {
               
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "PickConfirmationCompleteSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
                WriteError(message);
            }
            else
            {
                try
                {
                    InvokeResponse = InvokeIDO(_idoName, "PickConfirmationCompleteSp", inputValues);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                        ResetProperties(); //clear the properties and rest for the next run.
                        return message;
                    }
                }

                if (!(InvokeResponse.ReturnValue.Equals("0")))
                {
                    //errorMessage = constructErrorMessage(InvokeResponse.Parameters.ElementAt(3).ToString(), "PPPS0005", null);
                    return InvokeResponse.Parameters.ElementAt(3).ToString();
                }
            }

            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }
    }
}
