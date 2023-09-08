//PROJECT NAME: Data
//CLASS NAME: SFadisp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SFadisp : ISFadisp
	{
		readonly IApplicationDB appDB;
		
		public SFadisp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SFadispSp(
			string FadispFaNum,
			decimal? FadispDisposeAmt,
			decimal? FadispGainLoss,
			string Infobar)
		{
			FaNumType _FadispFaNum = FadispFaNum;
			AmountType _FadispDisposeAmt = FadispDisposeAmt;
			AmountType _FadispGainLoss = FadispGainLoss;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SFadispSp";
				
				appDB.AddCommandParameter(cmd, "FadispFaNum", _FadispFaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FadispDisposeAmt", _FadispDisposeAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FadispGainLoss", _FadispGainLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
