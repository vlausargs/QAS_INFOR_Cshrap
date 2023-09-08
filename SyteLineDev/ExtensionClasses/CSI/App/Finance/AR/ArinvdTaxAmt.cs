//PROJECT NAME: CSICustomer
//CLASS NAME: ArinvdTaxAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArinvdTaxAmt
    {
        int ArinvdTaxAmtSp(StringType Action,
                           DateType InvDate,
                           TermsCodeType TermsCode,
                           CurrCodeType CurrCode,
                           ExchRateType ExchRate,
                           ListYesNoType UseExchRate,
                           TaxSystemType TaxSystem,
                           TaxCodeType TaxCodeR,
                           TaxCodeType TaxCodeE,
                           AmountType TaxBasis,
                           AmountType DistAmount,
                           ref AmountType TaxAmount,
                           ref Infobar PromptMsg,
                           ref Infobar PromptBtns,
                           ref Infobar Infobar);
    }

    public class ArinvdTaxAmt : IArinvdTaxAmt
    {
        readonly IApplicationDB appDB;

        public ArinvdTaxAmt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArinvdTaxAmtSp(StringType Action,
                                  DateType InvDate,
                                  TermsCodeType TermsCode,
                                  CurrCodeType CurrCode,
                                  ExchRateType ExchRate,
                                  ListYesNoType UseExchRate,
                                  TaxSystemType TaxSystem,
                                  TaxCodeType TaxCodeR,
                                  TaxCodeType TaxCodeE,
                                  AmountType TaxBasis,
                                  AmountType DistAmount,
                                  ref AmountType TaxAmount,
                                  ref Infobar PromptMsg,
                                  ref Infobar PromptBtns,
                                  ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArinvdTaxAmtSp";

                appDB.AddCommandParameter(cmd, "Action", Action, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvDate", InvDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TermsCode", TermsCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrCode", CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExchRate", ExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseExchRate", UseExchRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxSystem", TaxSystem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCodeR", TaxCodeR, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxCodeE", TaxCodeE, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxBasis", TaxBasis, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DistAmount", DistAmount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxAmount", TaxAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptBtns", PromptBtns, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
