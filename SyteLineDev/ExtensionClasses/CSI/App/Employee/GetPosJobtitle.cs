//PROJECT NAME: CSIEmployee
//CLASS NAME: GetPosJobtitle.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IGetPosJobtitle
    {
        int GetPosJobtitleSp(JobIdType pJobId,
                             ref JobTitleType pJobTitle);
    }

    public class GetPosJobtitle : IGetPosJobtitle
    {
        readonly IApplicationDB appDB;

        public GetPosJobtitle(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetPosJobtitleSp(JobIdType pJobId,
                                    ref JobTitleType pJobTitle)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetPosJobtitleSp";

                appDB.AddCommandParameter(cmd, "pJobId", pJobId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pJobTitle", pJobTitle, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
