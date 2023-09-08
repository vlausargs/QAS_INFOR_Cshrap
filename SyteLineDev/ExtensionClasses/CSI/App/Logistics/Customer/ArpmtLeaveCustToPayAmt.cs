//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeaveCustToPayAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IArpmtLeaveCustToPayAmt
	{
		(int? ReturnCode, decimal? PToCheckAmt, decimal? PExchRate, decimal? PToApplied, decimal? PToRemaining, decimal? PFromRemaining, string Infobar) ArpmtLeaveCustToPayAmtSp(string PFromCurrCode,
		string PToCurrCode,
		string PDomCurrCode = null,
		decimal? PToCheckAmt = null,
		DateTime? PRecptDate = null,
		int? PCheckNum = null,
		string PBankCode = null,
		string PCustNum = null,
		string PType = null,
		string PCreditMemoNum = null,
		decimal? PExchRate = null,
		decimal? PFromCheckAmt = null,
		decimal? PDomCheckAmt = 0,
		decimal? PToApplied = null,
		decimal? PFromApplied = null,
		decimal? PDomApplied = 0,
		decimal? PToRemaining = null,
		decimal? PFromRemaining = null,
		string Infobar = null);
	}
	
	public class ArpmtLeaveCustToPayAmt : IArpmtLeaveCustToPayAmt
	{
		readonly IApplicationDB appDB;
		
		public ArpmtLeaveCustToPayAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PToCheckAmt, decimal? PExchRate, decimal? PToApplied, decimal? PToRemaining, decimal? PFromRemaining, string Infobar) ArpmtLeaveCustToPayAmtSp(string PFromCurrCode,
		string PToCurrCode,
		string PDomCurrCode = null,
		decimal? PToCheckAmt = null,
		DateTime? PRecptDate = null,
		int? PCheckNum = null,
		string PBankCode = null,
		string PCustNum = null,
		string PType = null,
		string PCreditMemoNum = null,
		decimal? PExchRate = null,
		decimal? PFromCheckAmt = null,
		decimal? PDomCheckAmt = 0,
		decimal? PToApplied = null,
		decimal? PFromApplied = null,
		decimal? PDomApplied = 0,
		decimal? PToRemaining = null,
		decimal? PFromRemaining = null,
		string Infobar = null)
		{
			CurrCodeType _PFromCurrCode = PFromCurrCode;
			CurrCodeType _PToCurrCode = PToCurrCode;
			CurrCodeType _PDomCurrCode = PDomCurrCode;
			AmountType _PToCheckAmt = PToCheckAmt;
			DateType _PRecptDate = PRecptDate;
			ArCheckNumType _PCheckNum = PCheckNum;
			BankCodeType _PBankCode = PBankCode;
			CustNumType _PCustNum = PCustNum;
			ArpmtTypeType _PType = PType;
			InvNumType _PCreditMemoNum = PCreditMemoNum;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PFromCheckAmt = PFromCheckAmt;
			AmountType _PDomCheckAmt = PDomCheckAmt;
			AmountType _PToApplied = PToApplied;
			AmountType _PFromApplied = PFromApplied;
			AmountType _PDomApplied = PDomApplied;
			AmountType _PToRemaining = PToRemaining;
			AmountType _PFromRemaining = PFromRemaining;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtLeaveCustToPayAmtSp";
				
				appDB.AddCommandParameter(cmd, "PFromCurrCode", _PFromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCurrCode", _PToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCurrCode", _PDomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCheckAmt", _PToCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreditMemoNum", _PCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFromCheckAmt", _PFromCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCheckAmt", _PDomCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToApplied", _PToApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFromApplied", _PFromApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomApplied", _PDomApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRemaining", _PToRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFromRemaining", _PFromRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PToCheckAmt = _PToCheckAmt;
				PExchRate = _PExchRate;
				PToApplied = _PToApplied;
				PToRemaining = _PToRemaining;
				PFromRemaining = _PFromRemaining;
				Infobar = _Infobar;
				
				return (Severity, PToCheckAmt, PExchRate, PToApplied, PToRemaining, PFromRemaining, Infobar);
			}
		}
	}
}
