//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSParmsSyncIncSro.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSParmsSyncIncSro
    {
        int SSSFSParmsSyncIncSroSp(string iMode,
                                   int? iSyncIndex,
                                   ref string Infobar);
    }

    public class SSSFSParmsSyncIncSro : ISSSFSParmsSyncIncSro
    {
        readonly IApplicationDB appDB;

        public SSSFSParmsSyncIncSro(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSParmsSyncIncSroSp(string iMode,
                                          int? iSyncIndex,
                                          ref string Infobar)
        {
            StringType _iMode = iMode;
            IntType _iSyncIndex = iSyncIndex;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSParmsSyncIncSroSp";

                appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSyncIndex", _iSyncIndex, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
