//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ToBeShippedValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_ToBeShippedValue
    {
        (ICollectionLoadResponse Data,
        int? ReturnCode) Rpt_ToBeShippedValueSp(
            string pCoType = null,
            string pCoStat = null,
            string pCoitemStat = null,
            int? pTransDomCurr = null,
            int? pSortByCurrency = null,
            string pCreditHold = null,
            int? pDispSubTots = null,
            string pStartCoNum = null,
            string pEndCoNum = null,
            string pStartCustNum = null,
            string pEndCustNum = null,
            DateTime? pStartOrderDate = null,
            DateTime? pEndOrderDate = null,
            string pStartCustPo = null,
            string pEndCustPo = null,
            string pStartItem = null,
            string pEndItem = null,
            string pStartCustItem = null,
            string pEndCustItem = null,
            DateTime? pStartDueDate = null,
            DateTime? pEndDueDate = null,
            DateTime? pStartShipDate = null,
            DateTime? pEndShipDate = null,
            string pStartCurrCode = null,
            string pEndCurrCode = null,
            int? PrintCost = 0,
            int? PrintPrice = 0,
            int? DisplayHeader = null,
            string BGSessionId = null,
            int? TaskId = null,
            string pSite = null,
            string BGUser = null);
    }
}

