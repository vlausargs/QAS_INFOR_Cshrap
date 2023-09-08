//PROJECT NAME: CSICustomer
//CLASS NAME: InvoicesDebitAndCreditMemos.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IInvoicesDebitAndCreditMemos
    {
        int InvoicesDebitAndCreditMemosSp(CustNumType CustNum,
                                          CustSeqType CustSeq,
                                          ArinvTypeType ArinvType,
                                          DateType InvoiceDate,
                                          ref DateType DueDate,
                                          ref CustTypeType CustType,
                                          ref TermsCodeType TermsCode,
                                          ref CustPayTypeType PayType,
                                          ref TaxCodeType TaxCode1,
                                          ref TaxCodeType TaxCode2,
                                          ref CurrCodeType CurrCode,
                                          ref ExchRateType ExchRate,
                                          ref ListYesNoType CurrRateIsFixed,
                                          ref ListYesNoType UseExchRate,
                                          ref AcctType Acct,
                                          ref UnitCode1Type AcctUnit1,
                                          ref UnitCode2Type AcctUnit2,
                                          ref UnitCode3Type AcctUnit3,
                                          ref UnitCode4Type AcctUnit4,
                                          ref UnitCodeAccessType AccessUnit1,
                                          ref UnitCodeAccessType AccessUnit2,
                                          ref UnitCodeAccessType AccessUnit3,
                                          ref UnitCodeAccessType AccessUnit4,
                                          ref Infobar Infobar,
                                          ref ListYesNoType CustIncludePrice,
                                          ref ListYesNoType RevDayExist,
                                          ref ListYesNoType IsControl);
    }

    public class InvoicesDebitAndCreditMemos : IInvoicesDebitAndCreditMemos
    {
        readonly IApplicationDB appDB;

        public InvoicesDebitAndCreditMemos(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int InvoicesDebitAndCreditMemosSp(CustNumType CustNum,
                                                 CustSeqType CustSeq,
                                                 ArinvTypeType ArinvType,
                                                 DateType InvoiceDate,
                                                 ref DateType DueDate,
                                                 ref CustTypeType CustType,
                                                 ref TermsCodeType TermsCode,
                                                 ref CustPayTypeType PayType,
                                                 ref TaxCodeType TaxCode1,
                                                 ref TaxCodeType TaxCode2,
                                                 ref CurrCodeType CurrCode,
                                                 ref ExchRateType ExchRate,
                                                 ref ListYesNoType CurrRateIsFixed,
                                                 ref ListYesNoType UseExchRate,
                                                 ref AcctType Acct,
                                                 ref UnitCode1Type AcctUnit1,
                                                 ref UnitCode2Type AcctUnit2,
                                                 ref UnitCode3Type AcctUnit3,
                                                 ref UnitCode4Type AcctUnit4,
                                                 ref UnitCodeAccessType AccessUnit1,
                                                 ref UnitCodeAccessType AccessUnit2,
                                                 ref UnitCodeAccessType AccessUnit3,
                                                 ref UnitCodeAccessType AccessUnit4,
                                                 ref Infobar Infobar,
                                                 ref ListYesNoType CustIncludePrice,
                                                 ref ListYesNoType RevDayExist,
                                                 ref ListYesNoType IsControl)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InvoicesDebitAndCreditMemosSp";

                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustSeq", CustSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ArinvType", ArinvType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvoiceDate", InvoiceDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DueDate", DueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustType", CustType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TermsCode", TermsCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PayType", PayType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode1", TaxCode1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TaxCode2", TaxCode2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrCode", CurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExchRate", ExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurrRateIsFixed", CurrRateIsFixed, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseExchRate", UseExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Acct", Acct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AcctUnit1", AcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AcctUnit2", AcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AcctUnit3", AcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AcctUnit4", AcctUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit1", AccessUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit2", AccessUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit3", AccessUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AccessUnit4", AccessUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustIncludePrice", CustIncludePrice, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RevDayExist", RevDayExist, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "IsControl", IsControl, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
