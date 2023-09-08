using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;



namespace InforCollect.ERP.SL.ICSLQCSTrans
{
    class GenerateTestUpdate : QcsUtilities
    {
        #region InputVariables

        //Input Variables.
        private string receiverNum = "";
        private string refType = "";
        private string testType = "";
        private string lot = "";
        private string qcLot = "";        
        private string lotSize = "";
        private string sampleSize = "";
        private string inspId = "";
                 
         
         
        
        #endregion 

        #region LocalVariables
        //Local Varialbles
        public LoadCollectionResponseData responseData_testHeader = null ;
        public LoadCollectionResponseData responseData_testDetails = null;
        public LoadCollectionResponseData responseData_teste = null;
        public LoadCollectionResponseData responseData_testf = null;
        //public UpdateCollectionRequestData updateRequestData;
        protected UpdateCollectionRequestData updateRequestData;
         protected IDOUpdateItem _updateItem = new IDOUpdateItem();
        private string errorMessage = "";
        public string transDate = ""; 
        private new string WMShortDatePattern = "yyyy/MM/dd";
        private string WMQCSDatePattern = "yyyy/MM/dd HH:mm:ss";

        private string inspectorName = "";
          

        private IMessageProvider messageProvider = null;
        
        #endregion
    

        public void SetMessageProvider(IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }

        public GenerateTestUpdate(string receiverNum, string refType, string testType, string lot, string qcLot, string lotSize, string sampleSize, string inspId )
                                 

        {
            initialize();
            this.receiverNum = receiverNum;
            this.refType = refType;
            this.testType = testType;
            this.qcLot = qcLot;
            this.lot = lot;
            this.lotSize = lotSize;            
            this.sampleSize = sampleSize;
            this.inspId = inspId;                         
                     

        }

        public void initialize()
        {
             
            //Input variables initialization
            receiverNum = "";
            refType = "";
            lot = "";
            qcLot = "";
            lotSize = "";
            sampleSize = "";
            inspId = "";            
               

        }


        public bool formatInputs()
        {
            receiverNum = formatDataByIDOAndPropertyName("RS_QCRcvrs", "RcvrNum", receiverNum);

            if (receiverNum == null || receiverNum.Trim().Equals(""))
            {
                errorMessage = "receiverNum input mandatory";
                return false;
            }

            if (lotSize == null || lotSize.Trim().Equals(""))
            {
                errorMessage =  "qty tested input mandatory";
                return false;
            }
            try
            {
                //if (Convert.ToDouble(lotSize, CultureInfo.InvariantCulture) <= 0) // FTDEV-9247
                //{
                //    errorMessage =  "Quantity should be greater than 0";
                //    return false;
                //}
            }
            catch (InvalidCastException)
            {
                errorMessage =  "Invalid Quantity Input";
                return false;
            }
            if (sampleSize == null || sampleSize.Trim().Equals(""))
            {
                sampleSize = "0";
            }
            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);
            if (inspId == null || inspId.Trim().Equals(""))
            {
                errorMessage = "Inspector Id input is mandatory";
                return false;
            }
            inspId = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", inspId);
 
            return true;
        }


        public bool validateInputs()
        {
            //Validate ReceiverNum
            if (ValidateReceiverNum(receiverNum,refType) == false)   
            {
                errorMessage =  "Receiver Details Not Found";
                return false;
            }
            // Validate Test plans exists
            if (ValidateTestPlansExists(receiverNum, refType ,out errorMessage) == false)
            {                 
                return false;
            }
            //Validate InspId 
            if (ValidateInpector(inspId, out inspectorName) == false)
            {
                errorMessage = "Invalide inspector";
                    return false;
            }

            //GetTestDataSp

            if (GetTestDataSp(receiverNum, transDate, out  errorMessage) == false)
             {
                 return false;
                }
            //Check if any tests created 
            
            responseData_testHeader = GetTestHeader(receiverNum,transDate );
            if(responseData_testHeader.Items.Count > 0)
            { return false;

            }
            // Check for any tests executed 
            responseData_testDetails = GetTestDetails(receiverNum, transDate);
            if (responseData_testHeader.Items.Count > 0)
            {
                return false;

            }
            // Check for any tests executed 
            responseData_teste = GetTestExecuted(receiverNum, transDate);
            if (responseData_testHeader.Items.Count > 0)
            {
                return false;

            }     

            return true;
        }

        public int PerformUpdate(out string infobar )
        {
            infobar = "";
            transDate = System.DateTime.Now.ToString(WMQCSDatePattern);      
            //2 Format Inputs
            if (formatInputs( ) == false)
            {
               infobar = errorMessage;
                return 1;
            }
            //3 validate Inputs
            if (validateInputs() == false)
            {
               infobar = errorMessage;
                return 2;
            }

            //4 Perform Updates
            if (performGenerate() == false)
            {
                infobar = errorMessage;
                return 3;
            }
           
            return 0;
        }
       // #region private methods
        private bool performGenerate()
        {
            try {
                //1 Date Check
                object[] dateCheckValues = new object[] { //System.DateTime.Now.ToShortDateString(), 
                                                      System.DateTime.Now.ToString(WMShortDatePattern),
                                                      "Transaction Date",
                                                      "@%update",
                                                      "",
                                                      "",
                                                      "" };

                InvokeResponseData invokeResponseDataStep1 = this.Context.Commands.Invoke("SLPeriods", "DateChkSp", dateCheckValues);
                if (!(invokeResponseDataStep1.ReturnValue.Equals("0")))
                {
                    errorMessage = invokeResponseDataStep1.Parameters.ElementAt(3).ToString();
                    return false;
                }

                if (UpdateTestHeader() == false)
                {
                    return false;
                }

                refreshSummary(receiverNum, transDate);

                if (testType == "B")
                {
                    if (GenerateBatchTest(receiverNum, transDate, out errorMessage) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if (GenerateEachTest(receiverNum, transDate, sampleSize, out errorMessage) == false)
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message; 
            }
            return true;
        }

       private bool UpdateTestHeader()
       {

           updateRequestData = new UpdateCollectionRequestData();
            updateRequestData.IDOName =  "RS_QCTesths" ; 
            updateRequestData.RefreshAfterUpdate = true;

            _updateItem.Action = UpdateAction.Insert;

           // _updateItem.Properties.Add("ItemNo", "0", true);
            _updateItem.Properties.Add("TransDate", transDate, true);
            _updateItem.Properties.Add("RcvrNum", receiverNum, true);
            _updateItem.Properties.Add("InspId", inspId, true);
            _updateItem.Properties.Add("Lot", lot, true);
            _updateItem.Properties.Add("LotSize", lotSize, true);
            _updateItem.Properties.Add("SampleSize", sampleSize, true);
            _updateItem.Properties.Add("EmpName", inspectorName, true);
            _updateItem.Properties.Add("VendLot", qcLot, true);
            
            updateRequestData.Items.Add(_updateItem);
            
            OutputUpdateRequestDataDebugInfo(updateRequestData); 
            UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            //}
            //catch (Exception ee)
            //{
            //    Console.WriteLine(ee.Message);
            //    errorMessage = ee.Message;
            //    return false;
            //}
         return true;
}
  


    }
}
