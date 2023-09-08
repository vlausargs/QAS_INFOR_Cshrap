//PROJECT NAME: CSIVendor
//CLASS NAME: ProfileBuilderPurchaseOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IProfileBuilderPurchaseOrder
    {
        (ICollectionLoadResponse Data, int? ReturnCode) ProfileBuilderPurchaseOrderSp(string pPoType = null,
        string pPoStat = null,
        string pPoitemStat = null,
        string pPrintItemVI = null,
        string OrigSite = null,
        string pStartPoNum = null,
        string pEndPoNum = null,
        short? pStartPoLine = null,
        short? pEndPoLine = null,
        short? pStartPoRelease = null,
        short? pEndPoRelease = null,
        DateTime? pStartDueDate = null,
        DateTime? pEndDueDate = null,
        string pStartvendor = null,
        string pEndVendor = null,
        DateTime? pStartorderDate = null,
        DateTime? pEndOrderDate = null,
        short? pStartDueDateOffset = null,
        short? pEndDueDateOffset = null,
        short? pStartOrderDateOffset = null,
        short? pEndOrderDateOffset = null,
        byte? IncludeBlnsWOReleases = (byte)0);
    }

    public class ProfileBuilderPurchaseOrder : IProfileBuilderPurchaseOrder
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public ProfileBuilderPurchaseOrder(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) ProfileBuilderPurchaseOrderSp(string pPoType = null,
        string pPoStat = null,
        string pPoitemStat = null,
        string pPrintItemVI = null,
        string OrigSite = null,
        string pStartPoNum = null,
        string pEndPoNum = null,
        short? pStartPoLine = null,
        short? pEndPoLine = null,
        short? pStartPoRelease = null,
        short? pEndPoRelease = null,
        DateTime? pStartDueDate = null,
        DateTime? pEndDueDate = null,
        string pStartvendor = null,
        string pEndVendor = null,
        DateTime? pStartorderDate = null,
        DateTime? pEndOrderDate = null,
        short? pStartDueDateOffset = null,
        short? pEndDueDateOffset = null,
        short? pStartOrderDateOffset = null,
        short? pEndOrderDateOffset = null,
        byte? IncludeBlnsWOReleases = (byte)0)
        {
            StringType _pPoType = pPoType;
            StringType _pPoStat = pPoStat;
            StringType _pPoitemStat = pPoitemStat;
            StringType _pPrintItemVI = pPrintItemVI;
            SiteType _OrigSite = OrigSite;
            BuilderPoNumType _pStartPoNum = pStartPoNum;
            BuilderPoNumType _pEndPoNum = pEndPoNum;
            PoLineType _pStartPoLine = pStartPoLine;
            PoLineType _pEndPoLine = pEndPoLine;
            PoReleaseType _pStartPoRelease = pStartPoRelease;
            PoReleaseType _pEndPoRelease = pEndPoRelease;
            DateType _pStartDueDate = pStartDueDate;
            DateType _pEndDueDate = pEndDueDate;
            VendNumType _pStartvendor = pStartvendor;
            VendNumType _pEndVendor = pEndVendor;
            DateType _pStartorderDate = pStartorderDate;
            DateType _pEndOrderDate = pEndOrderDate;
            DateOffsetType _pStartDueDateOffset = pStartDueDateOffset;
            DateOffsetType _pEndDueDateOffset = pEndDueDateOffset;
            DateOffsetType _pStartOrderDateOffset = pStartOrderDateOffset;
            DateOffsetType _pEndOrderDateOffset = pEndOrderDateOffset;
            FlagNyType _IncludeBlnsWOReleases = IncludeBlnsWOReleases;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ProfileBuilderPurchaseOrderSp";

                appDB.AddCommandParameter(cmd, "pPoType", _pPoType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pPoStat", _pPoStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pPoitemStat", _pPoitemStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pPrintItemVI", _pPrintItemVI, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrigSite", _OrigSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartPoNum", _pStartPoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndPoNum", _pEndPoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartPoLine", _pStartPoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndPoLine", _pEndPoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartPoRelease", _pStartPoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndPoRelease", _pEndPoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartDueDate", _pStartDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndDueDate", _pEndDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartvendor", _pStartvendor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndVendor", _pEndVendor, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartorderDate", _pStartorderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndOrderDate", _pEndOrderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartDueDateOffset", _pStartDueDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndDueDateOffset", _pEndDueDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pStartOrderDateOffset", _pStartOrderDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndOrderDateOffset", _pEndOrderDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncludeBlnsWOReleases", _IncludeBlnsWOReleases, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}
