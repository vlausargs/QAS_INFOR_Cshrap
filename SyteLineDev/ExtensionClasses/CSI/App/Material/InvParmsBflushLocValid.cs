//PROJECT NAME: CSIMaterial
//CLASS NAME: InvParmsBflushLocValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IInvParmsBflushLocValid
    {
        int InvParmsBflushLocValidSp(LocType PInvParmsBflushLoc,
                                     ref Infobar Infobar);
    }

    public class InvParmsBflushLocValid : IInvParmsBflushLocValid
    {
        readonly IApplicationDB appDB;

        public InvParmsBflushLocValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int InvParmsBflushLocValidSp(LocType PInvParmsBflushLoc,
                                            ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InvParmsBflushLocValidSp";

                appDB.AddCommandParameter(cmd, "PInvParmsBflushLoc", PInvParmsBflushLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
