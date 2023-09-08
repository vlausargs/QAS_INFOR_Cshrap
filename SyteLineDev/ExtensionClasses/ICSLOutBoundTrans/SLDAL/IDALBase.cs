using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;

using System.Xml;


namespace InforCollect.ERP.SL.ICSLOutBoundTrans.SLDAL
{
    public class IDALBase : ICSLCommonLibrary 
    {
        public InvokeResponseData InvokeResponse;
        public LoadCollectionResponseData LoadCollectionResponse;
        protected LoadCollectionRequestData requestData = new LoadCollectionRequestData();

        protected UpdateCollectionRequestData updateRequestData;
        public UpdateCollectionResponseData UpdateResponse;
        public UpdateAction Action = UpdateAction.Update;

        protected IDOUpdateItem _updateItem = new IDOUpdateItem();

        public PropertyList queryPropertyList = null; //was in IMessageDaoBase but with the conversion this class is not needed. So relocated the property here JH:20130820

        public IDOUpdateItem UpdateItem
        { get { return _updateItem; } }

        protected string _idoName = "base";
        public string IdoName
        { get { return _idoName; } }
        protected string _customInsert = "";
        public string CustomInsert
        {
            get { return _customInsert; }
            set { _customInsert = value; }
        }
        protected string _customUpdate = "";
        public string CustomUpdate
        {
            get { return _customUpdate; }
            set { _customUpdate = value; }
        }
        protected string _customDelete = "";
        public string CustomDelete
        {
            get { return _customDelete; }
            set { _customDelete = value; }
        }

        public virtual string propertylist
        {
            get
            {
                string DALPropertyList = "";
                return DALPropertyList;
            }
        }
        
        public void initialize()
        {//context should be setbefore calling this initialize.  jh:20130819
            //initialize statements were left out in the conversion JH:20130820            
            queryPropertyList = null;

            requestData = new LoadCollectionRequestData();
            updateRequestData = new UpdateCollectionRequestData();
        }


        //this method returns a message indicating the success, failure, or failure message.
        //The actual result data from this is stored in the LoadCollectionResponse property
        /// <summary>
        /// Method to query the IDO to get a sub set of records.  The standard way to call this method is with no paramters and to set the related property with the filter value.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="recordCap"></param>
        /// <param name="orderby"></param>
        /// <param name="returnProperties"></param>
        /// <returns></returns>
        ///         
        public virtual string QueryRecords(string filter, int recordCap = 1, string orderby = "", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
        {
            string message = "";
            return message;
        }

        public virtual LoadCollectionRequestData GetQueryRquest(string filter = "", int recordCap = -1, string orderby = "PickListId, Sequence", string returnProperties = "", bool standardFilterincludesCustomFilter = false)
        {
            requestData.IDOName = _idoName;
            if (returnProperties == "")
            {
                requestData.PropertyList.SetProperties(this.propertylist);
            }
            else
            {
                requestData.PropertyList.SetProperties(returnProperties);
            }


            if (filter == "")
            { filter = constructfilter(); }
            else
            {
                if (standardFilterincludesCustomFilter == true)
                {
                    string constructedfilter = "";
                    constructedfilter = constructfilter();
                    if (constructedfilter != "")
                    {
                        filter = constructedfilter + " and " + filter;
                    }
                }
            }

            requestData.Filter = filter;
            requestData.OrderBy = orderby;
            requestData.RecordCap = recordCap;
            return requestData;
        }

        protected virtual string constructfilter()
        {
            string retval = "";
            return retval;
        }
        //this method returns a message indicating the success, failure, or failure message.
        //The actual result data from this is stored in the UpdateResponse property
        public virtual string Update()
        {
            string message = "";
            return message;
        }

        //this method returns a message indicating the success, failure, or failure message.
        //The actual result data from this is stored in the UpdateResponse property
        public virtual string Insert()
        {
            string message = "";
            return message;
        }

        //this method returns a message indicating the success, failure, or failure message.
        //The actual result data from this is stored in the UpdateResponse property
        public virtual string Delete()
        {
            string message = "";
            return message;
        }
        //this method returns a message indicating the success, failure, or failure message.
        //The actual result data from this is stored in the InvokeResponse property
        //This method should be over ridden in the derived class because it is common for the number of parameters to change
        public virtual string InvokeIDOMethod(string methodName, object[] inputValues)
        {
            string message = "";
            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount(_idoName, methodName);
            CallingParamCount = inputValues.Length;

            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + methodName + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
            }
            else
            {
                InvokeResponse = InvokeIDO(_idoName, methodName, inputValues);
            }

            return message;
        }

        public virtual string InvokeIDOMethodTest(string methodName, object[] inputValues)
        {
            string message = "";
            Int32 IDOMethodParamCount = 0, CallingParamCount = 0;
            IDOMethodParamCount = GetIDOMethodParameterCount("SLJobMatls", methodName);
            CallingParamCount = inputValues.Length;

            if (IDOMethodParamCount != CallingParamCount)
            {
                message = "Number of IDOMethod parameters does not match the calling number of parameters: IDO = " + _idoName + " method = " + methodName + " SLparam Count = " + IDOMethodParamCount + " callaram Count = " + CallingParamCount;
            }
            else
            {
                InvokeResponse = InvokeIDO("SLJobMatls", methodName, inputValues);
            }

            return message;
        }

        public virtual string ResetProperties()
        {
            string retVal = "";

            return retVal;
        }

        public virtual string ResetDataCollections()
        {
            string retVal = "";

            InvokeResponse = null;
            UpdateResponse = null;
            LoadCollectionResponse = null;
            Action = UpdateAction.None;
            requestData = null;

            return retVal;
        }
        public LoadCollectionResponseData Execute(LoadCollectionRequestData reqdata)
        {
            LoadCollectionResponseData _ResponseData;
            //reqdata.PropertyList

            _ResponseData = ExcuteQueryRequest(reqdata);

            return _ResponseData;
        }

        protected void WriteError(string message)
        {//common debug information when we have a failure at the ido level.
          //  Console.WriteLine("** Adapter Config SL ver: " + GetSyteLineVersion());
            //Console.WriteLine("** " + message);
            MessageLogging("** IDALBase.WriteError: " + message, msgLevel.l4_error, 1200004);
        }
        #region examples
        #endregion

    }
}
