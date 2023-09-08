//PROJECT NAME: CSICustomer
//CLASS NAME: ARPayPostVerifyCloseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IARPayPostVerifyCloseForm
    {
        int ARPayPostVerifyCloseFormSp(RowPointer PSessionID,
                                       ref Infobar Infobar);
    }

    public class ARPayPostVerifyCloseForm : IARPayPostVerifyCloseForm
    {
        readonly IApplicationDB appDB;

        public ARPayPostVerifyCloseForm(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ARPayPostVerifyCloseFormSp(RowPointer PSessionID,
                                              ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ARPayPostVerifyCloseFormSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
