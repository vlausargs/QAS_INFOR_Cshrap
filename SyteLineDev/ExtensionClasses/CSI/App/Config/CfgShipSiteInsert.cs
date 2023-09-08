//PROJECT NAME: Config
//CLASS NAME: CfgShipSiteInsert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgShipSiteInsert : ICfgShipSiteInsert
	{
		readonly IApplicationDB appDB;
		
		
		public CfgShipSiteInsert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CfgShipSiteInsertSp(string co_num,
		string co_line,
		string config_type,
		string site,
		string Infobar)
		{
			StringType _co_num = co_num;
			StringType _co_line = co_line;
			StringType _config_type = config_type;
			StringType _site = site;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgShipSiteInsertSp";
				
				appDB.AddCommandParameter(cmd, "co_num", _co_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "co_line", _co_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "config_type", _config_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "site", _site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
