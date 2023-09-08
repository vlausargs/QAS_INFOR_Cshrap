using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;



namespace InforCollect.ERP.SL.ICSLInboundTrans
{
    abstract class ATransferOrderUtilities : ICSLCommonLibrary
    {
        #region Receive methods
        public InvokeResponseData ValidateTransferReceiveOrderNo(string order, bool setError, out string outErrorMessage)
        {
            string errorMessage = "";
            outErrorMessage = "";
            object[] inputValues = new object[] { order,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "O",
                                                  "",
                                                  "",
                                                  ""};

            InvokeResponseData responseValues = InvokeIDO("SL.SLTrnacts", "TrrcvTrnNumValidSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(9).ToString(), "-1", null);
                if (setError)
                {
                    outErrorMessage = errorMessage;
                }
            }
            else
            {
                outErrorMessage = "";
            }
            return responseValues;
        }

        public InvokeResponseData ValidateTransferReceiveOrderLine(string order,
                                                                   string line,
                                                                   string fromSite,
                                                                   string fromWhse,
                                                                   string toSite,
                                                                   string toWhse,
                                                                   bool setError,
                                                                   out string outErrorMessage)
        {
            string errorMessage = "";
            outErrorMessage = "";
            object[] inputValues = new object[] { order,
                                                  line,
                                                  fromSite,
                                                  fromWhse,
                                                  toSite,
                                                  toWhse,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "0",
                                                  "",
                                                  ""};

            InvokeResponseData responseValues = InvokeIDO("SL.SLTrnacts", "TrrcvTrnLineValidSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(37).ToString(), "-2", null);
                if (setError)
                {
                    outErrorMessage = errorMessage;
                }
            }
            else
            {
                outErrorMessage = "";
            }
            return responseValues;
        }

        public InvokeResponseData ValidateTransferReceiveSerial(string UserSite,
                                                                string Item,
                                                                string Serial,
                                                                string UseExisting,
                                                                string SelectFlag,
                                                                string FromSite,
                                                                string ToSite,
                                                                string FobSite,
                                                                bool setError,
                                                                out string outErrorMessage)
        {
            string errorMessage = "";
            outErrorMessage = "";
            object[] inputValues = new object[] { UserSite,
                                                  Item,
                                                  Serial,
                                                  UseExisting,
                                                  SelectFlag,
                                                  FromSite,
                                                  ToSite,
                                                  FobSite,
                                                  "1",
                                                  "1",
                                                  "",
                                                  "",
                                                  "",
                                                  ""};

            InvokeResponseData responseValues = InvokeIDO("SL.SLTrnacts", "TrrcvSerErrorSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                outErrorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(12).ToString(), "-3", null);
                if (setError)
                {
                    errorMessage = outErrorMessage;
                }
                return responseValues;
            }
            else
            {
                outErrorMessage = "";
            }

            inputValues = new object[] { Serial,
                                         Item,
                                         "1",
                                         "",
                                         "",
                                         ""};

            responseValues = InvokeIDO("SL.SLCoItemShps", "SerialExpiryDateSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                outErrorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(5).ToString(), "-4", null);
                if (setError)
                {
                    errorMessage = outErrorMessage;
                }
            }
            else
            {
                outErrorMessage = "";
            }

            return responseValues;
        }

        public InvokeResponseData ValidateTransitLocation(string site,
                                                          string whse,
                                                          string item,
                                                          string loc,
                                                          bool setError, out string outErrorMessage)
        {
            string errorMessage = "";
            outErrorMessage = "";
            object[] inputValues = new object[] { site,
                                                  whse,
                                                  item,
                                                  loc,
                                                  "",
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SL.SLTrnacts", "TlocChkSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(6).ToString(), "-5", null);
                if (setError)
                {
                    outErrorMessage = errorMessage;
                }
            }
            else
            {
                outErrorMessage = "";
            }
            return responseValues;
        }

        public InvokeResponseData ValidatePostTransitLocation(string site,
                                                          string whse,
                                                          string item,
                                                          string loc,
                                                          bool setError, out string outErrorMessage)
        {
            string errorMessage = "";
            outErrorMessage = "";
            object[] inputValues = new object[] { site,
                                                  whse,
                                                  item,
                                                  loc,
                                                  ""
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SL.SLTrnacts", "TlocChkPostSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(4).ToString(), "-6", null);
                if (setError)
                {
                    outErrorMessage = errorMessage;
                }
            }
            else
            {
                outErrorMessage = "";
            }
            return responseValues;
        }

        public InvokeResponseData ValidateItemFlSp(string site, string whse, string item, string transitLocation, string order, string line, string lot, string uomfactor, string qty, out string outErrorMessage)
        {
            outErrorMessage = "";
            object[] inputValues = new object[] { site,
                                                  whse,
                                                  item,
                                                  transitLocation,
                                                  order,
                                                  line,
                                                  lot,
                                                  uomfactor,
                                                  qty,
                                                  ""
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SLTrnacts", "ItemFlSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                outErrorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(9).ToString(), "-6", null);
            }
            return responseValues;
        }


        #endregion

        #region Ship Methods

        public InvokeResponseData ValidateTransferShipOrderNo(string order, bool setError, out string outErrorMessage)
        {
            string errorMessage = "";
            outErrorMessage = "";
            object[] inputValues;
            //int paramcount = 0;
            //paramcount = GetIDOMethodParameterCount("SL.SLTrnacts", "TrnShipTrnNumValidSp");
            //switch (paramcount)
            //{
            //    case 9:
                    inputValues = new object[] { order,
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  "",
                                                  ""};
                //    break;
                //default:
                //    inputValues = new object[] { order,
                //                                  "",
                //                                  "",
                //                                  "",
                //                                  "",
                //                                  "",
                //                                  "",
                //                                  ""};
                //    break;
           // }
            InvokeResponseData responseValues = InvokeIDO("SL.SLTrnacts", "TrnShipTrnNumValidSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(6).ToString(), "-7", null);
                if (setError)
                {
                    outErrorMessage = errorMessage;
                }
            }
            else
            {
                outErrorMessage = "";
            }
            return responseValues;
        }

        public InvokeResponseData ValidateTransferShipSerial(string UserSite,
                                                                string Item,
                                                                string Serial,
                                                                string UseExisting,
                                                                string SelectFlag,
                                                                string FromSite,
                                                                string ToSite,
                                                                string FobSite,
                                                                bool setError,
                                                                out string outErrorMessage)
        {
            string errorMessage = "";
            outErrorMessage = "";
            object[] inputValues = new object[] { UserSite,
                                                  Item,
                                                  Serial,
                                                  UseExisting,
                                                  SelectFlag,
                                                  FromSite,
                                                  ToSite,
                                                  "1",
                                                  "1",
                                                  "",
                                                  "",
                                                  "",
                                                  ""
                                                  };

            InvokeResponseData responseValues = InvokeIDO("SL.SLTrnacts", "TrcombSerErrorSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(12).ToString(), "-8", null);
                if (setError)
                {
                    outErrorMessage = errorMessage;
                }
                return responseValues;
            }
            else
            {
                outErrorMessage = "";
            }

            inputValues = new object[] { Serial,
                                         Item,
                                         "1",
                                         "",
                                         "",
                                         ""};

            responseValues = InvokeIDO("SL.SLCoItemShps", "SerialExpiryDateSp", inputValues);
            if (!(responseValues.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseValues.Parameters.ElementAt(5).ToString(), "-9", null);
                if (setError)
                {
                    outErrorMessage = errorMessage;
                }
            }
            else
            {
                outErrorMessage = "";
            }

            return responseValues;
        }

        #endregion

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

    }
}