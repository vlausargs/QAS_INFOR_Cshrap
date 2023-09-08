//PROJECT NAME: CSIVendor
//CLASS NAME: APVchPostingVerifyCloseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AP
{
    public interface IAPVchPostingVerifyCloseForm
    {
        int APVchPostingVerifyCloseFormSp(RowPointer PSessionID,
                                          ref Infobar Infobar);
    }

    public class APVchPostingVerifyCloseForm : IAPVchPostingVerifyCloseForm
    {
        readonly IApplicationDB appDB;

        public APVchPostingVerifyCloseForm(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int APVchPostingVerifyCloseFormSp(RowPointer PSessionID,
                                                 ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APVchPostingVerifyCloseFormSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
