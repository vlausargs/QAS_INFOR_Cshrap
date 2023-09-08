//PROJECT NAME: CSIMaterial
//CLASS NAME: RSQC_ShipUpdateCOC2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IRSQC_ShipUpdateCOC2
    {
        int RSQC_ShipUpdateCOC2Sp(CoNumType CoNum,
                                  CoLineType CoLine,
                                  CoReleaseType CoRelease,
                                  ref InfobarType Infobar);
    }

    public class RSQC_ShipUpdateCOC2 : IRSQC_ShipUpdateCOC2
    {
        readonly IApplicationDB appDB;

        public RSQC_ShipUpdateCOC2(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int RSQC_ShipUpdateCOC2Sp(CoNumType CoNum,
                                         CoLineType CoLine,
                                         CoReleaseType CoRelease,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RSQC_ShipUpdateCOC2Sp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
