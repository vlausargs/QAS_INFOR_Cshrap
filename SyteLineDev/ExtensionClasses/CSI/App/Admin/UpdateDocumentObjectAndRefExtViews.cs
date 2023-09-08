//PROJECT NAME: Admin
//CLASS NAME: UpdateDocumentObjectAndRefExtViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class UpdateDocumentObjectAndRefExtViews : IUpdateDocumentObjectAndRefExtViews
	{
		IApplicationDB appDB;
		
		
		public UpdateDocumentObjectAndRefExtViews(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? DocumentObjectRowPointer,
		string Infobar) UpdateDocumentObjectAndRefExtViewsSp(string TableName,
		Guid? TableRowPointer,
		decimal? RefSequence,
		Guid? DocumentObjectRowPointer,
		Guid? RowPointer,
		string DocumentName,
		decimal? Sequence,
		string Description,
		string DocumentType,
		string DocumentExtension,
		int? Internal,
		string Revision,
		string Status,
		DateTime? effective_start_date,
		DateTime? effective_end_date,
		int? is_external,
		byte[] DocumentObject = null,
		string Infobar = null)
		{
			TableNameType _TableName = TableName;
			RowPointerType _TableRowPointer = TableRowPointer;
			SequenceType _RefSequence = RefSequence;
			RowPointerType _DocumentObjectRowPointer = DocumentObjectRowPointer;
			RowPointerType _RowPointer = RowPointer;
			DocumentNameType _DocumentName = DocumentName;
			SequenceType _Sequence = Sequence;
			LongDescType _Description = Description;
			DocumentTypeType _DocumentType = DocumentType;
			DocumentExtensionType _DocumentExtension = DocumentExtension;
			ListYesNoType _Internal = Internal;
			RevisionType _Revision = Revision;
			DocumentStatusType _Status = Status;
			DateTimeType _effective_start_date = effective_start_date;
			DateTimeType _effective_end_date = effective_end_date;
			FlagNyType _is_external = is_external;
			DocumentObjectType _DocumentObject = DocumentObject;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateDocumentObjectAndRefExtViewsSp";
				
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableRowPointer", _TableRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefSequence", _RefSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentObjectRowPointer", _DocumentObjectRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentName", _DocumentName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentType", _DocumentType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentExtension", _DocumentExtension, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Internal", _Internal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "effective_start_date", _effective_start_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "effective_end_date", _effective_end_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "is_external", _is_external, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentObject", _DocumentObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DocumentObjectRowPointer = _DocumentObjectRowPointer;
				Infobar = _Infobar;
				
				return (Severity, DocumentObjectRowPointer, Infobar);
			}
		}
	}
}
