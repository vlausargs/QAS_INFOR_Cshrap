//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSDelOtherObjNoteRecord.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSDelOtherObjNoteRecord : IEXTSSSFSDelOtherObjNoteRecord
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSDelOtherObjNoteRecord(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EXTSSSFSDelOtherObjNoteRecordSp(
			string iTable,
			decimal? iSpecificToken,
			decimal? iUserToken,
			decimal? iSystemToken,
			Guid? RefRowPointer = null)
		{
			StringType _iTable = iTable;
			TokenType _iSpecificToken = iSpecificToken;
			TokenType _iUserToken = iUserToken;
			TokenType _iSystemToken = iSystemToken;
			RowPointerType _RefRowPointer = RefRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSDelOtherObjNoteRecordSp";
				
				appDB.AddCommandParameter(cmd, "iTable", _iTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSpecificToken", _iSpecificToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUserToken", _iUserToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSystemToken", _iSystemToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
