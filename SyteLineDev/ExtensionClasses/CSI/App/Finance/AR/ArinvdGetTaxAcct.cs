//PROJECT NAME: CSICustomer
//CLASS NAME: ArinvdGetTaxAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArinvdGetTaxAcct
    {
        int ArinvdGetTaxAcctSp(TaxSystemType TaxSystem,
                               TaxCodeType TaxCodeR,
                               TaxCodeType TaxCodeE,
                               ref AcctType TaxAcct,
                               ref UnitCode1Type TaxAcctUnit1,
                               ref UnitCode2Type TaxAcctUnit2,
                               ref UnitCode3Type TaxAcctUnit3,
                               ref UnitCode4Type TaxAcctUnit4,
                               ref UnitCodeAccessType AccessUnit1,
                               ref UnitCodeAccessType AccessUnit2,
                               ref UnitCodeAccessType AccessUnit3,
                               ref UnitCodeAccessType AccessUnit4,
                               ref Infobar Infobar,
                               ref ListYesNoType TaxAcctIsControl);
    }

    public class ArinvdGetTaxAcct : IArinvdGetTaxAcct
    {
        readonly IApplicationDB appDB;

        public ArinvdGetTaxAcct(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArinvdGetTaxAcctSp(TaxSystemType TaxSystem,
                                      TaxCodeType TaxCodeR,
                                      TaxCodeType TaxCodeE,
                                      ref AcctType TaxAcct,
                                      ref UnitCode1Type TaxAcctUnit1,
                                      ref UnitCode2Type TaxAcctUnit2,
                                      ref UnitCode3Type TaxAcctUnit3,
                                      ref UnitCode4Type TaxAcctUnit4,
                                      ref UnitCodeAccessType AccessUnit1,
                                      ref UnitCodeAccessType AccessUnit2,
                                      ref UnitCodeAccessType AccessUnit3,
                                      ref UnitCodeAccessType AccessUnit4,
                                      ref Infobar Infobar,
                                      ref ListYesNoType TaxAcctIsControl)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArinvdGetTaxAcctSp";

                appDB.AddCommandParameter(cmd, "TaxSystem", TaxSystem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCodeR", TaxCodeR, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCodeE", TaxCodeE, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxAcct", TaxAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxAcctUnit1", TaxAcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxAcctUnit2", TaxAcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxAcctUnit3", TaxAcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxAcctUnit4", TaxAcctUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit1", AccessUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit2", AccessUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit3", AccessUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit4", AccessUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxAcctIsControl", TaxAcctIsControl, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
