//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogUpdateOrAddDeleteCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrLogUpdateOrAddDeleteCheck
    {
        int PrLogUpdateOrAddDeleteCheckSp(LongListType Action,
                                          EmpNumType EmpNum,
                                          PrLogSeqType Seq,
                                          MatlTransNumType TransNum,
                                          DateType NewWorkDate,
                                          PrlogHrTypeType NewHrType,
                                          TotalHoursType NewHrs,
                                          PayRatePreciseType NewPayRate,
                                          AdpVersionType AdpParmInterfaceVersion,
                                          ref DeptType Dept,
                                          ref InfobarType Infobar);
    }

    public class PrLogUpdateOrAddDeleteCheck : IPrLogUpdateOrAddDeleteCheck
    {
        readonly IApplicationDB appDB;

        public PrLogUpdateOrAddDeleteCheck(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrLogUpdateOrAddDeleteCheckSp(LongListType Action,
                                                 EmpNumType EmpNum,
                                                 PrLogSeqType Seq,
                                                 MatlTransNumType TransNum,
                                                 DateType NewWorkDate,
                                                 PrlogHrTypeType NewHrType,
                                                 TotalHoursType NewHrs,
                                                 PayRatePreciseType NewPayRate,
                                                 AdpVersionType AdpParmInterfaceVersion,
                                                 ref DeptType Dept,
                                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrLogUpdateOrAddDeleteCheckSp";

                appDB.AddCommandParameter(cmd, "Action", Action, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Seq", Seq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransNum", TransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewWorkDate", NewWorkDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewHrType", NewHrType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewHrs", NewHrs, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewPayRate", NewPayRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AdpParmInterfaceVersion", AdpParmInterfaceVersion, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Dept", Dept, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
