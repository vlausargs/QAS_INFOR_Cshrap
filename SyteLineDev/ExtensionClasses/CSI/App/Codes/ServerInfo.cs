//PROJECT NAME: Codes
//CLASS NAME: ServerInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class ServerInfo : IServerInfo
	{
		readonly IApplicationDB appDB;
		
		
		public ServerInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SystemStatistics) ServerInfoSp(string pSite = null,
		string SystemStatistics = null)
		{
			SiteType _pSite = pSite;
			StringType _SystemStatistics = SystemStatistics;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ServerInfoSp";
				
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SystemStatistics", _SystemStatistics, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SystemStatistics = _SystemStatistics;
				
				return (Severity, SystemStatistics);
			}
		}
	}
}
