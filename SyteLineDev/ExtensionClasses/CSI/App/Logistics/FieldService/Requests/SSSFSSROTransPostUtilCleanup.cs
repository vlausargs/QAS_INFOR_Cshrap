//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransPostUtilCleanup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransPostUtilCleanup
	{
		(int? ReturnCode, string InfoBar) SSSFSSROTransPostUtilCleanupSp(Guid? PSessionID = null,
		decimal? PTaskID = null,
		string InfoBar = null);
	}
	
	public class SSSFSSROTransPostUtilCleanup : ISSSFSSROTransPostUtilCleanup
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransPostUtilCleanup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) SSSFSSROTransPostUtilCleanupSp(Guid? PSessionID = null,
		decimal? PTaskID = null,
		string InfoBar = null)
		{
			RowPointerType _PSessionID = PSessionID;
			TokenType _PTaskID = PTaskID;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransPostUtilCleanupSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskID", _PTaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
