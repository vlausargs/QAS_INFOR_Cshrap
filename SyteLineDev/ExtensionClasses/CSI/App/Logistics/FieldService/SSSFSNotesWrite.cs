//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSNotesWrite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSNotesWrite
	{
		int SSSFSNotesWriteSp(string ObjectName,
		                      string NoteDesc,
		                      string NoteContent,
		                      Guid? RefRowPointer);
	}
	
	public class SSSFSNotesWrite : ISSSFSNotesWrite
	{
		readonly IApplicationDB appDB;
		
		public SSSFSNotesWrite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSNotesWriteSp(string ObjectName,
		                             string NoteDesc,
		                             string NoteContent,
		                             Guid? RefRowPointer)
		{
			StringType _ObjectName = ObjectName;
			StringType _NoteDesc = NoteDesc;
			NoteType _NoteContent = NoteContent;
			RowPointerType _RefRowPointer = RefRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSNotesWriteSp";
				
				appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteDesc", _NoteDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteContent", _NoteContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
