//PROJECT NAME: Finance
//CLASS NAME: ChkAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class ChkAcct : IChkAcct
	{
		readonly IApplicationDB appDB;
		
		
		public ChkAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ChkAcctSp(string acct,
		DateTime? date,
		string Infobar,
		string Site = null)
		{
			AcctType _acct = acct;
			DateType _date = date;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkAcctSp";
				
				appDB.AddCommandParameter(cmd, "acct", _acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "date", _date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
