//PROJECT NAME: Logistics
//CLASS NAME: CalcARGainLoss.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CalcARGainLoss : ICalcARGainLoss
	{
		readonly IApplicationDB appDB;
		
		
		public CalcARGainLoss(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? DomGainAmt,
		string Infobar) CalcARGainLossSp(string CustNum,
		string InvNum,
		string CustCurrCode,
		decimal? Amount,
		decimal? DiscAmt,
		decimal? ExchRate,
		int? UseHistRate,
		string Site,
		int? InvSeq,
		int? CheckSeq,
		decimal? DomGainAmt,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			CurrCodeType _CustCurrCode = CustCurrCode;
			AmountType _Amount = Amount;
			AmountType _DiscAmt = DiscAmt;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _UseHistRate = UseHistRate;
			SiteType _Site = Site;
			ArInvSeqType _InvSeq = InvSeq;
			ArCheckNumType _CheckSeq = CheckSeq;
			AmountType _DomGainAmt = DomGainAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcARGainLossSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustCurrCode", _CustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscAmt", _DiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseHistRate", _UseHistRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomGainAmt", _DomGainAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DomGainAmt = _DomGainAmt;
				Infobar = _Infobar;
				
				return (Severity, DomGainAmt, Infobar);
			}
		}
	}
}
