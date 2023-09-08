//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSValidateVchTypeCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSValidateVchTypeCode
    {
        int CHSValidateVchTypeCodeSp(TransNatType TypeCode,
                                     ref InfobarType Infobar);
    }

    public class CHSValidateVchTypeCode : ICHSValidateVchTypeCode
    {
        readonly IApplicationDB appDB;

        public CHSValidateVchTypeCode(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSValidateVchTypeCodeSp(TransNatType TypeCode,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSValidateVchTypeCodeSp";

                appDB.AddCommandParameter(cmd, "TypeCode", TypeCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
