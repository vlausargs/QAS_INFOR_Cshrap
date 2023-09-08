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
    class SLCoitemShpsDAL : IDALBase
    {

        public SLCoitemShpsDAL(IIDOExtensionClassContext Context)
        {
            base.SetContext(Context);
            base.initialize();
            _idoName = "SLCoitemShps";  
        }        

#region Properties
        public string CustNum { get; set; }
        public string RowPointer { get; set; }
        public string RecordDate { get; set; }

        #region MethodSpecific
            public string OnHandNegative { get; set; }
            public string FirstSequenceWithError { get; set; }
            public string RecordsPosted { get; set; }
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
                DALPropertyList = DALPropertyList + "CustNum,RowPointer,RecordDate";
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
        public override LoadCollectionRequestData GetQueryRquest(string filter = "", int recordCap = -1, string orderby = "CustNum", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
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
        public override string QueryRecords(string filter = "", int recordCap = -1, string orderby = "CustNum", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
        {
            string retVal = "";

            requestData = GetQueryRquest(filter, recordCap, orderby, returnProperties, standardFilterincludesCustomFilter);
            LoadCollectionResponse = ExcuteQueryRequest(requestData);
            return retVal;
        }

        private string Constructfilter()
        {
            string retval = "";
          
            #region Set1
            
            //use find and replace to replace RepParam with the actual parameter name 
            if ((CustNum != "") & (CustNum != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "CustNum = " + CustNum;
            }
            if ((RowPointer != "") & (RowPointer != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RowPointer = " + RowPointer;
            }
            if ((RecordDate != "") & (RecordDate != null))
            {
                if (retval != "") { retval = retval + " and "; }
                retval = retval + "RecordDate = " + RecordDate;
            }
           
            #endregion
            
            return retval;

        }

        public virtual string InvokeIDOMethod_COShippingCleanupSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "COShippingCleanupSp");


            //based on the number of parameters on the ido/method create the input values.
            switch (IDOMethodParamCount)
            {
                default:

                    inputValues = new object[]{};
                    break;
            }

            CallingParamCount = inputValues.Length;
           
            InvokeResponse = InvokeIDO(_idoName, "COShippingCleanupSp", inputValues);
            
            ResetProperties(); //clear the properties and rest for the next run.
            return message;
        }

        public virtual string InvokeIDOMethod_COShippingLoopSp()
        {
            string message = "";
            object[] inputValues = new object[]{
                                                "",
                                                ""
                                                };



            //Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            //IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, "COShippingLoopSp");


            //based on the number of parameters on the ido/method create the input values.
            //switch (IDOMethodParamCount)
            //{
            //    case 8:
                    inputValues = new object[]{
                                                OnHandNegative,
                                                FirstSequenceWithError,
                                                RecordsPosted,
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };
            //        break;
            //    case 6://added for SL9 Qualification.  
            //        inputValues = new object[]{
            //                                    "0",
            //                                    "",
            //                                    "0",
            //                                    "",
            //                                    "",
            //                                    ""
            //                                    };
            //        break;
            //    case 5: 
            //    default:

            //        inputValues = new object[]{
            //                                    OnHandNegative, 
            //                                    FirstSequenceWithError,
            //                                    RecordsPosted,
            //                                    "",
            //                                    ""
            //                                    };
            //        break;
            //}

            //CallingParamCount = inputValues.Length;
            //if (IDOMethodParamCount != CallingParamCount)
            //{   
            //    message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + "COShippingLoopSp" + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
            //    WriteError(message);
            //}
            //else
            //{
                InvokeResponse = InvokeIDO(_idoName, "COShippingLoopSp", inputValues);
                if (InvokeResponse.ReturnValue.Equals("0"))
                {
                    return InvokeResponse.Parameters.ElementAt(3).ToString();
                }
            //}

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
            if (CustNum != null) { _updateItem.Properties.Add("CustNum", CustNum, true); }
            if (RecordDate != null) { _updateItem.Properties.Add("RecordDate", RecordDate, true); }
            updateRequestData.Items.Add(_updateItem);

            try
            {
                UpdateResponse = this.ExecuteUpdateCollection(updateRequestData);
                //Console.WriteLine(UpdateResponse.ToXml());
            }
            catch (Exception ee)
            {
                retVal = "Update Failed " + ee.Message ;
                MessageLogging("SLCoitemShpsDal.Update : " + ee.Message, msgLevel.l4_error, 1200002);
                //Console.WriteLine(ee.Message);
                
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
                MessageLogging("SLCoitemShpsDal.Delete : " + ee.Message, msgLevel.l4_error, 1200002);
                return retVal;
            }
            return retVal;

        }
        public override string  ResetProperties()
        {// unused properties must be initalized/reset null because we might want to filter on ''.
            string retVal = "";

            CustNum = null; RowPointer  = null; RecordDate = null;
            #region MethodSpecific
                 OnHandNegative = null;
                 FirstSequenceWithError = null;
                 RecordsPosted = null;
            #endregion
            return retVal;
        }
        
    }
}
