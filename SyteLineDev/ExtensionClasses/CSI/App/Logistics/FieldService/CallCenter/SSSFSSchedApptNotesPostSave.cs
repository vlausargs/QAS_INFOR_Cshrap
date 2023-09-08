//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSSchedApptNotesPostSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSSchedApptNotesPostSave
	{
		int SSSFSSchedApptNotesPostSaveSp(byte? Response,
		                                  byte? NewAppt,
		                                  Guid? ApptRowPtr,
		                                  Guid? ApptParentRowPtr);
	}
	
	public class SSSFSSchedApptNotesPostSave : ISSSFSSchedApptNotesPostSave
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSchedApptNotesPostSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSchedApptNotesPostSaveSp(byte? Response,
		                                         byte? NewAppt,
		                                         Guid? ApptRowPtr,
		                                         Guid? ApptParentRowPtr)
		{
			ListYesNoType _Response = Response;
			ListYesNoType _NewAppt = NewAppt;
			RowPointerType _ApptRowPtr = ApptRowPtr;
			RowPointerType _ApptParentRowPtr = ApptParentRowPtr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedApptNotesPostSaveSp";
				
				appDB.AddCommandParameter(cmd, "Response", _Response, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewAppt", _NewAppt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptRowPtr", _ApptRowPtr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApptParentRowPtr", _ApptParentRowPtr, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
