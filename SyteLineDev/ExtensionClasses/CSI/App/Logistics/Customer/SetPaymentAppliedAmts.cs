//PROJECT NAME: Logistics
//CLASS NAME: SetPaymentAppliedAmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SetPaymentAppliedAmts : ISetPaymentAppliedAmts
	{
		readonly IApplicationDB appDB;
		
		
		public SetPaymentAppliedAmts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PToApplied,
		decimal? PExchRate,
		decimal? PToRemaining,
		string Infobar) SetPaymentAppliedAmtsSp(string PFromCurrCode,
		string PToCurrCode,
		decimal? PToApplied,
		DateTime? PRecptDate,
		decimal? PExchRate,
		decimal? PFromApplied,
		decimal? PToCheckAmt,
		decimal? PToRemaining,
		decimal? PDomRemaning,
		string Infobar)
		{
			CurrCodeType _PFromCurrCode = PFromCurrCode;
			CurrCodeType _PToCurrCode = PToCurrCode;
			AmountType _PToApplied = PToApplied;
			DateType _PRecptDate = PRecptDate;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PFromApplied = PFromApplied;
			AmountType _PToCheckAmt = PToCheckAmt;
			AmountType _PToRemaining = PToRemaining;
			AmountType _PDomRemaning = PDomRemaning;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetPaymentAppliedAmtsSp";
				
				appDB.AddCommandParameter(cmd, "PFromCurrCode", _PFromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCurrCode", _PToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToApplied", _PToApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFromApplied", _PFromApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToCheckAmt", _PToCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRemaining", _PToRemaining, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomRemaning", _PDomRemaning, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PToApplied = _PToApplied;
				PExchRate = _PExchRate;
				PToRemaining = _PToRemaining;
				Infobar = _Infobar;
				
				return (Severity, PToApplied, PExchRate, PToRemaining, Infobar);
			}
		}
	}
}
