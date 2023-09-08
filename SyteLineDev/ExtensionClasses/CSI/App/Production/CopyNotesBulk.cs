//PROJECT NAME: Production
//CLASS NAME: CopyNotesBulk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CopyNotesBulk : ICopyNotesBulk
	{
		readonly IApplicationDB appDB;
		
		public CopyNotesBulk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CopyNotesBulkSp(
			string FromObject,
			string ToObject)
		{
			StringType _FromObject = FromObject;
			StringType _ToObject = ToObject;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyNotesBulkSp";
				
				appDB.AddCommandParameter(cmd, "FromObject", _FromObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToObject", _ToObject, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
