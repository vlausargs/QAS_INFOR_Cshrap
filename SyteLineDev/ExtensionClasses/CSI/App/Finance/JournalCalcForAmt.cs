//PROJECT NAME: Finance
//CLASS NAME: JournalCalcForAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JournalCalcForAmt : IJournalCalcForAmt
	{
		readonly IApplicationDB appDB;
		
		
		public JournalCalcForAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PForAmtDr,
		decimal? PForAmtCr,
		decimal? PExchRate,
		string Infobar) JournalCalcForAmtSp(int? PRecalcFor,
		decimal? PDomAmtDr,
		decimal? PDomAmtCr,
		string PCurrCode,
		decimal? PForAmtDr,
		decimal? PForAmtCr,
		decimal? PExchRate,
		string Infobar)
		{
			FlagNyType _PRecalcFor = PRecalcFor;
			AmountType _PDomAmtDr = PDomAmtDr;
			AmountType _PDomAmtCr = PDomAmtCr;
			CurrCodeType _PCurrCode = PCurrCode;
			AmountType _PForAmtDr = PForAmtDr;
			AmountType _PForAmtCr = PForAmtCr;
			ExchRateType _PExchRate = PExchRate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalCalcForAmtSp";
				
				appDB.AddCommandParameter(cmd, "PRecalcFor", _PRecalcFor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmtDr", _PDomAmtDr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmtCr", _PDomAmtCr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmtDr", _PForAmtDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PForAmtCr", _PForAmtCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PForAmtDr = _PForAmtDr;
				PForAmtCr = _PForAmtCr;
				PExchRate = _PExchRate;
				Infobar = _Infobar;
				
				return (Severity, PForAmtDr, PForAmtCr, PExchRate, Infobar);
			}
		}
	}
}
