using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLQCSTrans
{
    class DispositionUpdate : QcsUtilities
    {
        #region InputVariables

        //Input Variables.
        private string receiverNum = "";
            
        private string ordType = "";         
       
        private string order = "";
        private string completeFlag = "";
        private string userCode = "";
        private string inspId = "";        
        private string qtyAccepted = "" ;
        private string acceptReason = "";
        private string acceptDispCode = "";
        private string qtyRejected = "";
        private string rejectReason = "";
        private string rejectDispCode = "";
        private string rejectCause = "";
        private string rejectDispType = "";

        private string qtyHold = "";
        private string MrrHoldReason = "";
        private string MrrNum = "";
        private string qtyScrapped = "";
        private string scrapReason = "";
        private string OperComplete = "";
        private string additionalQty = "";
        private string cocNum = "";
        private string userInitial = "";

       
        #endregion 

        #region LocalVariables
        //Local Varialbles
        private string item = "";  
        private string testSeq = "";
        private string line = "";
        private string release = "";
        private string entity = "";
        private double   qtyDisposed = 0;
        private double qtyCumulativeDisposition = 0;
         
                                                    
        private string acceptMatlMove = "";
        private string rejectMatlMove = "";
        private string createNewCoc = "0";

        private string errorMessage = "";
        public LoadCollectionResponseData responseReceiverData = null;
        protected IDOUpdateItem _updateItem = new IDOUpdateItem();
        private string transDate = "";
        private string WMQCSDatePattern = "yyyy/MM/dd HH:mm:ss";
        private IMessageProvider messageProvider = null;
        
        #endregion
       

        public void SetMessageProvider(IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }

        public DispositionUpdate(string receiverNum,  string ordType, string order, string completeFlag, string userCode, string inspId, string qtyAccepted, string acceptReason, 
                                 string acceptDispCode,string qtyRejected, string rejectReason, string rejectDispCode, string rejectCause, string rejectDispType, string qtyHold, string MrrHoldReason, string MrrNum,
                                 string qtyScrapped, string scrapReason, string OperComplete,string additionalQty,string cocNum,string userInitial)
                                
                                 

        {
            initialize();
            this.receiverNum = receiverNum;
            
            this.ordType = ordType;
           
            
            this.order = order;
            this.completeFlag = completeFlag;
            this.userCode = userCode;
            this.inspId = inspId;
            this.qtyAccepted = qtyAccepted;
            this.acceptReason = acceptReason;
            this.acceptDispCode = acceptDispCode;

            this.qtyRejected = qtyRejected;
            this.rejectReason = rejectReason;
            this.qtyRejected = qtyRejected;
            this.rejectDispCode = rejectDispCode;
            this.rejectCause = rejectCause;
            this.rejectDispType = rejectDispType;
            this.qtyHold = qtyHold;
            this.MrrHoldReason = MrrHoldReason;
            this.MrrNum = MrrNum;
            this.qtyScrapped = qtyScrapped;
            this.scrapReason = scrapReason;
            this.OperComplete = OperComplete;
            this.additionalQty = additionalQty;
            this.cocNum = cocNum;
            this.userInitial = userInitial ;
             
             

        }

        public void initialize()
        {
             
            //Input variables initialization
            receiverNum = "";
            item = "";
            ordType = "";
            testSeq = "";
            order = "";
            completeFlag = "";
            userCode = "";
            inspId = "";
            qtyAccepted = "";
            acceptReason = "";
            acceptDispCode = "";
            qtyRejected = "";
            rejectReason = "";
            rejectDispCode = "";
            rejectCause = "";             
            transDate = "";
        }
        public bool formatInputs()
        {

            if (receiverNum == null || receiverNum.Trim().Equals(""))
            {
                errorMessage = "receiverNum input mandatory";
                return false;
            }
            responseReceiverData = ValidateReceiverNum(receiverNum);
            if (responseReceiverData.Items.Count == 0)
            {
                errorMessage = "Receiver Details Not Found";
                return false;
            }
            if (order.ToUpper() != "JIT")
            {
                if (IsStringContainsNumericValue(order) && IsStringStartsWithNumEndsWithNonNumeric(order) == false)
                {
                    order = formatDataByIDOAndPropertyName("SLPoItems", "PoNum", order);
                }                
            }
            if (responseReceiverData[0, "RefNum"].ToString().ToUpper() != order.ToUpper())
            {
                errorMessage = "Order Missmatch";
                return false;
            }
            item = responseReceiverData[0, "Item"].ToString();             
            release = responseReceiverData[0, "RefRelease"].ToString();
            line = responseReceiverData[0, "RefRelease"].ToString();
            entity = responseReceiverData[0, "Entity"].ToString();
            testSeq = responseReceiverData[0, "TestSeq"].ToString();

            if (qtyAccepted == null || qtyAccepted.Trim().Equals(""))
            {
                errorMessage = "qty Accepted input mandatory";
                return false;
            }
            try
            {
                if (Convert.ToDouble(qtyAccepted, CultureInfo.InvariantCulture) < 0) // FTDEV-9247
                {
                    errorMessage =  "Quantity should be greater than 0";
                    return false;
                }
            }
            catch (InvalidCastException)
            {
                errorMessage =  "Invalid Quantity Input";
                return false;
            }

            if (qtyHold == null || qtyHold.Trim().Equals(""))
            {
                errorMessage = "qty Accepted input mandatory";
                return false;
            }
            try
            {
                if (Convert.ToDouble(qtyHold, CultureInfo.InvariantCulture) < 0) // FTDEV-9247
                {
                    errorMessage = "Quantity can not be negative";
                    return false;
                }
            }
            catch (InvalidCastException)
            {
                errorMessage = "Invalid Quantity Input";
                return false;
            }


            if (qtyRejected == null || qtyRejected.Trim().Equals(""))
            {
                errorMessage = "qty tested input mandatory";
                return false;
            }
            try
            {
                if (Convert.ToDouble(qtyRejected, CultureInfo.InvariantCulture) < 0) // FTDEV-9247
                {
                    errorMessage = "Quantity should be greater than 0";
                    return false;
                }
            }
            catch (InvalidCastException)
            {
                errorMessage = "Invalid Quantity Input";
                return false;
            }
            try
            {

               if( Convert.ToDouble(qtyRejected, CultureInfo.InvariantCulture) == 0 && Convert.ToDouble(qtyHold, CultureInfo.InvariantCulture) == 0 && Convert.ToDouble(qtyAccepted, CultureInfo.InvariantCulture) == 0) // FTDEV-9247
                {
                   errorMessage = "Quantity should be greater than 0";
                   return false;
               }
            }
            catch (InvalidCastException)
            {
                errorMessage = "Invalid Quantity Input";
                return false;
            }
            qtyDisposed = Convert.ToDouble(responseReceiverData[0, "QtyRejected"].ToString(), CultureInfo.InvariantCulture) + Convert.ToDouble(responseReceiverData[0, "QtyAccepted"].ToString(), CultureInfo.InvariantCulture) + Convert.ToDouble(responseReceiverData[0, "QtyHold"].ToString(), CultureInfo.InvariantCulture); // FTDEV-9247
            qtyCumulativeDisposition = Convert.ToDouble(qtyRejected, CultureInfo.InvariantCulture) + Convert.ToDouble(qtyHold, CultureInfo.InvariantCulture) + Convert.ToDouble(qtyAccepted, CultureInfo.InvariantCulture)  + qtyDisposed; // FTDEV-9247
            if (Convert.ToDouble(responseReceiverData[0, "QtyReceived"].ToString(), CultureInfo.InvariantCulture) < qtyCumulativeDisposition && ordType.Trim().Equals('P')) // FTDEV-9247
            {
                errorMessage = "Total Disposition Qty greater than Received Qty ";
                return false;
            }
            return true;
        }


        public bool validateInputs()
        {
            //Validate Receiver Number
           responseReceiverData= ValidateReceiverNum(receiverNum);
           if (responseReceiverData.Items.Count == 0)   
            {
                errorMessage =  "Receiver Details Not Found";
                return false;
            }
           if (responseReceiverData[0, "RefNum"].ToString().ToUpper() != order.ToUpper())
            {
                errorMessage = "Order Missmatch";
                return false;
            }
            if (cocNum == null )
           {
               // No Coc for the transaction
               createNewCoc = "";
           }
            else if ((cocNum.Trim().Equals("0")))
           {
               // Create New COC
               createNewCoc = "1";
           }
          
           else
           { 
               // Use existing Coc
               cocNum =  formatDataByIDOAndPropertyName("RS_QCCocs", "CocNum", cocNum);
               if (validateCoc(receiverNum, cocNum) == false)
               {
                   errorMessage = "Invalid Coc";
                   return false;
               }
               createNewCoc = "0";
           }

             // Validate Qty    
            
            return true;
        }
        //perform update
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


            if (performDispositionUpdate() == false)
            {
                infobar = errorMessage;
                return 3;
            }
           
            return 0;
        }
       // #region private methods
        private bool performDispositionUpdate()
        {
            if (PostDisposition() == false)
            {
                return false;
            }
            
            return true;
        }

        private bool PostDisposition()
        {
             

            object[] inputValues = new object[] {  
                                                    Convert.ToInt64 (receiverNum, CultureInfo.InvariantCulture), // FTDEV-9247
                                                    item,
                                                    entity,
                                                     Convert.ToInt16(testSeq, CultureInfo.InvariantCulture), // FTDEV-9247
                                                    ordType,   //5
                                                    order,  
                                                     Convert.ToInt16(line, CultureInfo.InvariantCulture), // FTDEV-9247
                                                    Convert.ToInt16(release, CultureInfo.InvariantCulture), // FTDEV-9247
                                                    transDate,
                                                    "0" ,   //Hourse worked   //10
                                                    additionalQty,    //AddlQtyReceived  
                                                    "0",    //AcceptPrinted
                                                    "0", 
                                                   // "",    //User Code
                                                    userInitial ,
                                                    inspId,     //15
                                                    Convert.ToDouble(qtyAccepted, CultureInfo.InvariantCulture), // FTDEV-9247
                                                    acceptReason,
                                                    acceptDispCode,
                                                    cocNum,  //Coc  Num
                                                    createNewCoc,  // Create Coc   //20
                                                    Convert.ToDouble(qtyHold, CultureInfo.InvariantCulture), // FTDEV-9247
                                                    MrrHoldReason,
                                                    MrrNum,
                                                    Convert.ToDouble(qtyRejected, CultureInfo.InvariantCulture) , // FTDEV-9247
                                                    rejectReason,   //25
                                                    rejectDispCode,
                                                    rejectCause,
                                                    rejectDispType,
                                                   Convert.ToDouble( qtyScrapped, CultureInfo.InvariantCulture), // FTDEV-9247
                                                    scrapReason,  //30
                                                    "0",
                                                    acceptMatlMove,
                                                    rejectMatlMove,
                                                    "",//Message
                                                    "" , //ErrorCode   //35
                                                    "" , //  Mrr out

                                                    ""//Infobar
                                                        
                                                        };

            InvokeResponseData responseData = this.Context.Commands.Invoke("RS_QCDisps", "RSQC_PostDispositionSp", inputValues);
            if ((responseData.ReturnValue.Equals("0")))
            {
                errorMessage = responseData.Parameters.ElementAt(36).ToString().ToUpper();
                return true;
            }
            else
            {
                 errorMessage = "Disposition failed";
            return false;
            }
           
           
        }
         

    }
}
