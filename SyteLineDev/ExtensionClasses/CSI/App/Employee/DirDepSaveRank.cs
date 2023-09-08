//PROJECT NAME: CSIEmployee
//CLASS NAME: DirDepSaveRank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IDirDepSaveRank
    {
        int DirDepSaveRankSp(EmpNumType PEmpNum,
                             ref InfobarType Infobar);
    }

    public class DirDepSaveRank : IDirDepSaveRank
    {
        readonly IApplicationDB appDB;

        public DirDepSaveRank(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DirDepSaveRankSp(EmpNumType PEmpNum,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DirDepSaveRankSp";

                appDB.AddCommandParameter(cmd, "PEmpNum", PEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
