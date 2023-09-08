//PROJECT NAME: Logistics
//CLASS NAME: AppmtLeaveVendAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtLeaveVendAmt : IAppmtLeaveVendAmt
	{
		readonly IApplicationDB appDB;
		
		
		public AppmtLeaveVendAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PDomCheckAmt,
		decimal? PExchRate,
		decimal? PDomApplied,
		decimal? PForApplied,
		decimal? PDomRemaining,
		decimal? PForRemaining,
		string Infobar) AppmtLeaveVendAmtSp(string PVendCurrCode = null,
		string PDomCurrCode = null,
		decimal? PDomCheckAmt = null,
		DateTime? PRecptDate = null,
		int? PCheckSeq = null,
		string PBankCode = null,
		string PVendNum = null,
		decimal? PExchRate = null,
		decimal? PForCheckAmt = null,
		decimal? PDomApplied = null,
		decimal? PForApplied = null,
		decimal? PPayApplied = 0,
		decimal? PDomRemaining = null,
		decimal? PForRemaining = null,
		string Infobar = null,
		int? PPayLeave = 0)
		{
			CurrCodeType _PVendCurrCode = PVendCurrCode;
			CurrCodeType _PDomCurrCode = PDomCurrCode;
			AmountType _PDomCheckAmt = PDomCheckAmt;
			DateType _PRecptDate = PRecptDate;
			ApCheckSeqType _PCheckSeq = PCheckSeq;
			BankCodeType _PBankCode = PBankCode;
			VendNumType _PVendNum = PVendNum;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PForCheckAmt = PForCheckAmt;
			AmountType _PDomApplied = PDomApplied;
			AmountType _PForApplied = PForApplied;
			AmountType _PPayApplied = PPayApplied;
			AmountType _PDomRemaining = PDomRemaining;
			AmountType _PForRemaining = PForRemaining;
			InfobarType _Infobar = Infobar;
			FlagNyType _PPayLeave = PPayLeave;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtLeaveVendAmtSp";
				
				appDB.AddCommandParameter(cmd, "PVendCurrCode", _PVendCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCurrCode", _PDomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCheckAmt", _PDomCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForCheckAmt", _PForCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomApplied", _PDomApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForApplied", _PForApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayApplied", _PPayApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomRemaining", _PDomRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForRemaining", _PForRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayLeave", _PPayLeave, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDomCheckAmt = _PDomCheckAmt;
				PExchRate = _PExchRate;
				PDomApplied = _PDomApplied;
				PForApplied = _PForApplied;
				PDomRemaining = _PDomRemaining;
				PForRemaining = _PForRemaining;
				Infobar = _Infobar;
				
				return (Severity, PDomCheckAmt, PExchRate, PDomApplied, PForApplied, PDomRemaining, PForRemaining, Infobar);
			}
		}
	}
}
