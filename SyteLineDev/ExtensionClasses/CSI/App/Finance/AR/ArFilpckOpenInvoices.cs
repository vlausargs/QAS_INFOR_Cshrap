//PROJECT NAME: Finance
//CLASS NAME: ArFilpckOpenInvoices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArFilpckOpenInvoices : IArFilpckOpenInvoices
	{
		readonly IApplicationDB appDB;
		
		public ArFilpckOpenInvoices(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? TInvDate,
			DateTime? TDueDate,
			decimal? TOrig,
			decimal? TDisc,
			decimal? TBal,
			string Infobar) ArFilpckOpenInvoicesSp(
			string PCurrCode,
			string PParmsAllCurrCode,
			int? PSameCurr,
			int? PDomCust,
			int? PDomOfEuro,
			string ArparmsAllDiscAcct,
			string ArparmsAllDiscAcctUnit1,
			string ArparmsAllDiscAcctUnit2,
			string ArparmsAllDiscAcctUnit3,
			string ArparmsAllDiscAcctUnit4,
			DateTime? ArpmtRecptDate,
			int? ArpmtCheckNum,
			string ArpmtType,
			string ArpmtBankCode,
			string ArpmtCustNum,
			decimal? ArpmtExchRate,
			decimal? ArpmtPaymentExchRate,
			string TransactionCurrCode,
			Guid? PArtranAllRowPointer,
			int? PFirstOfArtran,
			int? PLastOfArtran,
			string InvoiceSite,
			string BaseSite,
			DateTime? TInvDate,
			DateTime? TDueDate,
			decimal? TOrig,
			decimal? TDisc,
			decimal? TBal,
			string Infobar,
			Guid? PProcessId,
			decimal? OpenPaymentAmount = 0)
		{
			CurrCodeType _PCurrCode = PCurrCode;
			CurrCodeType _PParmsAllCurrCode = PParmsAllCurrCode;
			FlagNyType _PSameCurr = PSameCurr;
			FlagNyType _PDomCust = PDomCust;
			FlagNyType _PDomOfEuro = PDomOfEuro;
			AcctType _ArparmsAllDiscAcct = ArparmsAllDiscAcct;
			UnitCode1Type _ArparmsAllDiscAcctUnit1 = ArparmsAllDiscAcctUnit1;
			UnitCode2Type _ArparmsAllDiscAcctUnit2 = ArparmsAllDiscAcctUnit2;
			UnitCode3Type _ArparmsAllDiscAcctUnit3 = ArparmsAllDiscAcctUnit3;
			UnitCode4Type _ArparmsAllDiscAcctUnit4 = ArparmsAllDiscAcctUnit4;
			DateType _ArpmtRecptDate = ArpmtRecptDate;
			ArCheckNumType _ArpmtCheckNum = ArpmtCheckNum;
			ArpmtTypeType _ArpmtType = ArpmtType;
			BankCodeType _ArpmtBankCode = ArpmtBankCode;
			CustNumType _ArpmtCustNum = ArpmtCustNum;
			ExchRateType _ArpmtExchRate = ArpmtExchRate;
			ExchRateType _ArpmtPaymentExchRate = ArpmtPaymentExchRate;
			CurrCodeType _TransactionCurrCode = TransactionCurrCode;
			RowPointerType _PArtranAllRowPointer = PArtranAllRowPointer;
			FlagNyType _PFirstOfArtran = PFirstOfArtran;
			FlagNyType _PLastOfArtran = PLastOfArtran;
			SiteType _InvoiceSite = InvoiceSite;
			SiteType _BaseSite = BaseSite;
			DateType _TInvDate = TInvDate;
			DateType _TDueDate = TDueDate;
			AmountType _TOrig = TOrig;
			AmountType _TDisc = TDisc;
			AmountType _TBal = TBal;
			InfobarType _Infobar = Infobar;
			RowPointerType _PProcessId = PProcessId;
			AmountType _OpenPaymentAmount = OpenPaymentAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArFilpckOpenInvoicesSp";
				
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParmsAllCurrCode", _PParmsAllCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSameCurr", _PSameCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCust", _PDomCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomOfEuro", _PDomOfEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArparmsAllDiscAcct", _ArparmsAllDiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArparmsAllDiscAcctUnit1", _ArparmsAllDiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArparmsAllDiscAcctUnit2", _ArparmsAllDiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArparmsAllDiscAcctUnit3", _ArparmsAllDiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArparmsAllDiscAcctUnit4", _ArparmsAllDiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtRecptDate", _ArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCheckNum", _ArpmtCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtType", _ArpmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtBankCode", _ArpmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCustNum", _ArpmtCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtExchRate", _ArpmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtPaymentExchRate", _ArpmtPaymentExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionCurrCode", _TransactionCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArtranAllRowPointer", _PArtranAllRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFirstOfArtran", _PFirstOfArtran, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastOfArtran", _PLastOfArtran, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceSite", _InvoiceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseSite", _BaseSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvDate", _TInvDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDueDate", _TDueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TOrig", _TOrig, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDisc", _TDisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TBal", _TBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpenPaymentAmount", _OpenPaymentAmount, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TInvDate = _TInvDate;
				TDueDate = _TDueDate;
				TOrig = _TOrig;
				TDisc = _TDisc;
				TBal = _TBal;
				Infobar = _Infobar;
				
				return (Severity, TInvDate, TDueDate, TOrig, TDisc, TBal, Infobar);
			}
		}
	}
}
