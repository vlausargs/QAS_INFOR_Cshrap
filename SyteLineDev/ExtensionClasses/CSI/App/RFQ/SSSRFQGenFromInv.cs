//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQGenFromInv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQGenFromInv
    {
        DataTable SSSRFQGenFromInvSp(byte? Commit,
                                     string StartProductCode,
                                     string EndProductCode,
                                     string StartItem,
                                     string EndItem,
                                     string StartBuyer,
                                     string EndBuyer,
                                     string StartPlanCode,
                                     string EndPlanCode,
                                     string GenMethod,
                                     string RollupMethod,
                                     byte? PurchasePartsOnly,
                                     string QtysToPrice,
                                     string AppendRfqNum,
                                     string PSessionId);
    }

    public class SSSRFQGenFromInv : ISSSRFQGenFromInv
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SSSRFQGenFromInv(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SSSRFQGenFromInvSp(byte? Commit,
                                            string StartProductCode,
                                            string EndProductCode,
                                            string StartItem,
                                            string EndItem,
                                            string StartBuyer,
                                            string EndBuyer,
                                            string StartPlanCode,
                                            string EndPlanCode,
                                            string GenMethod,
                                            string RollupMethod,
                                            byte? PurchasePartsOnly,
                                            string QtysToPrice,
                                            string AppendRfqNum,
                                            string PSessionId)
        {
            ListYesNoType _Commit = Commit;
            ProductCodeType _StartProductCode = StartProductCode;
            ProductCodeType _EndProductCode = EndProductCode;
            ItemType _StartItem = StartItem;
            ItemType _EndItem = EndItem;
            UsernameType _StartBuyer = StartBuyer;
            UsernameType _EndBuyer = EndBuyer;
            UserCodeType _StartPlanCode = StartPlanCode;
            UserCodeType _EndPlanCode = EndPlanCode;
            StringType _GenMethod = GenMethod;
            StringType _RollupMethod = RollupMethod;
            ListYesNoType _PurchasePartsOnly = PurchasePartsOnly;
            LongListType _QtysToPrice = QtysToPrice;
            RFQNumType _AppendRfqNum = AppendRfqNum;
            StringType _PSessionId = PSessionId;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQGenFromInvSp";

                appDB.AddCommandParameter(cmd, "Commit", _Commit, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartProductCode", _StartProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndProductCode", _EndProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartBuyer", _StartBuyer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndBuyer", _EndBuyer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartPlanCode", _StartPlanCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndPlanCode", _EndPlanCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GenMethod", _GenMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RollupMethod", _RollupMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PurchasePartsOnly", _PurchasePartsOnly, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtysToPrice", _QtysToPrice, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AppendRfqNum", _AppendRfqNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
