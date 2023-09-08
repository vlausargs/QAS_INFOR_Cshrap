//PROJECT NAME: Data
//CLASS NAME: PullReplData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PullReplData : IPullReplData
	{
		readonly IApplicationDB appDB;
		
		public PullReplData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PullReplDataSp(
			string SpName,
			Guid? SessionID)
		{
			StringType _SpName = SpName;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PullReplDataSp";
				
				appDB.AddCommandParameter(cmd, "SpName", _SpName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
