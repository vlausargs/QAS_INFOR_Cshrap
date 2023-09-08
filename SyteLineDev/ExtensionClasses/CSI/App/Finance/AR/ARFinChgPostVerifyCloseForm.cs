//PROJECT NAME: CSICustomer
//CLASS NAME: ARFinChgPostVerifyCloseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IARFinChgPostVerifyCloseForm
    {
        int ARFinChgPostVerifyCloseFormSp(RowPointer PSessionID,
                                          ref Infobar Infobar);
    }

    public class ARFinChgPostVerifyCloseForm : IARFinChgPostVerifyCloseForm
    {
        readonly IApplicationDB appDB;

        public ARFinChgPostVerifyCloseForm(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ARFinChgPostVerifyCloseFormSp(RowPointer PSessionID,
                                                 ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ARFinChgPostVerifyCloseFormSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
