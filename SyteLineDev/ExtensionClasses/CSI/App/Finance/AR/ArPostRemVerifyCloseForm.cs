//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRemVerifyCloseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArPostRemVerifyCloseForm
    {
        int ArPostRemVerifyCloseFormSp(RowPointer PSessionID,
                                       ref Infobar Infobar);
    }

    public class ArPostRemVerifyCloseForm : IArPostRemVerifyCloseForm
    {
        readonly IApplicationDB appDB;

        public ArPostRemVerifyCloseForm(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArPostRemVerifyCloseFormSp(RowPointer PSessionID,
                                              ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArPostRemVerifyCloseFormSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
