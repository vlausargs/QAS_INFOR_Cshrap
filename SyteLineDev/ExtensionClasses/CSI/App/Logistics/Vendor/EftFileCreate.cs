//PROJECT NAME: Logistics
//CLASS NAME: EftFileCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class EftFileCreate : IEftFileCreate
	{
		readonly IApplicationDB appDB;
		
		
		public EftFileCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? GUID,
		string Infobar) EftFileCreateSp(string EFTFile,
		string NoteDesc,
		byte[] NoteContentFile,
		int? Status,
		Guid? GUID,
		string Infobar)
		{
			EFTFileType _EFTFile = EFTFile;
			LongDescType _NoteDesc = NoteDesc;
			DocumentObjectType _NoteContentFile = NoteContentFile;
			JP_EFTFileStatusType _Status = Status;
			RowPointerType _GUID = GUID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EftFileCreateSp";
				
				appDB.AddCommandParameter(cmd, "EFTFile", _EFTFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteDesc", _NoteDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteContentFile", _NoteContentFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GUID", _GUID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				GUID = _GUID;
				Infobar = _Infobar;
				
				return (Severity, GUID, Infobar);
			}
		}
	}
}
