//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeaveCustAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IArpmtLeaveCustAmt
	{
		(int? ReturnCode, decimal? PDomCheckAmt, decimal? PExchRate, decimal? PEuroAmt, decimal? PDomApplied, decimal? PForApplied, decimal? PDomRemaining, decimal? PForRemaining, string Infobar) ArpmtLeaveCustAmtSp(int? PDomOfEuro,
		int? PBankOfEuro,
		int? PBankCurrtIsEuro,
		string PPaymentCurrCode,
		int? PCurPayPartOfEuro,
		int? PFixedEuro,
		string PBnkCurrCode,
		string PDomCurrCode,
		decimal? PDomCheckAmt,
		DateTime? PRecptDate,
		int? PCheckNum,
		string PBankCode,
		string PCustNum,
		string PType,
		string PCreditMemoNum,
		decimal? PExchRate,
		decimal? PPaymentCheckAmount = 0,
		decimal? PForCheckAmt = null,
		decimal? PEuroAmt = null,
		decimal? PDomApplied = null,
		decimal? PForApplied = null,
		decimal? PPayApplied = 0,
		decimal? PDomRemaining = null,
		decimal? PForRemaining = null,
		string Infobar = null);
	}
	
	public class ArpmtLeaveCustAmt : IArpmtLeaveCustAmt
	{
		readonly IApplicationDB appDB;
		
		public ArpmtLeaveCustAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PDomCheckAmt, decimal? PExchRate, decimal? PEuroAmt, decimal? PDomApplied, decimal? PForApplied, decimal? PDomRemaining, decimal? PForRemaining, string Infobar) ArpmtLeaveCustAmtSp(int? PDomOfEuro,
		int? PBankOfEuro,
		int? PBankCurrtIsEuro,
		string PPaymentCurrCode,
		int? PCurPayPartOfEuro,
		int? PFixedEuro,
		string PBnkCurrCode,
		string PDomCurrCode,
		decimal? PDomCheckAmt,
		DateTime? PRecptDate,
		int? PCheckNum,
		string PBankCode,
		string PCustNum,
		string PType,
		string PCreditMemoNum,
		decimal? PExchRate,
		decimal? PPaymentCheckAmount = 0,
		decimal? PForCheckAmt = null,
		decimal? PEuroAmt = null,
		decimal? PDomApplied = null,
		decimal? PForApplied = null,
		decimal? PPayApplied = 0,
		decimal? PDomRemaining = null,
		decimal? PForRemaining = null,
		string Infobar = null)
		{
			FlagNyType _PDomOfEuro = PDomOfEuro;
			FlagNyType _PBankOfEuro = PBankOfEuro;
			FlagNyType _PBankCurrtIsEuro = PBankCurrtIsEuro;
			BankCodeType _PPaymentCurrCode = PPaymentCurrCode;
			FlagNyType _PCurPayPartOfEuro = PCurPayPartOfEuro;
			FlagNyType _PFixedEuro = PFixedEuro;
			CurrCodeType _PBnkCurrCode = PBnkCurrCode;
			CurrCodeType _PDomCurrCode = PDomCurrCode;
			AmountType _PDomCheckAmt = PDomCheckAmt;
			DateType _PRecptDate = PRecptDate;
			ArCheckNumType _PCheckNum = PCheckNum;
			BankCodeType _PBankCode = PBankCode;
			CustNumType _PCustNum = PCustNum;
			ArpmtTypeType _PType = PType;
			InvNumType _PCreditMemoNum = PCreditMemoNum;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PPaymentCheckAmount = PPaymentCheckAmount;
			AmountType _PForCheckAmt = PForCheckAmt;
			AmountType _PEuroAmt = PEuroAmt;
			AmountType _PDomApplied = PDomApplied;
			AmountType _PForApplied = PForApplied;
			AmountType _PPayApplied = PPayApplied;
			AmountType _PDomRemaining = PDomRemaining;
			AmountType _PForRemaining = PForRemaining;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtLeaveCustAmtSp";
				
				appDB.AddCommandParameter(cmd, "PDomOfEuro", _PDomOfEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankOfEuro", _PBankOfEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCurrtIsEuro", _PBankCurrtIsEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPaymentCurrCode", _PPaymentCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurPayPartOfEuro", _PCurPayPartOfEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFixedEuro", _PFixedEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBnkCurrCode", _PBnkCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCurrCode", _PDomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCheckAmt", _PDomCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreditMemoNum", _PCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPaymentCheckAmount", _PPaymentCheckAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForCheckAmt", _PForCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEuroAmt", _PEuroAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomApplied", _PDomApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForApplied", _PForApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayApplied", _PPayApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomRemaining", _PDomRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForRemaining", _PForRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDomCheckAmt = _PDomCheckAmt;
				PExchRate = _PExchRate;
				PEuroAmt = _PEuroAmt;
				PDomApplied = _PDomApplied;
				PForApplied = _PForApplied;
				PDomRemaining = _PDomRemaining;
				PForRemaining = _PForRemaining;
				Infobar = _Infobar;
				
				return (Severity, PDomCheckAmt, PExchRate, PEuroAmt, PDomApplied, PForApplied, PDomRemaining, PForRemaining, Infobar);
			}
		}
	}
}
