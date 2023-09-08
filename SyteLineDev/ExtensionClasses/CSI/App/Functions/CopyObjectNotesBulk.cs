//PROJECT NAME: Data
//CLASS NAME: CopyObjectNotesBulk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopyObjectNotesBulk : ICopyObjectNotesBulk
	{
		readonly IApplicationDB appDB;
		
		public CopyObjectNotesBulk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CopyObjectNotesBulkSp(
			decimal? FromNoteHeaderToken,
			decimal? ToNoteHeaderToken)
		{
			TokenType _FromNoteHeaderToken = FromNoteHeaderToken;
			TokenType _ToNoteHeaderToken = ToNoteHeaderToken;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyObjectNotesBulkSp";
				
				appDB.AddCommandParameter(cmd, "FromNoteHeaderToken", _FromNoteHeaderToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToNoteHeaderToken", _ToNoteHeaderToken, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
