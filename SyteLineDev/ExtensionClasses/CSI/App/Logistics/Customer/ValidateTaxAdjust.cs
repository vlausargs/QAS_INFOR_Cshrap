//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateTaxAdjust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IValidateTaxAdjust
    {
        int ValidateTaxAdjustSp(AmountType ForTax,
                                AmountType ForTaxVar,
                                ref Infobar InfoBar);
    }

    public class ValidateTaxAdjust : IValidateTaxAdjust
    {
        readonly IApplicationDB appDB;

        public ValidateTaxAdjust(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateTaxAdjustSp(AmountType ForTax,
                                       AmountType ForTaxVar,
                                       ref Infobar InfoBar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateTaxAdjustSp";

                appDB.AddCommandParameter(cmd, "ForTax", ForTax, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ForTaxVar", ForTaxVar, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
