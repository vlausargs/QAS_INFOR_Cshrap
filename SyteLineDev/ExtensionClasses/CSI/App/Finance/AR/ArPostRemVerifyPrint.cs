//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRemVerifyPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArPostRemVerifyPrint
    {
        int ArPostRemVerifyPrintSp(ref RowPointer PSessionID,
                                   ref Infobar Infobar);
    }

    public class ArPostRemVerifyPrint : IArPostRemVerifyPrint
    {
        readonly IApplicationDB appDB;

        public ArPostRemVerifyPrint(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArPostRemVerifyPrintSp(ref RowPointer PSessionID,
                                          ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArPostRemVerifyPrintSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
