﻿//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeaveDomAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArpmtLeaveDomAmt
    {
        int ArpmtLeaveDomAmtSp(FlagNyType PDomOfEuro,
                               FlagNyType PBankOfEuro,
                               FlagNyType PDomIsEuro,
                               CurrCodeType PPaymentCurrCode,
                               FlagNyType PCurPayPartOfEuro,
                               FlagNyType PFixedEuro,
                               CurrCodeType PBnkCurrCode,
                               CurrCodeType PDomCurrCode,
                               AmountType PDomCheckAmt,
                               DateType PRecptDate,
                               ArCheckNumType PCheckNum,
                               BankCodeType PBankCode,
                               CustNumType PCustNum,
                               ArpmtTypeType PType,
                               InvNumType PCreditMemoNum,
                               ref ExchRateType PExchRate,
                               ref AmountType PForCheckAmt,
                               ref AmountType PEuroAmt,
                               ref AmountType PDomApplied,
                               ref AmountType PForApplied,
                               ref AmountType PDomRemaining,
                               ref AmountType PForRemaining,
                               ref InfobarType Infobar);
    }

    public class ArpmtLeaveDomAmt : IArpmtLeaveDomAmt
    {
        readonly IApplicationDB appDB;

        public ArpmtLeaveDomAmt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArpmtLeaveDomAmtSp(FlagNyType PDomOfEuro,
                                      FlagNyType PBankOfEuro,
                                      FlagNyType PDomIsEuro,
                                      CurrCodeType PPaymentCurrCode,
                                      FlagNyType PCurPayPartOfEuro,
                                      FlagNyType PFixedEuro,
                                      CurrCodeType PBnkCurrCode,
                                      CurrCodeType PDomCurrCode,
                                      AmountType PDomCheckAmt,
                                      DateType PRecptDate,
                                      ArCheckNumType PCheckNum,
                                      BankCodeType PBankCode,
                                      CustNumType PCustNum,
                                      ArpmtTypeType PType,
                                      InvNumType PCreditMemoNum,
                                      ref ExchRateType PExchRate,
                                      ref AmountType PForCheckAmt,
                                      ref AmountType PEuroAmt,
                                      ref AmountType PDomApplied,
                                      ref AmountType PForApplied,
                                      ref AmountType PDomRemaining,
                                      ref AmountType PForRemaining,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArpmtLeaveDomAmtSp";

                appDB.AddCommandParameter(cmd, "PDomOfEuro", PDomOfEuro, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankOfEuro", PBankOfEuro, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDomIsEuro", PDomIsEuro, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPaymentCurrCode", PPaymentCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCurPayPartOfEuro", PCurPayPartOfEuro, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PFixedEuro", PFixedEuro, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBnkCurrCode", PBnkCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDomCurrCode", PDomCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDomCheckAmt", PDomCheckAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRecptDate", PRecptDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckNum", PCheckNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCode", PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PType", PType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCreditMemoNum", PCreditMemoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PExchRate", PExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForCheckAmt", PForCheckAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PEuroAmt", PEuroAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDomApplied", PDomApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForApplied", PForApplied, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDomRemaining", PDomRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PForRemaining", PForRemaining, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
