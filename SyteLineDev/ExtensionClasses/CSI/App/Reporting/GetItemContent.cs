//PROJECT NAME: Reporting
//CLASS NAME: GetItemContent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
    public class GetItemContent : IGetItemContent
    {
        IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public GetItemContent(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) GetItemContentSp(string Item = null,
        string RefType = null,
        string RefNum = null,
        int? RefLine = 0,
        int? RefRelease = 0,
        string InvNum = null,
        int? InvLine = null,
        int? InvSeq = null,
        DateTime? TransDate = null)
        {
            ItemType _Item = Item;
            RefTypeCEIOPRVType _RefType = RefType;
            EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
            CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLine = RefLine;
            CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
            InvNumType _InvNum = InvNum;
            InvLineType _InvLine = InvLine;
            InvSeqType _InvSeq = InvSeq;
            DateTimeType _TransDate = TransDate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetItemContentSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvLine", _InvLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}
