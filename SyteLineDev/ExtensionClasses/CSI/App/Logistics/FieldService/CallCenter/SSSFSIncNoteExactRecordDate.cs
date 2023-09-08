//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncNoteExactRecordDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSIncNoteExactRecordDate : ISSSFSIncNoteExactRecordDate
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSIncNoteExactRecordDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ExactRecordDate) SSSFSIncNoteExactRecordDateSp(decimal? SpecificNoteToken,
		string ExactRecordDate)
		{
			TokenType _SpecificNoteToken = SpecificNoteToken;
			InfobarType _ExactRecordDate = ExactRecordDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncNoteExactRecordDateSp";
				
				appDB.AddCommandParameter(cmd, "SpecificNoteToken", _SpecificNoteToken, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExactRecordDate", _ExactRecordDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExactRecordDate = _ExactRecordDate;
				
				return (Severity, ExactRecordDate);
			}
		}
	}
}
