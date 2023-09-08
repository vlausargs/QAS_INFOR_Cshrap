//PROJECT NAME: CSIEmployee
//CLASS NAME: GetEmpSelfServInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IGetEmpSelfServInfo
    {
        int GetEmpSelfServInfoSp(ref EmpNumType EmpNum,
                                 ref DateType Today,
                                 ref DateType FirstDayOfCurrentYear);
    }

    public class GetEmpSelfServInfo : IGetEmpSelfServInfo
    {
        readonly IApplicationDB appDB;

        public GetEmpSelfServInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetEmpSelfServInfoSp(ref EmpNumType EmpNum,
                                        ref DateType Today,
                                        ref DateType FirstDayOfCurrentYear)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEmpSelfServInfoSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Today", Today, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FirstDayOfCurrentYear", FirstDayOfCurrentYear, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
