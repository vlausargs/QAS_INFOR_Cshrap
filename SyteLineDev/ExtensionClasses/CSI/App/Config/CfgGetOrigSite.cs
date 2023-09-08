//PROJECT NAME: Config
//CLASS NAME: CfgGetOrigSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgGetOrigSite : ICfgGetOrigSite
	{
		readonly IApplicationDB appDB;
		
		
		public CfgGetOrigSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OrigSite,
		string Infobar) CfgGetOrigSiteSp(string CoNum,
		string OrigSite,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			SiteType _OrigSite = OrigSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgGetOrigSiteSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigSite", _OrigSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OrigSite = _OrigSite;
				Infobar = _Infobar;
				
				return (Severity, OrigSite, Infobar);
			}
		}
	}
}
