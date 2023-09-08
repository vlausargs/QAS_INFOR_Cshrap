//PROJECT NAME: Codes
//CLASS NAME: JournalCalcExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class JournalCalcExchRate : IJournalCalcExchRate
	{
		readonly IApplicationDB appDB;
		
		
		public JournalCalcExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PRate,
		string Infobar) JournalCalcExchRateSp(string PCurrCode,
		decimal? PForAmt,
		decimal? PDomAmt,
		decimal? PRate,
		string Infobar)
		{
			CurrCodeType _PCurrCode = PCurrCode;
			AmountType _PForAmt = PForAmt;
			AmountType _PDomAmt = PDomAmt;
			ExchRateType _PRate = PRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalCalcExchRateSp";
				
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmt", _PForAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmt", _PDomAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRate", _PRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PRate = _PRate;
				Infobar = _Infobar;
				
				return (Severity, PRate, Infobar);
			}
		}
	}
}
