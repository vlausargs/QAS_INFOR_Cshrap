//PROJECT NAME: CSIEmployee
//CLASS NAME: GetWorkUnitDescriptionForEmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IGetWorkUnitDescriptionForEmp
    {
        int GetWorkUnitDescriptionForEmpSp(EmpNumType CurEmpNum,
                                           ref DeWorkUnitDescType TUnits);
    }

    public class GetWorkUnitDescriptionForEmp : IGetWorkUnitDescriptionForEmp
    {
        readonly IApplicationDB appDB;

        public GetWorkUnitDescriptionForEmp(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetWorkUnitDescriptionForEmpSp(EmpNumType CurEmpNum,
                                                  ref DeWorkUnitDescType TUnits)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetWorkUnitDescriptionForEmpSp";

                appDB.AddCommandParameter(cmd, "CurEmpNum", CurEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TUnits", TUnits, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
