//PROJECT NAME: CSIMaterial
//CLASS NAME: Chglstat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IChglstat
    {
        DataTable ChglstatSp(EcnItemStatusType EcnitemFStat,
                             EcnItemStatusType EcnitemTStat,
                             EcnNumType EcnFrom,
                             EcnNumType EcnTo,
                             EcnLineType EcnFromLine,
                             EcnLineType EcnToLine,
                             FlagNyType PProcess,
                             ref InfobarType Infobar);
    }

    public class Chglstat : IChglstat
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Chglstat(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable ChglstatSp(EcnItemStatusType EcnitemFStat,
                                    EcnItemStatusType EcnitemTStat,
                                    EcnNumType EcnFrom,
                                    EcnNumType EcnTo,
                                    EcnLineType EcnFromLine,
                                    EcnLineType EcnToLine,
                                    FlagNyType PProcess,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChglstatSp";

                appDB.AddCommandParameter(cmd, "EcnitemFStat", EcnitemFStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EcnitemTStat", EcnitemTStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EcnFrom", EcnFrom, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EcnTo", EcnTo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EcnFromLine", EcnFromLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EcnToLine", EcnToLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PProcess", PProcess, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
