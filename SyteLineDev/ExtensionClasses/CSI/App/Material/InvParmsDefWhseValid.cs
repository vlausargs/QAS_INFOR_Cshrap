//PROJECT NAME: CSIMaterial
//CLASS NAME: InvParmsDefWhseValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IInvParmsDefWhseValid
    {
        int InvParmsDefWhseValidSp(WhseType PInvParmsDefWhse,
                                   ref Infobar Infobar);
    }

    public class InvParmsDefWhseValid : IInvParmsDefWhseValid
    {
        readonly IApplicationDB appDB;

        public InvParmsDefWhseValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int InvParmsDefWhseValidSp(WhseType PInvParmsDefWhse,
                                          ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InvParmsDefWhseValidSp";

                appDB.AddCommandParameter(cmd, "PInvParmsDefWhse", PInvParmsDefWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
