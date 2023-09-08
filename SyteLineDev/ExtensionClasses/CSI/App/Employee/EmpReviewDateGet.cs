//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpReviewDateGet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IEmpReviewDateGet
    {
        int EmpReviewDateGetSp(EmpNumType EmpNum,
                               ref DateType EmpReviewDate);
    }

    public class EmpReviewDateGet : IEmpReviewDateGet
    {
        readonly IApplicationDB appDB;

        public EmpReviewDateGet(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EmpReviewDateGetSp(EmpNumType EmpNum,
                                      ref DateType EmpReviewDate)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpReviewDateGetSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpReviewDate", EmpReviewDate, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
