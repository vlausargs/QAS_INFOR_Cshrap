//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSSchedProfileFilterTaskGroupSaveServer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public interface ISSSFSSchedProfileFilterTaskGroupSaveServer
    {
        int SSSFSSchedProfileFilterTaskGroupSaveServerSp(StringType List,
                                                         ref Infobar InfoBar);
    }

    public class SSSFSSchedProfileFilterTaskGroupSaveServer : ISSSFSSchedProfileFilterTaskGroupSaveServer
    {
        readonly IApplicationDB appDB;

        public SSSFSSchedProfileFilterTaskGroupSaveServer(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSchedProfileFilterTaskGroupSaveServerSp(StringType List,
                                                                ref Infobar InfoBar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSchedProfileFilterTaskGroupSaveServerSp";

                appDB.AddCommandParameter(cmd, "List", List, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}