//PROJECT NAME: CSIFinance
//CLASS NAME: MultIFSBGlCmprPDoProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultIFSBGlCmprPDoProcess
    {
        int MultIFSBGlCmprPDoProcessSp(GuidType ProcessId,
                                       LongListType PCompressBy,
                                       LongListType PCompressionLevel,
                                       ref FlagNyType RACompressed,
                                       ref InfobarType Infobar);
    }

    public class MultIFSBGlCmprPDoProcess : IMultIFSBGlCmprPDoProcess
    {
        readonly IApplicationDB appDB;

        public MultIFSBGlCmprPDoProcess(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultIFSBGlCmprPDoProcessSp(GuidType ProcessId,
                                              LongListType PCompressBy,
                                              LongListType PCompressionLevel,
                                              ref FlagNyType RACompressed,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultIFSBGlCmprPDoProcessSp";

                appDB.AddCommandParameter(cmd, "ProcessId", ProcessId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCompressBy", PCompressBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCompressionLevel", PCompressionLevel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RACompressed", RACompressed, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}