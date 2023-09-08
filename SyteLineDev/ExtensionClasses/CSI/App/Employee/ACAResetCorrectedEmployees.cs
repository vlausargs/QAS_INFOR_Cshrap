//PROJECT NAME: CSIEmployee
//CLASS NAME: ACAResetCorrectedEmployees.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IACAResetCorrectedEmployees
    {
        int ACAResetCorrectedEmployeesSp(ref string Infobar);
    }

    public class ACAResetCorrectedEmployees : IACAResetCorrectedEmployees
    {
        readonly IApplicationDB appDB;

        public ACAResetCorrectedEmployees(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ACAResetCorrectedEmployeesSp(ref string Infobar)
        {
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ACAResetCorrectedEmployeesSp";

                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
