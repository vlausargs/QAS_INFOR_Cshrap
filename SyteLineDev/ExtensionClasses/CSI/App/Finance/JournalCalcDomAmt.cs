//PROJECT NAME: Finance
//CLASS NAME: JournalCalcDomAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JournalCalcDomAmt : IJournalCalcDomAmt
	{
		readonly IApplicationDB appDB;
		
		
		public JournalCalcDomAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PDomAmtDr,
		decimal? PDomAmtCr,
		decimal? PExchRate,
		string Infobar) JournalCalcDomAmtSp(int? PRecalcFor,
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
				cmd.CommandText = "JournalCalcDomAmtSp";
				
				appDB.AddCommandParameter(cmd, "PRecalcFor", _PRecalcFor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmtDr", _PDomAmtDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomAmtCr", _PDomAmtCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmtDr", _PForAmtDr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmtCr", _PForAmtCr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDomAmtDr = _PDomAmtDr;
				PDomAmtCr = _PDomAmtCr;
				PExchRate = _PExchRate;
				Infobar = _Infobar;
				
				return (Severity, PDomAmtDr, PDomAmtCr, PExchRate, Infobar);
			}
		}
	}
}
