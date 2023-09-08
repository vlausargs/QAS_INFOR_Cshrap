//PROJECT NAME: CSIEmployee
//CLASS NAME: ESSHasEmployeePositionSp..cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
    public interface IESSHasEmployeePosition
    {
        (int? ReturnCode, byte? HasEmployeePosition) ESSHasEmployeePositionSp(string EmpNum = null,
        byte? HasEmployeePosition = null);
    }

    public class ESSHasEmployeePosition : IESSHasEmployeePosition
    {
        readonly IApplicationDB appDB;

        public ESSHasEmployeePosition(IApplicationDB appDB)
        {

            this.appDB = appDB;

        }

        public (int? ReturnCode, byte? HasEmployeePosition) ESSHasEmployeePositionSp(string EmpNum = null,
        byte? HasEmployeePosition = null)
        {
            EmpNumType _EmpNum = EmpNum;
            ListYesNoType _HasEmployeePosition = HasEmployeePosition;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ESSHasEmployeePositionSp";

                appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HasEmployeePosition", _HasEmployeePosition, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                HasEmployeePosition = _HasEmployeePosition;

                return (Severity, HasEmployeePosition);
            }
        }
    }
}
