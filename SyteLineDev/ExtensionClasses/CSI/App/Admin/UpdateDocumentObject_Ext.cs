//PROJECT NAME: Admin
//CLASS NAME: UpdateDocumentObject_Ext.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class UpdateDocumentObject_Ext : IUpdateDocumentObject_Ext
	{
		IApplicationDB appDB;
		
		
		public UpdateDocumentObject_Ext(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateDocumentObject_ExtSp(string DocumentName,
		decimal? Sequence,
		string Description,
		string DocumentType,
		string DocumentExtension,
		int? Internal,
		Guid? DocumentObjectRowPointer,
		string Revision,
		string Status,
		DateTime? effective_start_date,
		DateTime? effective_end_date,
		int? is_external,
		string Infobar)
		{
			DocumentNameType _DocumentName = DocumentName;
			SequenceType _Sequence = Sequence;
			LongDescType _Description = Description;
			DocumentTypeType _DocumentType = DocumentType;
			DocumentExtensionType _DocumentExtension = DocumentExtension;
			ListYesNoType _Internal = Internal;
			RowPointerType _DocumentObjectRowPointer = DocumentObjectRowPointer;
			RevisionType _Revision = Revision;
			DocumentStatusType _Status = Status;
			DateTimeType _effective_start_date = effective_start_date;
			DateTimeType _effective_end_date = effective_end_date;
			FlagNyType _is_external = is_external;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateDocumentObject_ExtSp";
				
				appDB.AddCommandParameter(cmd, "DocumentName", _DocumentName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentType", _DocumentType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentExtension", _DocumentExtension, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Internal", _Internal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentObjectRowPointer", _DocumentObjectRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "effective_start_date", _effective_start_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "effective_end_date", _effective_end_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "is_external", _is_external, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
