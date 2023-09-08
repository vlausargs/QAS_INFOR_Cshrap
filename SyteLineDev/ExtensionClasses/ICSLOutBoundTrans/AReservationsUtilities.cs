using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mongoose.Core.Configuration;
using Mongoose.IDO.Protocol;
using Mongoose.IDO;
using Mongoose.Core;
using System.Globalization;

namespace InforCollect.ERP.SL.ICSLOutBoundTrans
{
    abstract class AReservationsUtilities : OutBoundUtilities
    {
        #region Receive methods

        public LoadCollectionResponseData ValidateCustomerOrder(string order)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLCos";
            requestData.PropertyList.SetProperties("CoNum, CustNum");

            string filterString = "";
            filterString += "CoNum ='" + order + "'";
            requestData.Filter = filterString;
            requestData.RecordCap = 1;
            requestData.OrderBy = "CoNum";
            LoadCollectionResponseData orderResponseData = ExcuteQueryRequest(requestData);
            return orderResponseData;
        }

        public LoadCollectionResponseData GetCustomerOrderLines(string order, string line, string release, string site, string noOfDaystoDueDate, bool showAllLines)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLCoitems";
            requestData.PropertyList.SetProperties("CoNum, CoLine, CoRelease, Item, ItDescription, ItLotTracked, ItSerialTracked, ItUM, QtyOrdered, QtyRsvd, QtyReturned, QtyShipped, QtyInvoiced, QtyOrderedConv, QtyPacked, QtyReady, Whse, CustNum, CustItem, CustPo, ItReservable, RowPointer, CoCustNum, CoStat,RecordDate");

            string filterString = "";
            filterString += "CoNum ='" + order + "' and ShipSite ='" + site + "'";
            if (line != null && !(line.Trim().Equals("")))
            {
                filterString += " and CoLine ='" + line + "' ";
            }

            if (release != null && !(release.Trim().Equals("")))
            {
                filterString += " and CoRelease ='" + release + "'";
            }

            if (noOfDaystoDueDate != null && !(noOfDaystoDueDate.Trim().Equals("")))
            {
                string adddays = DateTime.Now.AddDays(Convert.ToDouble(noOfDaystoDueDate, CultureInfo.InvariantCulture)).ToString(WMShortDatePattern); // FTDEV-9247
                filterString += " and DueDate <= '"+adddays+"'";
            }

            if (showAllLines == false)
            {
                filterString += " and ((QtyOrdered - QtyRsvd - QtyShipped) > 0) ";
            }

            requestData.Filter = filterString;
            requestData.RecordCap = -1;
            requestData.OrderBy = "CoNum, CoLine";
            LoadCollectionResponseData orderResponseData = ExcuteQueryRequest(requestData);
            return orderResponseData;
        }

        public LoadCollectionResponseData GetReservations(string order,
                                                          string line,
                                                          string release,
                                                          string whse,
                                                          string loc,
                                                          string lot)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLRsvdInvs";
            requestData.PropertyList.SetProperties("RsvdNum, RefNum, RefLine, RefRelease, Item, Lot, Whse, Loc, QtyRsvd, QtyRsvdConv, CoiDueDate");

            string filterString = "";
            filterString += "RefNum ='" + order + "' and RefLine ='" + line + "'";
            filterString += " and RefRelease ='" + release + "' ";
            filterString += " and Whse ='" + whse + "' ";
            filterString += " and Loc ='" + loc + "' ";
            if (lot != null && !(lot.Trim().Equals("")))
            {
                filterString += " and Lot = '" + lot + "'";
            }
            filterString += " and QtyRsvd > 0";

            requestData.Filter = filterString;
            requestData.RecordCap = -1;
            requestData.OrderBy = "RsvdNum";
            LoadCollectionResponseData orderResponseData = ExcuteQueryRequest(requestData);
            return orderResponseData;
        }

        public LoadCollectionResponseData GetReservations(string order,
                                                          string line,
                                                          string release,
                                                          string whse,
                                                          string loc)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLRsvdInvs";
            requestData.PropertyList.SetProperties("RsvdNum, RefNum, RefLine, RefRelease, Item, Lot, Whse, Loc, QtyRsvd, QtyRsvdConv, CoiDueDate");

            string filterString = "";
            filterString += "RefNum ='" + order + "' and RefLine ='" + line + "'";
            filterString += " and RefRelease ='" + release + "' ";
            filterString += " and Whse ='" + whse + "' ";
            filterString += " and Loc ='" + loc + "' ";
            filterString += " and QtyRsvd > 0";

            requestData.Filter = filterString;
            requestData.RecordCap = -1;
            requestData.OrderBy = "RsvdNum";
            LoadCollectionResponseData orderResponseData = ExcuteQueryRequest(requestData);
            return orderResponseData;
        }

        public LoadCollectionResponseData GetReservationSerials(string reservationNum)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLSerials";
            requestData.PropertyList.SetProperties("SerNum,InWorkflow,Item,Loc,Lot,NoteExistsFlag,RowPointer,Whse,_ItemId,_ItemWarnings,UbSelect,Stat,RefRelease,RefNum,RefLine,RsvdNum");

            string filterString = "";
            filterString += " RsvdNum ='" + reservationNum + "' ";
            filterString += " and Stat ='R' ";

            requestData.Filter = filterString;
            requestData.RecordCap = -1;
            requestData.OrderBy = "SerNum";
            LoadCollectionResponseData orderResponseData = ExcuteQueryRequest(requestData);
            return orderResponseData;
        }

        public LoadCollectionResponseData GetReservations(string order,
                                                          string whse,
                                                          string stageLocation,
                                                          string noofDaysToDueDate)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLRsvdInvs";
            requestData.PropertyList.SetProperties("RsvdNum, RefNum, RefLine, RefRelease, Item, Lot, Whse, Loc, QtyRsvd, QtyRsvdConv, CoiDueDate");
            string adddays = DateTime.Now.AddDays(Convert.ToDouble(noofDaysToDueDate, CultureInfo.InvariantCulture)).ToString(WMShortDatePattern); // FTDEV-9247
            string filterString = "";
            filterString += "RefNum ='" + order + "' ";
            filterString += " and Whse ='" + whse + "' ";
            filterString += " and Loc ='" + stageLocation + "' ";
            filterString += " and CoiDueDate <= '"+adddays+"'  and QtyRsvd > 0 ";

            requestData.Filter = filterString;
            requestData.RecordCap = -1;
            requestData.OrderBy = "RsvdNum";
            LoadCollectionResponseData orderResponseData = ExcuteQueryRequest(requestData);
            return orderResponseData;
        }

        public LoadCollectionResponseData SLCoItemShps(string order,
                                                       string line,
                                                       string release,
                                                       string whse)
        {
            LoadCollectionRequestData requestData = new LoadCollectionRequestData();
            requestData.IDOName = "SLCoItemShps";
            //requestData.PropertyList.SetProperties("CoNum, CoLine, CoRelease, UM, DerShipStat, CoCustNum, AdrName, CoStat, CusPrintPackInv, DueDate, Stat, QtyOrdered, QtyShipped, QtyReturned, QtyInvoiced, QtyOrderedConv, DerQtyShippedConv, DerQtyReturnedConv, DerQtyInvoicedConv, CoEinvoice, CoShipEarly, CoShipPartial, Item, ItDescription, RowPointer, RefType, RefNum, RefLineSuf, RefRelease, ShipDate, DerQtyAvailable, ItwhsQtyOnHand,DerQtyAvailableConv, DerItwhsQtyOnHandConv, ItSerialTracked, Whse, ItLotTracked, CoFixedRate,ItTaxFreeMatl,ItReservable");
            requestData.PropertyList.SetProperties("CoNum, CoLine, CoRelease, UM, DerShipStat, CoCustNum, AdrName, CoStat, CusPrintPackInv, DueDate, Stat, QtyOrdered, QtyShipped, QtyReturned, QtyInvoiced, QtyOrderedConv, DerQtyShippedConv, DerQtyReturnedConv, DerQtyInvoicedConv, CoEinvoice, CoShipEarly, CoShipPartial, Item, ItDescription, RowPointer, RefType, RefNum, RefLineSuf, RefRelease, ShipDate, DerQtyAvailable, ItwhsQtyOnHand,DerQtyAvailableConv, DerItwhsQtyOnHandConv, ItSerialTracked, Whse, ItLotTracked, CoFixedRate,ItTaxFreeMatl,ItReservable, RecordDate"); //added recorddate for MSF159449  JH:20130319
            string filterString = "";
            filterString += "CoNum ='" + order + "' and CoLine ='" + line + "' and CoRelease ='" + release + "' ";
            filterString += " and Whse ='" + whse + "' ";
            filterString += " and (Stat = 'O' or Stat = 'F')";

            requestData.Filter = filterString;
            requestData.RecordCap = -1;
            requestData.OrderBy = "CoNum";
            LoadCollectionResponseData orderResponseData = ExcuteQueryRequest(requestData);
            return orderResponseData;
        }

              
        #endregion

        public bool ShipLcrSp(string order, out string errorMessage)
        {
            errorMessage = "";
            object[] inputValues = new object[]{
                                                order,
                                                //System.DateTime.Now.ToShortDateString(), 
                                                System.DateTime.Now.ToString(WMShortDatePattern), //MSF157397 Date time conversion issue when the customer has culture settings other than US JH:20130128
                                                "Ship",
                                                "",
                                                "",
                                                ""
                                                };
            InvokeResponseData responseData = InvokeIDO("SLCoitemShps", "ShipLcrSp", inputValues);

            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(5).ToString(), "-6", null);
                return false;
            }

            if (!responseData.Parameters.ElementAt(3).ToString().Equals(""))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(3).ToString(), "-7", null);
                return false;
            }
            return true;
        }

        public bool COShippingLoopSp(string docNum, out string errorMessage,bool allowNegInventory = false)
        {
            errorMessage = "";
            object[] inputValues = new object[]{
                                                allowNegInventory==true?"1" : "0",
                                                "",
                                                "0",
                                                "",
                                                "",
                                                "",
                                                "",
                                                docNum
                                                };

            InvokeResponseData responseData = InvokeIDO("SLCoitemShps", "COShippingLoopSp", inputValues);
            //Console.WriteLine("in CustomerOrderShipping 2:" + responseData.Parameters.ElementAt(2).ToString());
            //Console.WriteLine("in CustomerOrderShipping 3:" + responseData.Parameters.ElementAt(3).ToString());
            MessageLogging("in CustomerOrderShipping 2:" + responseData.Parameters.ElementAt(2).ToString(), msgLevel.l1_information, 1200002);
            MessageLogging("in CustomerOrderShipping 3:" + responseData.Parameters.ElementAt(3).ToString(), msgLevel.l1_information, 1200002);

            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(3).ToString(), "-8", null);
                return false;
            }

            if ((responseData.Parameters.ElementAt(2).ToString().Trim().Equals("0")) && (!responseData.Parameters.ElementAt(3).ToString().Equals("")))
            {
                COShippingCleanupSp(out errorMessage);

                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(3).ToString(), "-81", null);
                return false;
            }
            // errorMessage = responseData.Parameters.ElementAt(3).ToString();
            return true;
        }

        public bool COShippingCleanupSp(out string errorMessage)
        {
            errorMessage = "";
            object[] inputValues = new object[] { };
            InvokeResponseData responseData = InvokeIDO("SLCoitemShps", "COShippingCleanupSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage("COShippingCleanupSp Step Failed", "SLACOSH010", null);
                return false;
            }
            return true;

        }
            

        public bool PerformCycleCountCheck(string whse, string item,bool allowIfCycleCountExists,out string errorMessage)
        {
            errorMessage = "";
            object[] inputValues = new object[]{
                                                whse,
                                                item,
                                                "0",
                                                "0",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                ""
                                                };

            InvokeResponseData responseData = InvokeIDO("SLItemwhses", "ItemwhseCheckCntInProcSp", inputValues);
            if (!(responseData.ReturnValue.Equals("0")))
            {
                errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(10).ToString(), "-4", null);
                return false;
            }

            if (allowIfCycleCountExists == false)
            {
                if (!responseData.Parameters.ElementAt(11).ToString().Equals(""))
                {
                    errorMessage = constructErrorMessage(responseData.Parameters.ElementAt(11).ToString(), "-5", null);
                    return false;
                }
            }

            return true;
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

    }
}