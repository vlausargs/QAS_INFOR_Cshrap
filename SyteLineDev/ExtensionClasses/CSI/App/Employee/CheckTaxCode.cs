//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckTaxCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface ICheckTaxCode
    {
        int CheckTaxCodeSp(PrTaxCodeType Code,
                           StringType FromTo,
                           ref InfobarType Infobar);
    }

    public class CheckTaxCode : ICheckTaxCode
    {
        readonly IApplicationDB appDB;

        public CheckTaxCode(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckTaxCodeSp(PrTaxCodeType Code,
                                  StringType FromTo,
                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckTaxCodeSp";

                appDB.AddCommandParameter(cmd, "Code", Code, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromTo", FromTo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
