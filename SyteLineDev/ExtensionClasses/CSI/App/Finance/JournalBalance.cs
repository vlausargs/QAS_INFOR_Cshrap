//PROJECT NAME: Finance
//CLASS NAME: JournalBalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class JournalBalance : IJournalBalance
	{
		readonly IApplicationDB appDB;
		
		
		public JournalBalance(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? BalDr,
		decimal? BalCr,
		decimal? RevDr,
		decimal? RevCr,
		string Infobar) JournalBalanceSp(string JournalId,
		decimal? BalDr,
		decimal? BalCr,
		decimal? RevDr,
		decimal? RevCr,
		string GLVouchers = null,
		string Infobar = null)
		{
			JournalIdType _JournalId = JournalId;
			AmtTotType _BalDr = BalDr;
			AmtTotType _BalCr = BalCr;
			AmtTotType _RevDr = RevDr;
			AmtTotType _RevCr = RevCr;
			InvNumVoucherType _GLVouchers = GLVouchers;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JournalBalanceSp";
				
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalDr", _BalDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BalCr", _BalCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevDr", _RevDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RevCr", _RevCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GLVouchers", _GLVouchers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BalDr = _BalDr;
				BalCr = _BalCr;
				RevDr = _RevDr;
				RevCr = _RevCr;
				Infobar = _Infobar;
				
				return (Severity, BalDr, BalCr, RevDr, RevCr, Infobar);
			}
		}
	}
}
