//PROJECT NAME: CSICustomer
//CLASS NAME: ArinvdDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArinvdDefault
    {
        int ArinvdDefaultSp(CustNumType CustNum,
                            InvNumType InvNum,
                            ArInvSeqType InvSeq,
                            ref DateType InvDate,
                            ref DateType DueDate,
                            ref CoNumType CoNum,
                            ref ListYesNoType PostedFromCo,
                            ref DoNumType DoNum,
                            ref TermsCodeType TermsCode,
                            ref TaxCodeType TaxCode1,
                            ref TaxCodeType TaxCode2,
                            ref CurrCodeType CurrCode,
                            ref ExchRateType ExchRate,
                            ref ListYesNoType FixedRate,
                            ref ListYesNoType UseExchRate,
                            ref AmountType Amount,
                            ref AmountType Freight,
                            ref AmountType MiscCharges,
                            ref AmountType SalesTax,
                            ref AmountType SalesTax2,
                            ref AmountType TotalInvAmt,
                            ref AmountType TotalDist,
                            ref AmountType TotalRem,
                            ref RowPointer arinvRowPointer,
                            ref InvNumType ApplyToInvNum,
                            ref InvNumType CNVATInvNum,
                            ref AmountType CNVATSalesTax,
                            ref CNVATStatusType CNVATStatus,
                            ref Infobar Infobar);
    }

    public class ArinvdDefault : IArinvdDefault
    {
        readonly IApplicationDB appDB;

        public ArinvdDefault(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArinvdDefaultSp(CustNumType CustNum,
                                   InvNumType InvNum,
                                   ArInvSeqType InvSeq,
                                   ref DateType InvDate,
                                   ref DateType DueDate,
                                   ref CoNumType CoNum,
                                   ref ListYesNoType PostedFromCo,
                                   ref DoNumType DoNum,
                                   ref TermsCodeType TermsCode,
                                   ref TaxCodeType TaxCode1,
                                   ref TaxCodeType TaxCode2,
                                   ref CurrCodeType CurrCode,
                                   ref ExchRateType ExchRate,
                                   ref ListYesNoType FixedRate,
                                   ref ListYesNoType UseExchRate,
                                   ref AmountType Amount,
                                   ref AmountType Freight,
                                   ref AmountType MiscCharges,
                                   ref AmountType SalesTax,
                                   ref AmountType SalesTax2,
                                   ref AmountType TotalInvAmt,
                                   ref AmountType TotalDist,
                                   ref AmountType TotalRem,
                                   ref RowPointer arinvRowPointer,
                                   ref InvNumType ApplyToInvNum,
                                   ref InvNumType CNVATInvNum,
                                   ref AmountType CNVATSalesTax,
                                   ref CNVATStatusType CNVATStatus,
                                   ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArinvdDefaultSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNum", InvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvSeq", InvSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvDate", InvDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DueDate", DueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PostedFromCo", PostedFromCo, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DoNum", DoNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TermsCode", TermsCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1", TaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2", TaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCode", CurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExchRate", ExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FixedRate", FixedRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseExchRate", UseExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Amount", Amount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Freight", Freight, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MiscCharges", MiscCharges, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SalesTax", SalesTax, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SalesTax2", SalesTax2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TotalInvAmt", TotalInvAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TotalDist", TotalDist, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TotalRem", TotalRem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "arinvRowPointer", arinvRowPointer, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ApplyToInvNum", ApplyToInvNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CNVATInvNum", CNVATInvNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CNVATSalesTax", CNVATSalesTax, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CNVATStatus", CNVATStatus, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
