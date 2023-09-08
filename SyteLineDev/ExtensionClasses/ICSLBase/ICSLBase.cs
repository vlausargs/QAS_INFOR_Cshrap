using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;  

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;

using System.Diagnostics; //Added to allow message logging.
using System.Globalization;

namespace InforCollect.ERP.SL
{
    public class ICSLBase
    {
        public IIDOExtensionClassContext Context = null;

      #region Base Properties
        /// <summary>
        /// Short date Pattern used by warehouse mobility.  This should be used throught the system to avoid issues related culture formatting.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Created for MSF 157397 JH:20130128 
        /// When a customer has culture setting other than US (example en_AU)
        /// Using the various System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat DateTimePatterns gives inconsistant results 
        /// when used with IDO filtering and IDO Method calls.
        ///     IDO filtering does not accept "d/MM/yyyy" formatting
        ///     IDO Method calls does not accept "M/d/yyyy" formatting
        ///     IDO filtering and Method call does appear to accept "yyyyMMdd" formatting
        ///     
        ///  The .net Convert.ToDateTime function fails if the "/" seperators are not present in the string.  The call to a IDO via the Syteline 
        ///     service appears to work if the "/" seperatora are present and if the "/" seperator is not present.  JH:0130212
        /// </remarks>
        private string wmShortDatePattern = "yyyy/MM/dd";
        public string WMShortDatePattern
        {
            get { return wmShortDatePattern; }
            //for now read only.
            //set { wmShortDatePattern = value; }
        }

        /// <summary>
        /// Full date time Pattern used by warehouse mobility. This should be used throught the system to avoid issues related culture formatting.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Created for MSF 157397 JH:20130128 
        /// When a customer has culture setting other than US (example en_AU)
        /// Using the various System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat DateTimePatterns gives inconsistant results 
        /// when used with IDO filtering and IDO Method calls.
        ///     IDO filtering does not accept "d/MM/yyyy" formatting
        ///     IDO Method calls does not accept "M/d/yyyy" formatting
        ///     IDO filtering and Method call does appear to accept "yyyyMMdd" formatting
        ///     
        ///  The .net Convert.ToDateTime function fails if the "/" seperators are not present in the string.  The call to a IDO via the Syteline 
        ///     service appears to work if the "/" seperators are present and if the "/" seperator is not present.  JH:0130212
        /// </remarks>
        private string wmFullDateTimePattern = "yyyy/MM/dd H:mm:ss";  //For SL 9 cert changed the time format to show midnight as 0:00  JH:20130726
        public string WMFullDateTimePattern
        {
            get { return wmFullDateTimePattern; }
            //for now read only.
            //set { WMFullDateTimePattern = value; }
        }

        /// <summary>
        /// Full date time Pattern used by ICSL components. This includes full two-digit hours representation and milliseconds.
        /// Returns: Date Time format string to use when converting a DateTime object when communicating with IDOs
        /// Created for Jira FTDEV-9195, using WMFullDateTimePattern above as a template to start from.
        /// </summary>
        private string wmLongDateTimePattern = "yyyy/MM/dd HH:mm:ss.fff";
        public string WMLongDateTimePattern
        {
            get { return wmLongDateTimePattern; }
            //for now read only.
            //set { WMFullDateTimePattern = value; }
        }

        /// <summary>
        /// Time Pattern used by warehouse mobility. This should be used throught the system to avoid issues related culture formatting.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Created for MSF 157397 JH:20130128 
        /// When a customer has culture setting other than US (example en_AU)
        /// Using the various System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat DateTimePatterns gives inconsistant results 
        /// when used with IDO filtering and IDO Method calls.
        ///     IDO filtering does not accept "d/MM/yyyy" formatting
        ///     IDO Method calls does not accept "M/d/yyyy" formatting
        ///     IDO filtering and Method call does appear to accept "yyyyMMdd" formatting
        /// </remarks>
        private string wmTimePattern = "H:mm:ss"; //For SL 9 cert changed the time format to show midnight as 0:00  JH:20130726
        public string WMTimePattern
        {
            get { return wmTimePattern; }
            //for now read only.
            //set { wmTimePattern = value; }
        }

        /// <summary>
        /// HH:mm:ss.fff
        /// </summary>
        private string wmLongTimePattern = "HH:mm:ss.fff";
        public string WMLongTimePattern
        {
            get { return wmLongTimePattern; }
            //for now read only.
            //set { wmTimePattern = value; }
        }
        #endregion

        #region Message Logging
        //we need to find a good way to make these parameters dynamic.  For Now set them verbose.  JH:20130826
        private string sLogName = "Infor Collect"; //Name of Windows Log only 8 charcters can be used.
        private string sSource = "IC SLIDO";
        /* MF 07032019: commented out code no longer being used until it can be refactored.
        //setting this value controls the messages that are written to the windows log by level/importance
        private msgLevel loggingLevel = msgLevel.l3_warning; //the level we record messages.  
        //will need a way to set this most likely a parameter in the infrastructure. For now this is ok.

       

        //method to set the level.  This is the base method.
        public void setlogginglevel(string level)
        {
            switch (level.ToUpper())
            {
                case "INFORMATION":
                    loggingLevel = msgLevel.l1_information;
                    break;
                case "SUCCESS":
                    loggingLevel = msgLevel.l2_success;
                    break;
                case "WARNING":
                    loggingLevel = msgLevel.l3_warning;
                    break;
                case "ERROR":
                    loggingLevel = msgLevel.l4_error;
                    break;
                case "FAILURE":
                    loggingLevel = msgLevel.l5_failure;
                    break;
                default:
                    loggingLevel = msgLevel.l3_warning;
                    break;
            }
        }
        /// <summary>
        /// A overload method to set the logging level based on a integer.
        /// </summary>
        /// <param name="level">10= information, 20,30,40,50= failure</param>
        /// <remarks>
        ///  translates the level integer to a string and calls the setlogginglevel.
        /// </remarks>
        public void setlogginglevel(int level)
        {
            switch (level)
            {
                case 10:
                    setlogginglevel("INFORMATION");
                    break;
                case 20:
                    setlogginglevel("SUCCESS");
                    break;
                case 30:
                    setlogginglevel("WARNING");
                    break;
                case 40:
                    setlogginglevel("ERROR");
                    break;
                case 50:
                    setlogginglevel("FAILURE");
                    break;
            }
        }*/

        public enum msgLevel : int
        {//valid types of messages (0 base list) with most critical leval at the end.

            l1_information = 10,  //information that we want written to the log but subject to the logging level setting.
            l2_success = 20,  //information that is more important than level 1
            l3_warning = 30,  //Warning message.  More important than level 2
            l4_error = 40,    //Error message.  More important than level 3 and Typically very important, but did not stop the transaction
            l5_failure = 50,  //Failure message.  More important than level 4 and Typically extremly important, and stoped the transaction from completing.
            l9_allways = 99,  //information that we always want written to the log.  The message might not indicate a problem but we want this written to the log file.
        }
        /// <summary>
        /// Infor Collect message logging method 
        /// </summary>
        /// <param name="message">The text to be displayed in the log file</param>        
        /// <param name="messageLevel">The level of the message. Enumerated value.</param>
        /// <param name="msgID">a numeric identifer.  Not used at this time.</param>
        /// <param name="details">a more technical and detailed information. Not used at this time.</param>
        /// <remarks>
        /// Created by: Jason Hammock       On:2013/08/26
        /// </remarks>
        public void MessageLogging(string message, msgLevel messageLevel, int msgID = 1000, string details = "")
        {
            /*if (!EventLog.SourceExists(sSource))
                createEventLog();

            switch (messageLevel)
            {
                case msgLevel.l9_allways:
                    if (loggingLevel <= messageLevel)
                    { EventLog.WriteEntry(sSource, message, EventLogEntryType.Information, 900); }
                    break;
                case msgLevel.l5_failure:
                    if (loggingLevel <= messageLevel)
                    { EventLog.WriteEntry(sSource, message, EventLogEntryType.FailureAudit, 500); }
                    break;
                case msgLevel.l4_error:
                    //50 <= 40
                    if (loggingLevel <= messageLevel)
                    { EventLog.WriteEntry(sSource, message, EventLogEntryType.Error, 400); }
                    break;
                case msgLevel.l3_warning:
                    if (loggingLevel <= messageLevel)
                    { EventLog.WriteEntry(sSource, message, EventLogEntryType.Warning, 300); }
                    break;
                case msgLevel.l2_success:
                    if (loggingLevel <= messageLevel)
                    { EventLog.WriteEntry(sSource, message, EventLogEntryType.SuccessAudit, 200); }
                    break;
                case msgLevel.l1_information:
                    if (loggingLevel <= messageLevel)
                    { EventLog.WriteEntry(sSource, message, EventLogEntryType.Information, 100); }
                    break;
            }*/



        }

        private bool createEventLog()
        {
            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLogName);

            EventLog myNewLog = new EventLog(sLogName);
            myNewLog.Source = sSource;
            myNewLog.MaximumKilobytes = 1024;
            myNewLog.ModifyOverflowPolicy(OverflowAction.OverwriteOlder, 60);


            return true;
        }
      #endregion

      #region Initialization methods
        /// <summary>
        /// Base class method to set the context.
        /// </summary>
        /// <param name="context">The context that will be used by all derived classes to call the ERP</param>
        public void SetContext(IIDOExtensionClassContext context)
        {
            Context = context;
        }

        public void Initialize()
        {
            //SetErpErrorMessage("");
        }
        /// <summary>
        /// Base class initialize method.
        /// </summary>
        /// <param name="context"></param>
        public void Initialize(IIDOExtensionClassContext context)
        {
            Initialize();  //call the base initialize 
            Context = context; //to the extra step of setting the context.            
        }
        #endregion

      #region Data formating methods
        public String GetExpandedString(String input, String type, String site)
        {
            object[] inputValues = null;
            inputValues = new object[]{
                                                type,
                                                input,
                                                site,
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLPurchaseOrders", "ExpandKyByTypeSp", inputValues);
            if (!responseData.ReturnValue.Equals("0"))
            {
                //errorMessage = "Error in ExpandKyByTypeSp";
            }

            return responseData.Parameters.ElementAt(3).ToString();
        }

        public string formatByPropertInfo(PropertyInfo propertyInfo, string input)
        {
            if (propertyInfo.CaseFormat.Equals("upper"))
            {
                input = input.ToUpper();
            }

            if (propertyInfo.JustifyFormat.Equals("R"))
            {
                input = padSpaces(input, propertyInfo.DataLength, true);
            }
            else
            {
                input = padSpaces(input, propertyInfo.DataLength, false);
            }

            if (propertyInfo.DataType.Equals("Short Integer"))
            {
                try
                {
                    input = (Convert.ToInt16(input, CultureInfo.InvariantCulture)).ToString(); // FTDEV-9247
                }
                catch (FormatException)
                {
                    //System.Console.WriteLine(fe.Message);
                }

            }

            return input;
        }
   
        public string padSpaces(string value, int reqLength, bool attachBefore)
        {
            while (value.Length < reqLength)
            {
                if (attachBefore)
                {
                    value = " " + value;
                }
                else
                {
                    value = value + " ";
                }
            }
            return value;
        }

        
        public string GetIDOInputBoolValue(bool input)
        {
            if (input == true)
            {
                return "1";
            }
            return "0";
        }

        public string formatItem(string input)
        {
            if (input != null && input.IndexOf('\'') != -1)
            {
                input = input.Replace("'", "''");
            }
            return input;
        }
        public string formatResponse(string returnString)
        {
            returnString = returnString.Replace("\n\r", "");
            returnString = returnString.Replace("\n", "");
            returnString = returnString.Replace("\r", "");
            returnString = returnString.Replace("&", "&amp;");
            //returnString = returnString.Replace("<", "&lt;");
            //returnString = returnString.Replace(">", "&gt;");
            //returnString = returnString.Replace("'", "&quot;");
            //returnString = returnString.Replace("\"", "&apos;");
            returnString = returnString.Replace("'", "&apos;");
            returnString = returnString.Replace("\"", "&quot;");
            returnString = returnString.Replace("~lt;~", "&lt;");                           //Support incident 5322739  - Kiran 03/27/2012
            returnString = returnString.Replace("~gt;~", "&gt;");                           //Support incident 5322739  - Kiran 03/27/2012

            return returnString;
        }
        
        public bool GetBool(string input)
        {
            if (input.Equals("1"))
            {
                return true;
            }
            return false;
        }
        public decimal GetDecimalValue(string input)
        {
            return Convert.ToDecimal(input, CultureInfo.InvariantCulture); // FTDEV-9247
        }

        /// <summary>
        /// Method to format strings sent to the IDO.
        /// This is mostly used to escapt special charcters.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>well formated input value</returns>
        /// <remarks>
        /// Created: 2013/07/17     By: Jason Hammock
        /// Initally created to address MSF165152
        /// This should be expanded as we identify additional IDO requirements.
        /// </remarks>
        public string IDOStrFormat(string input)
        {
            string retVal = "";
            retVal = System.Text.RegularExpressions.Regex.Replace(input, "'", "''");


            return retVal;
        }
      #endregion

        public DataTable CreateDataTable(string idoName, PropertyList propList)
        {
            GetPropertyInfoResponseData respData = Context.Commands.GetPropertyInfo(idoName);
            DataTable dataTable = new DataTable(idoName);
            

            for (int index = 0; index < propList.Count; index++)
            {
                Mongoose.IDO.Protocol.PropertyInfo propInfo = respData.Properties[propList[index]];
                dataTable.Columns.Add(propInfo.Name, propInfo.ClrType);
            }

            return dataTable;
        }
        public DataTable ExecuteQuery(LoadCollectionRequestData requestData, string errorMessageId)
        {
            DataTable dataTable = new DataTable();
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            
            if (responseData == null || responseData.Items.Count == 0)
            {
                //this.GetMessageProvider().GetMessage(("mAuthorizeSuccessful"))
                //SetErpErrorMessage(errorMessageId);
            }

            dataTable = CreateDataTable(requestData.IDOName, requestData.PropertyList);
            responseData.Fill(dataTable);
            return dataTable;
        }
        public DataTable ExecuteQuery(LoadCollectionRequestData requestData, string[] outputFields, string errorMessageId)
        {
            DataTable dataTable = new DataTable();
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

            if (responseData == null || responseData.Items.Count == 0)
            {
                //SetErpErrorMessage(errorMessageId);
            }

            for (int index = 0; index < outputFields.Length; index++)
            {
                dataTable.Columns.Add(outputFields[index]);
            }

            for (int index = 0; index < responseData.Items.Count; index++)
            {
                DataRow dataRow = dataTable.NewRow();

                if (outputFields.Length > requestData.PropertyList.Count)
                {
                    int j = 0;
                    for (; j < requestData.PropertyList.Count; j++)
                    {
                        dataRow[outputFields[j]] = responseData[index, requestData.PropertyList[j]].ToString();
                    }

                    for (; j < outputFields.Length; j++)
                    {
                        dataRow[outputFields[j]] = "";
                    }
                }
                else
                {
                    for (int j = 0; j < requestData.PropertyList.Count; j++)
                    {
                        dataRow[outputFields[j]] = responseData[index, requestData.PropertyList[j]].ToString();
                    }

                }

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        public DataTable ExecuteQuery(LoadCollectionResponseData responseData, string errorMessageId)
        {
            DataTable dataTable = new DataTable();

            if (responseData == null || responseData.Items.Count == 0)
            {
                //this.GetMessageProvider().GetMessage(("mAuthorizeSuccessful"))
                //SetErpErrorMessage(errorMessageId);
            }

            dataTable = CreateDataTable(responseData.IDOName, responseData.PropertyList);
            responseData.Fill(dataTable);
            return dataTable;
        }
        
        public LoadCollectionResponseData ExcuteQueryRequest(LoadCollectionRequestData requestData)
        {
            return Context.Commands.LoadCollection(requestData);
        }

        public UpdateCollectionResponseData ExecuteUpdateCollection(UpdateCollectionRequestData updateRequestData)
        {
            UpdateCollectionResponseData updateResponseData = null;
            try
            {
                updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
                 //Console.WriteLine(updateResponseData.ToXml());
            }
            catch (Exception)
            {
                return null;
            }
            return updateResponseData;
        }
      #region Support/Info methods
        /// <summary>
        /// Debugging statement that logs information on a update Request.
        /// </summary>
        /// <param name="updateRequestData"></param>
        /// <returns></returns>
        public string OutputUpdateRequestDataDebugInfo(UpdateCollectionRequestData updateRequestData)
        {
            string retVal = "";

             //Console.WriteLine("** UpdateCollection **");
             //Console.WriteLine("UpdateCollection #items: " + updateRequestData.Items.Count);
             //Console.WriteLine("IDO: " + updateRequestData.IDOName);
             //Console.WriteLine("IDO CustomeUpdate: " + updateRequestData.CustomUpdate);
            if (updateRequestData.Items.Count > 0)
            {
                 //Console.WriteLine("Item Action: " + updateRequestData.Items[0].Action);

                foreach (IDOUpdateProperty prop in updateRequestData.Items[0].Properties)
                {  //Console.WriteLine(prop.Name + " : " + prop.Value);
                }
            }
            else {  //Console.WriteLine("No items in the Request");
            }

            return retVal;
        }

        //The GUID is also known as the sessionID.  In collect we should not need to use this because 
        //   the context object has a link to a session.

        public bool GenerateGUID(ref string GUID, out string ErrorMessage)
        {
            ErrorMessage = "";
            object[] inputParams = new object[]{
                                                ""
                                               };
            InvokeResponseData responseData = InvokeIDO("SLCos", "GenerateGUIDSp", inputParams);
            if (!responseData.ReturnValue.Equals("0"))
            {
                ErrorMessage = "Failed to Generate GUID";
                return false;
            }
            GUID = responseData.Parameters.ElementAt(0).ToString();
            return true;
        }
      #endregion

      #region Basic IDO methods
        public InvokeResponseData InvokeIDO(string idoName, string methodName, object[] inputValues)
        {
            //debugging information.
            ////Console.WriteLine("*- Adapter Config SL ver: " + GetSyteLineVersion() + "  >> " + AssemblyDescription + " : " + AssemblyTrademark);
            ////Console.WriteLine("*- IDO/Method/#Inputs: " + idoName + "/" + methodName + "/" + CallingParamCount);
            ////Console.WriteLine("*- Expected #Inputs: " + IDOMethodParamCount);

            ////if (IDOMethodParamCount != CallingParamCount)
            ////{
            ////    message = "InvokeIDO: Number of IDOMethod parameters does not match the calling number of parameters";
            ////    Console.WriteLine(message);
            ////}

            return Context.Commands.Invoke(idoName, methodName, inputValues); ;
        }

        /// <summary>
        /// Method that returns a count of the number of times the given property is in the IDO.  
        /// If the property is empty then the method returns the number of properties for the IDO.
        /// The most common use is to determine if a property exists on a IDO 0 = property is not on the IDO.
        /// </summary>
        /// <param name="idoname"></param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        public int GetIDOParameterCount(string idoname, string PropertyName = "")
        {

            string filterString = "";
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();

            //get the parameters for a ido and method.
            requestData.IDOName = "IdoProperties"; //gets unposted labor transaction for a employee
            requestData.PropertyList.SetProperties("PropertyName, PropertyDesc");
            //filterString = "CollectionName = 'SLJobTrans' ";
            filterString = "CollectionName = '" + idoname + "'";  //corrected the code so it uses the ido name.  jh:20130213
            if (PropertyName != "")
            {
                filterString += " and PropertyName = '" + PropertyName + "' and DevelopmentFlag=0";
            }

            requestData.Filter = filterString;
            requestData.RecordCap = -1;

            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);

             //Console.WriteLine("** ParameterCount **");
             //Console.WriteLine(" Count: " + responseData.Items.Count);

            if (responseData != null && responseData.Items.Count > 0)
            {
                return responseData.Items.Count;
            }
            return -1;

        }
        public int GetIDOMethodParameterCount(string idoname, string methodname)
        {
            if (idoname.Contains("SL."))
            {
                 //Console.WriteLine("SL.");
                idoname = idoname.Replace("SL.", "");
            }
            //get the parameters for a ido and method.
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "IdoMethodParameters"; //gets unposted labor transaction for a employee
            requestData.PropertyList.SetProperties("CollectionName, ParameterName, Sequence, CreateDate");
            //filterString = "CollectionName = 'SLJobTrans' ";     

            requestData.Filter = "CollectionName = '" + idoname + "' ";
            if (methodname != "")
            {
                requestData.Filter += " and MethodName = '" + methodname + "'  and DevelopmentFlag=0";
            }
            requestData.RecordCap = -1;
            LoadCollectionResponseData responseData = ExcuteQueryRequest(requestData);
            if (responseData != null && responseData.Items.Count > 0)
            {
                return responseData.Items.Count;
            }
            return -1;
        }
      #endregion

    }
}
