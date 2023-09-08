//PROJECT NAME: Finance
//CLASS NAME: ChkAcctAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class ChkAcctAll : IChkAcctAll
	{
		readonly IApplicationDB appDB;
		
		
		public ChkAcctAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ChkAcctAllSp(string acct,
		DateTime? date,
		string pSite,
		string Infobar)
		{
			AcctType _acct = acct;
			DateType _date = date;
			SiteType _pSite = pSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkAcctAllSp";
				
				appDB.AddCommandParameter(cmd, "acct", _acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "date", _date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
