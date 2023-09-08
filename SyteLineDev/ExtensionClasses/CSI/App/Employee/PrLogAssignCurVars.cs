//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogAssignCurVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrLogAssignCurVars
    {
        int PrLogAssignCurVarsSp(ref EmpNumType EmpNum,
                                 ref DateType CurStart,
                                 ref DateType CurEnd,
                                 ref DateType CurDate,
                                 ref EmpNumType CurEmpNum,
                                 ref EmpNameType CurEmpName,
                                 ref PrLogSeqType CurEmpSeq,
                                 ref ShiftType CurShift,
                                 ref InfobarType Infobar);
    }

    public class PrLogAssignCurVars : IPrLogAssignCurVars
    {
        readonly IApplicationDB appDB;

        public PrLogAssignCurVars(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrLogAssignCurVarsSp(ref EmpNumType EmpNum,
                                        ref DateType CurStart,
                                        ref DateType CurEnd,
                                        ref DateType CurDate,
                                        ref EmpNumType CurEmpNum,
                                        ref EmpNameType CurEmpName,
                                        ref PrLogSeqType CurEmpSeq,
                                        ref ShiftType CurShift,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrLogAssignCurVarsSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurStart", CurStart, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurEnd", CurEnd, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurDate", CurDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurEmpNum", CurEmpNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurEmpName", CurEmpName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurEmpSeq", CurEmpSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurShift", CurShift, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
