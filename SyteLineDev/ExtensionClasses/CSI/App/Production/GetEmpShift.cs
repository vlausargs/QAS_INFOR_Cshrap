//PROJECT NAME: CSIProduct
//CLASS NAME: GetEmpShift.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IGetEmpShift
    {
        int GetEmpShiftSp(EmpNumType pEmpNum,
                          ref ShiftType pShift);
    }

    public class GetEmpShift : IGetEmpShift
    {
        readonly IApplicationDB appDB;

        public GetEmpShift(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetEmpShiftSp(EmpNumType pEmpNum,
                                 ref ShiftType pShift)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEmpShiftSp";

                appDB.AddCommandParameter(cmd, "pEmpNum", pEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pShift", pShift, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
