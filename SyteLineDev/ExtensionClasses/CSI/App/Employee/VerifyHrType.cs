//PROJECT NAME: CSIEmployee
//CLASS NAME: VerifyHrType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IVerifyHrType
    {
        int VerifyHrTypeSp(EmpNumType pEmpNum,
                           PrhrsHrTypeType pHrType);
    }

    public class VerifyHrType : IVerifyHrType
    {
        readonly IApplicationDB appDB;

        public VerifyHrType(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int VerifyHrTypeSp(EmpNumType pEmpNum,
                                  PrhrsHrTypeType pHrType)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VerifyHrTypeSp";

                appDB.AddCommandParameter(cmd, "pEmpNum", pEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pHrType", pHrType, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
