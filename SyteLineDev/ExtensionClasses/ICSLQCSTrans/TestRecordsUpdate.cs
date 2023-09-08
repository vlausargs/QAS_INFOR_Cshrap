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
    class TestRecordsUpdate : QcsUtilities
    {
        #region InputVariables

        //Input Variables.
        private string receiverNum = "";
        private string ordType = "";
        private string testId = "";
        private string testSeq = "";
        private string order = "";
        private string passFlag = "";

        private string item = "";
        private string qtyTested = "";
        private string qtyAccepted = "";
        private string qtyRejected = "";
        private string actualMin = "";
        private string actualNominal = "";
        private string actualMax = "";
        private string uom = "";
        private string qcLot = "";
        private string lot = "";
        private string lotSize = "";
        private string sampleSize = "";
        private string inspId = "";
        private string prmCheckFailCode = "";
        private string actualGage = "";
        private string complete = "";
        private string testValue = "";
        private string testType = "";
        private string userInitial = "";



        #endregion

        #region LocalVariables
        //Local Varialbles

        private string errorMessage = "";
        public LoadCollectionResponseData responseReceiverData = null;
        public LoadCollectionResponseData responseTestHeaderData = null;
        public LoadCollectionResponseData responseTestData = null;
        public LoadCollectionResponseData responseEachTestData = null;
        protected UpdateCollectionRequestData updateRequestData;
        protected IDOUpdateItem _updateItem = new IDOUpdateItem();
        private string transDate = "";
        private string WMQCSDatePattern = "yyyy/MM/dd HH:mm:ss";
        private string inspectorName = "";
        private IMessageProvider messageProvider = null;

        #endregion


        public void SetMessageProvider(IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }

        public TestRecordsUpdate(string receiverNum, string ordType, string testId, string testSeq, string order, string passFlag, string item, string qtyTested, string qtyAccepted,
                                 string qtyRejected, string actualMin, string actualNominal, string actualMax, string uom, string qcLot, string lot, string lotSize, string sampleSize, string inspId,
                                 string prmCheckFailCode, string actualGage, string transDate, string complete, string testValue, string testType, string userInitial)


        {
            initialize();
            this.receiverNum = receiverNum;
            this.ordType = ordType;
            this.testId = testId;
            this.testSeq = testSeq;
            this.order = order;
            this.passFlag = passFlag;

            this.item = item;
            this.qtyTested = qtyTested;
            this.qtyAccepted = qtyAccepted;
            this.qtyRejected = qtyRejected;
            this.actualMin = actualMin;
            this.actualNominal = actualNominal;
            this.actualMax = actualMax;
            this.uom = uom;
            this.qcLot = qcLot;
            this.lot = lot;
            this.lotSize = lotSize;
            this.inspId = inspId;
            this.prmCheckFailCode = prmCheckFailCode;
            this.actualGage = actualGage;
            this.complete = complete;
            this.testValue = testValue;
            this.testType = testType;
            this.userInitial = userInitial;



        }

        public void initialize()
        {

            //Input variables initialization
            receiverNum = "";
            testId = "";
            testSeq = "";
            order = "";

            item = "";
            qtyTested = "";
            qtyAccepted = "";
            qtyRejected = "";
            actualMin = "";
            actualNominal = "";
            actualMax = "";
            uom = "";
            qcLot = "";
            lot = "";
            lotSize = "";
            inspId = "";
            prmCheckFailCode = "";
            actualGage = "";
            transDate = "";
            userInitial = "";


        }


        public bool formatInputs()
        {
            receiverNum = formatDataByIDOAndPropertyName("RS_QCRcvrs", "RcvrNum", receiverNum);


            if (receiverNum == null || receiverNum.Trim().Equals(""))
            {
                errorMessage = "receiverNum input mandatory";
                return false;
            }
            if (order.ToUpper() != "JIT")
                order = formatDataByIDOAndPropertyName("SLPoItems", "PoNum", order);



            if (qtyTested == null || qtyTested.Trim().Equals(""))
            {
                errorMessage = "qty tested input mandatory";
                return false;
            }
            try
            {
                if (Convert.ToDouble(qtyTested, CultureInfo.InvariantCulture) <= 0) // FTDEV-9247
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

            if (qtyAccepted == null || qtyAccepted.Trim().Equals(""))
            {
                errorMessage = "qty Accepted input mandatory";
                return false;
            }
            try
            {
                if (Convert.ToDouble(qtyAccepted, CultureInfo.InvariantCulture) < 0) // FTDEV-9247
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





            //   item = updateRequest.GetFieldValue("item");
            if (item == null || item.Trim().Equals(""))

                //uom = updateRequest.GetFieldValue("uom");
                if (uom == null || uom.Trim().Equals(""))
                {
                    errorMessage = "uom input mandatory";
                    return false;
                }



            lot = formatDataByIDOAndPropertyName("SLLotLocs", "Lot", lot);

            inspId = formatDataByIDOAndPropertyName("SLEmployees", "EmpNum", inspId);

            if (complete.Trim().Equals("True"))
            {
                complete = "1";
            }
            else
            {
                complete = "0";
            }

            if (passFlag.Trim().Equals("True"))
            {
                passFlag = "1";
            }
            else
            {
                passFlag = "0";
            }
            return true;
        }


        public bool validateInputs()
        {
            //Validate Receiver Number
            responseReceiverData = ValidateReceiverNum(receiverNum);
            if (order == null) order = "";
            if (testId == null) testId = "0";
            if (testSeq == null) testSeq = "0";
            if (responseReceiverData.Items.Count == 0)
            {
                errorMessage = "Receiver Details Not Found";
                return false;
            }
            if (responseReceiverData[0, "RefNum"].ToString().ToUpper() != order.ToUpper())
            {
                errorMessage = "Order Missmatch";
                return false;
            }
            responseTestHeaderData = GetTestHeader(receiverNum, transDate);
            // Validate test details    
            if (testType.Trim().Equals("B"))
            {
                responseTestData = GetTestDetails(receiverNum, transDate, testId);
                if (responseTestData.Items.Count == 0)
                {
                    errorMessage = "Test Details Not Found";
                    return false;
                }
                transDate = responseTestData[0, "TransDate"].ToString();
            }
            else if (testType.Trim().Equals("E"))
            {
                responseEachTestData = GetEachTestDetails(receiverNum, transDate, testId, testSeq);
                if (responseEachTestData.Items.Count == 0)
                {
                    errorMessage = "Test Details Not Found";
                    return false;
                }
                transDate = responseEachTestData[0, "TransDate"].ToString();
            }

            //Validate InspId 
            if (ValidateInpector(inspId, out inspectorName) == false)
            {
                errorMessage = "Invalide inspector";
                return false;
            }
            return true;
        }

        public int PerformUpdate(out string infobar)
        {
            infobar = "";

            transDate = System.DateTime.Now.ToString(WMQCSDatePattern);
            //2 Format Inputs
            if (formatInputs() == false)
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


            if (performTestRecord() == false)
            {
                infobar = errorMessage;
                return 3;
            }

            return 0;
        }
        // #region private methods
        private bool performTestRecord()
        {
            if (testType.Trim().Equals("B"))
            {
                if (updateBatchDetailRecord() == false)
                {
                    return false;
                }
            }
            else if (testType.Trim().Equals("E"))
            {
                if (updateEachDetailRecord() == false)
                {
                    return false;
                }

            }
            else
            {
                errorMessage = "Invalid Test Type";
                return false;
            }

            return true;
        }

        private bool updateEachDetailRecord()
        {
            try
            {

                updateRequestData = new UpdateCollectionRequestData();
                updateRequestData.IDOName = "RS_QCTesths";
                updateRequestData.RefreshAfterUpdate = true;

                _updateItem.Action = UpdateAction.Update;
                _updateItem.ItemNumber = 1;

                _updateItem.ItemID = responseTestHeaderData.Items[0].ItemID;
                _updateItem.Properties.Add("TransDate", transDate, false);
                _updateItem.Properties.Add("RcvrNum", receiverNum, false);
                _updateItem.Properties.Add("InspId", inspId, false);
                _updateItem.Properties.Add("Lot", lot, false);
                _updateItem.Properties.Add("LotSize", lotSize, true);
                _updateItem.Properties.Add("SampleSize", sampleSize, false);

                _updateItem.Properties.Add("RcvrRefType", ordType, false);
                //_updateItem.Properties.Add("rcvrEntity", entity, false);
                _updateItem.Properties.Add("RcvrRefNum", order, true);
                _updateItem.Properties.Add("RcvrRefLine", responseReceiverData[0, "RefLine"].ToString().ToUpper(), false);

                _updateItem.Properties.Add("RcvrRefRelease", responseReceiverData[0, "RefRelease"].ToString(), false);
                _updateItem.Properties.Add("EmpName", inspectorName, false);

                UpdateCollectionRequestData testDetails = new UpdateCollectionRequestData();
                testDetails.IDOName = "RS_QCTestes";
                testDetails.RefreshAfterUpdate = true;
                PropertyPair[] propertyPair = new PropertyPair[] { new PropertyPair("RcvrNum", "RcvrNum"), new PropertyPair("TransDate", "TransDate") };
                testDetails.LinkBy = propertyPair;
                IDOUpdateItem testItem = new IDOUpdateItem();
                testItem.Action = UpdateAction.Update;
                testItem.ItemID = responseEachTestData.Items[0].ItemID;
                testItem.ItemNumber = 1;


                // testItem.Properties.Add("Sequence", testSeq, true);
                testItem.Properties.Add("TransDate", transDate, false);
                testItem.Properties.Add("RcvrNum", receiverNum, false);
                testItem.Properties.Add("Complete", complete, true);
                // testItem.Properties.Add("CompletedBy", "FT" , true);
                testItem.Properties.Add("CompletedBy", userInitial, true);
                testItem.Properties.Add("TestKey", testId, false);
                testItem.Properties.Add("TesteSeq", testSeq, false);
                testItem.Properties.Add("TestValue", testValue, true);

                testItem.Properties.Add("Pass", passFlag, true);
                /* testItem.Properties.Add("ActualMin", actualMin, true);
                 testItem.Properties.Add("ActualGage", actualGage, true);
                 testItem.Properties.Add("ActualNominal", actualNominal, true);
                 testItem.Properties.Add("ActualMax", actualMax, true); 
                 testItem.Properties.Add("GageExpired", prmCheckFailCode, true);*/
                testItem.Properties.Add("ActualGage", actualGage, true);
                testDetails.Items.Add(testItem);

                _updateItem.NestedUpdates.Add(testDetails);

                updateRequestData.Items.Add(_updateItem);

                //string input = updateRequestData.ToXml();


                OutputUpdateRequestDataDebugInfo(updateRequestData);
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            }
            catch (Exception ee)
            {
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message;
                return false;
            }
            return true;
        }
        private bool updateBatchDetailRecord()
        {
            try
            {

                updateRequestData = new UpdateCollectionRequestData();
                updateRequestData.IDOName = "RS_QCTesths";
                updateRequestData.RefreshAfterUpdate = true;

                _updateItem.Action = UpdateAction.Update;
                _updateItem.ItemNumber = 1;

                _updateItem.ItemID = responseTestHeaderData.Items[0].ItemID;
                _updateItem.Properties.Add("TransDate", transDate, false);
                _updateItem.Properties.Add("RcvrNum", receiverNum, false);
                _updateItem.Properties.Add("InspId", inspId, false);
                _updateItem.Properties.Add("Lot", lot, false);
                _updateItem.Properties.Add("LotSize", lotSize, true);
                _updateItem.Properties.Add("SampleSize", sampleSize, false);

                _updateItem.Properties.Add("RcvrRefType", ordType, false);
                //_updateItem.Properties.Add("rcvrEntity", entity, false);
                _updateItem.Properties.Add("RcvrRefNum", order, true);
                _updateItem.Properties.Add("RcvrRefLine", responseReceiverData[0, "RefLine"].ToString().ToUpper(), false);

                _updateItem.Properties.Add("RcvrRefRelease", responseReceiverData[0, "RefRelease"].ToString(), false);
                _updateItem.Properties.Add("EmpName", inspectorName, false);

                UpdateCollectionRequestData testDetails = new UpdateCollectionRequestData();
                testDetails.IDOName = "RS_QCTestds";
                testDetails.RefreshAfterUpdate = true;
                PropertyPair[] propertyPair = new PropertyPair[] { new PropertyPair("RcvrNum", "RcvrNum"), new PropertyPair("TransDate", "TransDate") };
                testDetails.LinkBy = propertyPair;
                IDOUpdateItem testItem = new IDOUpdateItem();
                testItem.Action = UpdateAction.Update;
                testItem.ItemID = responseTestData.Items[0].ItemID;
                testItem.ItemNumber = 1;


                // testItem.Properties.Add("Sequence", testSeq, true);
                testItem.Properties.Add("TransDate", transDate, false);
                testItem.Properties.Add("RcvrNum", receiverNum, false);
                testItem.Properties.Add("Complete", complete, true);
                //  testItem.Properties.Add("CompletedBy", "FT" , true); 
                testItem.Properties.Add("CompletedBy", userInitial, true);
                testItem.Properties.Add("TestKey", testId.Trim(), true);
                testItem.Properties.Add("QtyTested", qtyTested, true);
                testItem.Properties.Add("QtyFailed", qtyRejected, true);

                testItem.Properties.Add("Pass", passFlag, true);
                testItem.Properties.Add("ActualMin", actualMin, true);
                testItem.Properties.Add("ActualGage", actualGage, true);
                testItem.Properties.Add("ActualNominal", actualNominal, true);
                testItem.Properties.Add("ActualMax", actualMax, true);
                testItem.Properties.Add("GageExpired", prmCheckFailCode, true);
                testDetails.Items.Add(testItem);

                _updateItem.NestedUpdates.Add(testDetails);

                updateRequestData.Items.Add(_updateItem);

                //string input = updateRequestData.ToXml();


                OutputUpdateRequestDataDebugInfo(updateRequestData);
                UpdateCollectionResponseData updateResponseData = this.Context.Commands.UpdateCollection(updateRequestData);
            }
            catch (Exception ee)
            {
                //Console.WriteLine(ee.Message);
                errorMessage = ee.Message;
                return false;
            }
            return true;
        }


    }
}