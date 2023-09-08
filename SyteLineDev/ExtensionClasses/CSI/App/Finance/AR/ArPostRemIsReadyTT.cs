//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRemIsReadyTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArPostRemIsReadyTT
    {
        int ArPostRemIsReadyTTSP(RowPointer PSessionID,
                                 ref Infobar Infobar);
    }

    public class ArPostRemIsReadyTT : IArPostRemIsReadyTT
    {
        readonly IApplicationDB appDB;

        public ArPostRemIsReadyTT(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArPostRemIsReadyTTSP(RowPointer PSessionID,
                                        ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArPostRemIsReadyTTSP";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
