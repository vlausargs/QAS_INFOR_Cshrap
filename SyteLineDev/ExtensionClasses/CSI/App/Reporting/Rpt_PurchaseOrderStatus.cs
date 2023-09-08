//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseOrderStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
    public class Rpt_PurchaseOrderStatus : IRpt_PurchaseOrderStatus
    {
        IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public Rpt_PurchaseOrderStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseOrderStatusSp(string pPoType = null,
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
        string pSite = null)
        {
            InfobarType _pPoType = pPoType;
            InfobarType _pPoitemStat = pPoitemStat;
            InfobarType _pPoStat = pPoStat;
            InfobarType _pSortBy = pSortBy;
            ListYesNoType _pIncludeGrn = pIncludeGrn;
            ListYesNoType _pTransDomCurr = pTransDomCurr;
            PoNumType _pStartPoNum = pStartPoNum;
            PoNumType _pEndPoNum = pEndPoNum;
            VendNumType _pStartVendor = pStartVendor;
            VendNumType _pEndVendor = pEndVendor;
            GenericDateType _pStartOrderDate = pStartOrderDate;
            GenericDateType _pEndOrderDate = pEndOrderDate;
            VendOrderType _pStartVendOrder = pStartVendOrder;
            VendOrderType _pEndVendOrder = pEndVendOrder;
            ItemType _pStartItem = pStartItem;
            ItemType _pEndItem = pEndItem;
            VendItemType _pStartVendItem = pStartVendItem;
            VendItemType _pEndVendItem = pEndVendItem;
            GenericDateType _pStartDueDate = pStartDueDate;
            GenericDateType _pEndDueDate = pEndDueDate;
            GenericDateType _pStartRecvDate = pStartRecvDate;
            GenericDateType _pEndRecvDate = pEndRecvDate;
            GenericDateType _pStartRelDate = pStartRelDate;
            GenericDateType _pEndRelDate = pEndRelDate;
            WhseType _pStartWhse = pStartWhse;
            WhseType _pEndWhse = pEndWhse;
            DateOffsetType _pStartOrderDateOffset = pStartOrderDateOffset;
            DateOffsetType _pEndOrderDateOffset = pEndOrderDateOffset;
            DateOffsetType _pStartDueDateOffset = pStartDueDateOffset;
            DateOffsetType _pEndDueDateOffset = pEndDueDateOffset;
            DateOffsetType _pStartRecvDateOffset = pStartRecvDateOffset;
            DateOffsetType _pEndRecvDateOffset = pEndRecvDateOffset;
            DateOffsetType _pStartRelDateOffset = pStartRelDateOffset;
            DateOffsetType _pEndRelDateOffset = pEndRelDateOffset;
            ListYesNoType _PrintCost = PrintCost;
            ListYesNoType _DisplayHeader = DisplayHeader;
            StringType _BGSessionId = BGSessionId;
            TaskNumType _TaskId = TaskId;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Rpt_PurchaseOrderStatusSp";

                appDB.AddCommandParameter(cmd, "pPoType", _pPoType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pPoitemStat", _pPoitemStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pPoStat", _pPoStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSortBy", _pSortBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pIncludeGrn", _pIncludeGrn, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pTransDomCurr", _pTransDomCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartPoNum", _pStartPoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndPoNum", _pEndPoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartVendor", _pStartVendor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndVendor", _pEndVendor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartOrderDate", _pStartOrderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndOrderDate", _pEndOrderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartVendOrder", _pStartVendOrder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndVendOrder", _pEndVendOrder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartVendItem", _pStartVendItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndVendItem", _pEndVendItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartDueDate", _pStartDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndDueDate", _pEndDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartRecvDate", _pStartRecvDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndRecvDate", _pEndRecvDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartRelDate", _pStartRelDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndRelDate", _pEndRelDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartWhse", _pStartWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndWhse", _pEndWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartOrderDateOffset", _pStartOrderDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndOrderDateOffset", _pEndOrderDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartDueDateOffset", _pStartDueDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndDueDateOffset", _pEndDueDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartRecvDateOffset", _pStartRecvDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndRecvDateOffset", _pEndRecvDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartRelDateOffset", _pStartRelDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndRelDateOffset", _pEndRelDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}