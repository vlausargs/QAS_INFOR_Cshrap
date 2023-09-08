//PROJECT NAME: CSIEmployee
//CLASS NAME: GetDefaultPayRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IGetDefaultPayRate
    {
        int GetDefaultPayRateSp(EmpNumType EmpNum,
                                PrhrsHrTypeType HrType,
                                ShiftType Shift,
                                DateType WorkDate,
                                ListYesNoType CheckPrtrx,
                                PrtrxSeqType Seq,
                                ref PayRatePreciseType PayRate,
                                ref InfobarType Infobar);
    }

    public class GetDefaultPayRate : IGetDefaultPayRate
    {
        readonly IApplicationDB appDB;

        public GetDefaultPayRate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetDefaultPayRateSp(EmpNumType EmpNum,
                                       PrhrsHrTypeType HrType,
                                       ShiftType Shift,
                                       DateType WorkDate,
                                       ListYesNoType CheckPrtrx,
                                       PrtrxSeqType Seq,
                                       ref PayRatePreciseType PayRate,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetDefaultPayRateSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HrType", HrType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Shift", Shift, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WorkDate", WorkDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CheckPrtrx", CheckPrtrx, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Seq", Seq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PayRate", PayRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
