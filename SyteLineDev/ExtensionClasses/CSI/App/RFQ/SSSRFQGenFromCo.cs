//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQGenFromCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQGenFromCo
    {
        DataTable SSSRFQGenFromCoSp(byte? Commit,
                                    string Type,
                                    string StartCoNum,
                                    string EndCoNum,
                                    short? StartLine,
                                    short? EndLine,
                                    short? StartRel,
                                    short? EndRel,
                                    string StartProductCode,
                                    string EndProductCode,
                                    string StartItem,
                                    string EndItem,
                                    string GenMethod,
                                    string RollupMethod,
                                    byte? PurchasePartsOnly,
                                    string QtysToPrice,
                                    string AppendRfqNum,
                                    string PSessionID);
    }

    public class SSSRFQGenFromCo : ISSSRFQGenFromCo
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SSSRFQGenFromCo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SSSRFQGenFromCoSp(byte? Commit,
                                           string Type,
                                           string StartCoNum,
                                           string EndCoNum,
                                           short? StartLine,
                                           short? EndLine,
                                           short? StartRel,
                                           short? EndRel,
                                           string StartProductCode,
                                           string EndProductCode,
                                           string StartItem,
                                           string EndItem,
                                           string GenMethod,
                                           string RollupMethod,
                                           byte? PurchasePartsOnly,
                                           string QtysToPrice,
                                           string AppendRfqNum,
                                           string PSessionID)
        {
            ListYesNoType _Commit = Commit;
            StringType _Type = Type;
            CoNumType _StartCoNum = StartCoNum;
            CoNumType _EndCoNum = EndCoNum;
            CoLineType _StartLine = StartLine;
            CoLineType _EndLine = EndLine;
            CoReleaseType _StartRel = StartRel;
            CoReleaseType _EndRel = EndRel;
            ProductCodeType _StartProductCode = StartProductCode;
            ProductCodeType _EndProductCode = EndProductCode;
            ItemType _StartItem = StartItem;
            ItemType _EndItem = EndItem;
            StringType _GenMethod = GenMethod;
            StringType _RollupMethod = RollupMethod;
            ListYesNoType _PurchasePartsOnly = PurchasePartsOnly;
            LongListType _QtysToPrice = QtysToPrice;
            RFQNumType _AppendRfqNum = AppendRfqNum;
            StringType _PSessionID = PSessionID;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQGenFromCoSp";

                appDB.AddCommandParameter(cmd, "Commit", _Commit, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartCoNum", _StartCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndCoNum", _EndCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartLine", _StartLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndLine", _EndLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartRel", _StartRel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndRel", _EndRel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartProductCode", _StartProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndProductCode", _EndProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GenMethod", _GenMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RollupMethod", _RollupMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PurchasePartsOnly", _PurchasePartsOnly, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtysToPrice", _QtysToPrice, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AppendRfqNum", _AppendRfqNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
