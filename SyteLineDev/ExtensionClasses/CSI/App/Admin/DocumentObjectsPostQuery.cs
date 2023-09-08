//PROJECT NAME: Admin
//CLASS NAME: DocumentObjectsPostQuery.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class DocumentObjectsPostQuery : IDocumentObjectsPostQuery
	{
		IApplicationDB appDB;
		
		
		public DocumentObjectsPostQuery(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Revision,
		string Status,
		DateTime? EffectiveStartDate,
		DateTime? EffectiveEndDate,
		int? IsExternal) DocumentObjectsPostQuerySp(Guid? DocumentObjectRowPointer,
		string Revision,
		string Status,
		DateTime? EffectiveStartDate,
		DateTime? EffectiveEndDate,
		int? IsExternal)
		{
			RowPointerType _DocumentObjectRowPointer = DocumentObjectRowPointer;
			RevisionType _Revision = Revision;
			DocumentStatusType _Status = Status;
			DateTimeType _EffectiveStartDate = EffectiveStartDate;
			DateTimeType _EffectiveEndDate = EffectiveEndDate;
			ListYesNoType _IsExternal = IsExternal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DocumentObjectsPostQuerySp";
				
				appDB.AddCommandParameter(cmd, "DocumentObjectRowPointer", _DocumentObjectRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EffectiveStartDate", _EffectiveStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EffectiveEndDate", _EffectiveEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsExternal", _IsExternal, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Revision = _Revision;
				Status = _Status;
				EffectiveStartDate = _EffectiveStartDate;
				EffectiveEndDate = _EffectiveEndDate;
				IsExternal = _IsExternal;
				
				return (Severity, Revision, Status, EffectiveStartDate, EffectiveEndDate, IsExternal);
			}
		}
	}
}
