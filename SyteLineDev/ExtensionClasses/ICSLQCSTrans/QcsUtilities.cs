using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;


namespace InforCollect.ERP.SL.ICSLQCSTrans
{
    class QcsUtilities : ICSLCommonLibrary
    {
        private LoadCollectionResponseData receiverNumResponseData = null;
        //public bool ValidateReceiverNum(string receiverNum )
        //{
        //    LoadCollectionRequestData requestData = new LoadCollectionRequestData();
        //    requestData.IDOName = "RS_QCRcvrs";
        //    requestData.PropertyList.SetProperties("RcvrNum, RefType, Stat, VendNum");
        //    string filterString = "";
        //    filterString += " RcvrNum ='" + receiverNum + "'";
        //    filterString += " and (Complete = 0)";
        //    requestData.Filter = filterString;
        //    requestData.RecordCap = 1;
        //    requestData.OrderBy = "RcvrNum";
        //    receiverNumResponseData = ExcuteQueryRequest(requestData);
        //    if (receiverNumResponseData.Items.Count == 0)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        public bool ValidateReceiverNum(string receiverNum,string refType)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "RS_QCRcvrs";
            requestData.PropertyList.SetProperties("RcvrNum, RefType");
            string filterString = "";
            filterString += " RcvrNum =" + receiverNum +  " AND RefType ='" + refType + "'";
            filterString += " and (Complete = 0)";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "RcvrNum";
            receiverNumResponseData = ExcuteQueryRequest(requestData);
            if (receiverNumResponseData.Items.Count == 0)
            {
                return false;
            }
            return true;
        }
        public LoadCollectionResponseData ValidateReceiverNum(string receiverNum)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "RS_QCRcvrs";
            requestData.PropertyList.SetProperties("RcvrNum, RefType,Item, QtyReceived,QtyAccepted,QtyRejected,QtyHold,RefNum,RefLine,RefRelease,RefRelease,TestSeq,Entity");
            string filterString = "";
            filterString += " RcvrNum ='" + receiverNum + "'";
            filterString += " and (Complete = 0)";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "RcvrNum";
            return ExcuteQueryRequest(requestData);
             
        }

        public LoadCollectionResponseData GetTestHeader(string receiverNum ,string transDate)
        {
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "RS_QCTesths";
            requestData.PropertyList.SetProperties("TransDate,RcvrNum, InspId, Revision, VendLot, Lot, LotSize, SampleSize, RcvrItem, RcvrRefType, RcvrRefNum, RcvrRefLine, RcvrOperNum, RcvrTestSeq, RcvrTestType ");
          //  requestData.Filter = " RcvrNum =" + receiverNum  + " AND TransDate = '"+transDate+ "'"  ;
            requestData.Filter = " RcvrNum =" + receiverNum ;
            requestData.RecordCap = 1;
            requestData.OrderBy = "TransDate desc";             
            return ExcuteQueryRequest(requestData);
        }
        public LoadCollectionResponseData GetTestDetails(string receiverNum, string transDate,string testKey)
        {
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "RS_QCTestds";
            requestData.PropertyList.SetProperties("TransDate,RcvrNum, Sequence, Qcmethod, TestKey, TestType, Complete, QtyTested, QtyFailed, ExpectedMin, ExpectedNominal, ExpectedMax, ExpectedGage ");
            requestData.Filter = " RcvrNum =" + receiverNum +" AND TestKey= "+testKey   ;
            requestData.RecordCap = 1;
            requestData.OrderBy = "TransDate desc";             
            return ExcuteQueryRequest(requestData);
        }
        public LoadCollectionResponseData GetTestDetails(string receiverNum, string transDate )
        {
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "RS_QCTestds";
            requestData.PropertyList.SetProperties("TransDate,RcvrNum, Sequence, Qcmethod, TestKey, TestType, Complete, QtyTested, QtyFailed, ExpectedMin, ExpectedNominal, ExpectedMax, ExpectedGage ");
            requestData.Filter = " RcvrNum =" + receiverNum + " AND TransDate = '" + transDate + "'";
            requestData.RecordCap = 1;
            requestData.OrderBy = "TransDate desc";
            return ExcuteQueryRequest(requestData);
        }
        public LoadCollectionResponseData GetEachTestDetails(string receiverNum, string transDate, string testKey, string testSeq)
        {
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "RS_QCTestes";
            requestData.PropertyList.SetProperties("TransDate,RcvrNum, TesteSeq, TestdQcmethod, TestKey,  Complete, TestdPassFailOnly, TestValue, TestdExpectedMin, TestdExpectedNominal, TestdExpectedMax, TestdExpectedGage ");
            requestData.Filter = " RcvrNum =" + receiverNum + " AND TestKey= " + testKey + " AND TesteSeq = " + testSeq;
            requestData.RecordCap = 1;
            requestData.OrderBy = "TransDate desc";
            return ExcuteQueryRequest(requestData);
        }

        public LoadCollectionResponseData GetTestExecuted(string receiverNum, string transDate)
        {
            Initialize();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "RS_QCTestes";
            requestData.PropertyList.SetProperties("TransDate,RcvrNum, TesteSeq, TestdQcmethod, TestKey,  Complete, TestdPassFailOnly, TestValue, TestdExpectedMin, TestdExpectedNominal, TestdExpectedMax, TestdExpectedGage ");
            requestData.Filter = " RcvrNum =" + receiverNum   ;
            requestData.RecordCap = 1;
            requestData.OrderBy = "TransDate desc";             
            return ExcuteQueryRequest(requestData);
        }

        public bool validateCoc(string receiverNum, string cocNum)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "RS_QCCocs";
            requestData.PropertyList.SetProperties("RcvrNum, CocNum");
            string filterString = "";
            filterString += " RcvrNum =" + receiverNum + " AND CocNum ='" + cocNum + "'";
             
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "RcvrNum";
            receiverNumResponseData = ExcuteQueryRequest(requestData);
            if (receiverNumResponseData.Items.Count == 0)
            {
                return false;
            }
            return true;
        }
        public bool ValidateInpector(string inspId, out string  inspectorName) 
        {
            inspectorName = "";

            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLEmployees";
            requestData.PropertyList.SetProperties("EmpNum, Name");
            string filterString = " EmpNum = '" + inspId+ "'";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "EmpNum";
            receiverNumResponseData = ExcuteQueryRequest(requestData);
            if (receiverNumResponseData.Items.Count == 0)
            {
                return false;
            }
            else
            {
                inspectorName = receiverNumResponseData[0, "Name"].ToString();
                return true;
            }             
        }
        
        public void refreshSummary(string receiverNum, string transDate)
        {
            
            object[] inputValues = new object[] {  receiverNum,
                                                    transDate,
                                                        ""
                                                        };

            InvokeResponseData responseData = this.Context.Commands.Invoke("RS_QCTesths", "RSQC_CreateUpdateTestSummarySp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
             
            }
        }

        public bool GenerateBatchTest(string receiverNum, string transDate, out string errorMessage)
        {
            errorMessage = "";
            object[] inputValues = new object[] {  receiverNum,
                                                   transDate,
                                                   "",
                                                   errorMessage
                                                        
                                                        };

            InvokeResponseData responseData = this.Context.Commands.Invoke("RS_QCTesths", "RSQC_CreateBatchTestsSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = "Generate Failed" ;
                return false;
            }
             return true;
             
        }
        public bool GenerateEachTest(string receiverNum, string transDate,string sampleSize, out string errorMessage)
        {
            errorMessage = "";
            object[] inputValues = new object[] {  receiverNum,
                                                    transDate,
                                                    sampleSize,
                                                    errorMessage  
                                                        };

            InvokeResponseData responseData = this.Context.Commands.Invoke("RS_QCTesths", "RSQC_CreateEachTestsSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = "Generate Failed";
                return false;
            }
            return true;

        }
        public bool ValidateTestPlansExists(string receiverNum, string refType, out string errorMessage)
        {
            errorMessage = "";
            object[] inputValues = new object[] {  receiverNum , 
                                                    "",
                                                    errorMessage
                                                        
                                                        };

            InvokeResponseData responseData = this.Context.Commands.Invoke("RS_QCInspSups", "RSQC_CheckforTestPlanSp", inputValues);
            if ((responseData.ReturnValue.Equals("0")))
            {
                if (responseData.Parameters.ElementAt(1).ToString().ToUpper() == "YES")
                {
                    return true;
                }
                else
                {
                    errorMessage = "Test Plans does not exists";
                    return false;
                }
            }
            errorMessage = "Test Plans does not exists";
             return false;
             
        }

        public bool GetTestDataSp(string receiverNum, string transDate, out string errorMessage)
        {
            errorMessage = "";
            object[] inputValues = new object[] {  receiverNum,
                                                    transDate,
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    ""
                                                        
                                                        };

            InvokeResponseData responseData = this.Context.Commands.Invoke("RS_QCTesths", "RSQC_GetTestDataSp", inputValues);
            if ((responseData.ReturnValue.Equals("0")))
            {
                if (responseData.Parameters.ElementAt(0).ToString().ToUpper() == "YES" || responseData.Parameters.ElementAt(1).ToString().ToUpper() == "YES")
                {
                    errorMessage = "Tests already generated";
                    return false;
                }
                
                return true;
            }
            errorMessage = "Sp not returned values";
            return false;

        }
        public bool IsStringContainsNumericValue(string Value)
        {

            bool isNumeric = false;
            foreach (char c in Value)
            {
                if (Char.IsNumber(c))
                {
                    isNumeric = true;
                    break;
                }
            }
            return isNumeric;

        }
        public bool IsStringStartsWithNumEndsWithNonNumeric(string Value)
        {

            bool isNumeric = false;

            if (Char.IsNumber(Convert.ToChar(Value.Substring(0, 1))) == false)
            {
                return false;
            }

            foreach (char c in Value)
            {
                if (Char.IsNumber(c) == false)
                {
                    isNumeric = true;
                    break;
                }
            }
            return isNumeric;

        }


    }
}
