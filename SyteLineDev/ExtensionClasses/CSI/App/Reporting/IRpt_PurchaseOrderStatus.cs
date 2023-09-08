//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchaseOrderStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
    public interface IRpt_PurchaseOrderStatus
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseOrderStatusSp(string pPoType = null,
        string pPoitemStat = null,
        string pPoStat = null,
        string pSortBy = null,
        int? pIncludeGrn = null,
        int? pTransDomCurr = null,
        string pStartPoNum = null,
        string pEndPoNum = null,
        string pStartVendor = null,
        string pEndVendor = null,
        DateTime? pStartOrderDate = null,
        DateTime? pEndOrderDate = null,
        string pStartVendOrder = null,
        string pEndVendOrder = null,
        string pStartItem = null,
        string pEndItem = null,
        string pStartVendItem = null,
        string pEndVendItem = null,
        DateTime? pStartDueDate = null,
        DateTime? pEndDueDate = null,
        DateTime? pStartRecvDate = null,
        DateTime? pEndRecvDate = null,
        DateTime? pStartRelDate = null,
        DateTime? pEndRelDate = null,
        string pStartWhse = null,
        string pEndWhse = null,
        int? pStartOrderDateOffset = null,
        int? pEndOrderDateOffset = null,
        int? pStartDueDateOffset = null,
        int? pEndDueDateOffset = null,
        int? pStartRecvDateOffset = null,
        int? pEndRecvDateOffset = null,
        int? pStartRelDateOffset = null,
        int? pEndRelDateOffset = null,
        int? PrintCost = 0,
        int? DisplayHeader = null,
        string BGSessionId = null,
        int? TaskId = null,
        string pSite = null);
    }
}