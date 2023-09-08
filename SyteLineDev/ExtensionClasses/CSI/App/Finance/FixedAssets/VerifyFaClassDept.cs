//PROJECT NAME: CSIFinance
//CLASS NAME: VerifyFaClassDept.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public interface IVerifyFaClassDept
    {
        int VerifyFaClassDeptSp(FaClassType PFaClass,
                                DeptType PDept,
                                ref InfobarType Infobar);
    }

    public class VerifyFaClassDept : IVerifyFaClassDept
    {
        readonly IApplicationDB appDB;

        public VerifyFaClassDept(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int VerifyFaClassDeptSp(FaClassType PFaClass,
                                       DeptType PDept,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VerifyFaClassDeptSp";

                appDB.AddCommandParameter(cmd, "PFaClass", PFaClass, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDept", PDept, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

