//PROJECT NAME: Data
//CLASS NAME: DeleteReplData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DeleteReplData : IDeleteReplData
	{
		readonly IApplicationDB appDB;
		
		public DeleteReplData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DeleteReplDataSp(
			string TableName,
			Guid? SessionID)
		{
			StringType _TableName = TableName;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteReplDataSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
