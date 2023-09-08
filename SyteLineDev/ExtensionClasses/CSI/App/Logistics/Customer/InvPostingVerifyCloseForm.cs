//PROJECT NAME: CSICustomer
//CLASS NAME: InvPostingVerifyCloseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IInvPostingVerifyCloseForm
    {
        int InvPostingVerifyCloseFormSp(RowPointer PSessionID,
                                        ref Infobar Infobar);
    }

    public class InvPostingVerifyCloseForm : IInvPostingVerifyCloseForm
    {
        readonly IApplicationDB appDB;

        public InvPostingVerifyCloseForm(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int InvPostingVerifyCloseFormSp(RowPointer PSessionID,
                                               ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InvPostingVerifyCloseFormSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
