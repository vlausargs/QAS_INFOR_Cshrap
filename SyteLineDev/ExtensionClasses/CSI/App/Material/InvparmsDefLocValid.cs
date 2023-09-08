//PROJECT NAME: CSIMaterial
//CLASS NAME: InvparmsDefLocValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IInvparmsDefLocValid
    {
        int InvparmsDefLocValidSp(LocType Loc,
                                  ref InfobarType Infobar);
    }

    public class InvparmsDefLocValid : IInvparmsDefLocValid
    {
        readonly IApplicationDB appDB;

        public InvparmsDefLocValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int InvparmsDefLocValidSp(LocType Loc,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InvparmsDefLocValidSp";

                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
