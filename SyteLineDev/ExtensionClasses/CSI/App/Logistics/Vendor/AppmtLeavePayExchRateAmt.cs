//PROJECT NAME: Logistics
//CLASS NAME: AppmtLeavePayExchRateAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtLeavePayExchRateAmt : IAppmtLeavePayExchRateAmt
	{
		readonly IApplicationDB appDB;
		
		
		public AppmtLeavePayExchRateAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PToCheckAmt,
		decimal? PExchRate,
		decimal? PToApplied,
		decimal? PFromApplied,
		decimal? PToRemaining,
		decimal? PFromRemaining,
		string Infobar) AppmtLeavePayExchRateAmtSp(string PFromCurrCode,
		string PToCurrCode,
		string PBanCurrCode,
		decimal? PToCheckAmt,
		DateTime? PRecptDate,
		int? PCheckSeq,
		string PBankCode,
		string PVendtNum,
		string PType,
		string PCreditMemoNum,
		decimal? PExchRate,
		decimal? PFromCheckAmt,
		decimal? PToApplied,
		decimal? PFromApplied,
		decimal? PToRemaining,
		decimal? PFromRemaining,
		string Infobar)
		{
			CurrCodeType _PFromCurrCode = PFromCurrCode;
			CurrCodeType _PToCurrCode = PToCurrCode;
			CurrCodeType _PBanCurrCode = PBanCurrCode;
			AmountType _PToCheckAmt = PToCheckAmt;
			DateType _PRecptDate = PRecptDate;
			ArCheckNumType _PCheckSeq = PCheckSeq;
			BankCodeType _PBankCode = PBankCode;
			VendNumType _PVendtNum = PVendtNum;
			ArpmtTypeType _PType = PType;
			InvNumType _PCreditMemoNum = PCreditMemoNum;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PFromCheckAmt = PFromCheckAmt;
			AmountType _PToApplied = PToApplied;
			AmountType _PFromApplied = PFromApplied;
			AmountType _PToRemaining = PToRemaining;
			AmountType _PFromRemaining = PFromRemaining;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtLeavePayExchRateAmtSp";
				
				appDB.AddCommandParameter(cmd, "PFromCurrCode", _PFromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCurrCode", _PToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBanCurrCode", _PBanCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCheckAmt", _PToCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendtNum", _PVendtNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreditMemoNum", _PCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFromCheckAmt", _PFromCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToApplied", _PToApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFromApplied", _PFromApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PToRemaining", _PToRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFromRemaining", _PFromRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PToCheckAmt = _PToCheckAmt;
				PExchRate = _PExchRate;
				PToApplied = _PToApplied;
				PFromApplied = _PFromApplied;
				PToRemaining = _PToRemaining;
				PFromRemaining = _PFromRemaining;
				Infobar = _Infobar;
				
				return (Severity, PToCheckAmt, PExchRate, PToApplied, PFromApplied, PToRemaining, PFromRemaining, Infobar);
			}
		}
	}
}
