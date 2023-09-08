//PROJECT NAME: CSIVendor
//CLASS NAME: APVchPostClearTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AP
{
    public interface IAPVchPostClearTT
    {
        int APVchPostClearTTSP(RowPointer PSessionID);
    }

    public class APVchPostClearTT : IAPVchPostClearTT
    {
        readonly IApplicationDB appDB;

        public APVchPostClearTT(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int APVchPostClearTTSP(RowPointer PSessionID)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APVchPostClearTTSP";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
