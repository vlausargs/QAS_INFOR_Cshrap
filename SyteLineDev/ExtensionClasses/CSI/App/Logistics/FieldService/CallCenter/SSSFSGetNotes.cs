//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSGetNotes
	{
		(int? ReturnCode, string ReturnNotes) SSSFSGetNotesSp(string RowPointer,
		string ReturnNotes,
		byte? InternalOnly = (byte)0,
		byte? ExternalOnly = (byte)0);

		string SSSFSGetNotesFn(
			Guid? RowPointer);
	}
	
	public class SSSFSGetNotes : ISSSFSGetNotes
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ReturnNotes) SSSFSGetNotesSp(string RowPointer,
		string ReturnNotes,
		byte? InternalOnly = (byte)0,
		byte? ExternalOnly = (byte)0)
		{
			StringType _RowPointer = RowPointer;
			LongListType _ReturnNotes = ReturnNotes;
			ListYesNoType _InternalOnly = InternalOnly;
			ListYesNoType _ExternalOnly = ExternalOnly;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetNotesSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnNotes", _ReturnNotes, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InternalOnly", _InternalOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExternalOnly", _ExternalOnly, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReturnNotes = _ReturnNotes;
				
				return (Severity, ReturnNotes);
			}
		}

		public string SSSFSGetNotesFn(
			Guid? RowPointer)
		{
			RowPointerType _RowPointer = RowPointer;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetNotes](@RowPointer)";

				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
