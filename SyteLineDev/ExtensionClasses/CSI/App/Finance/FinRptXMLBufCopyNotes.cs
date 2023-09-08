//PROJECT NAME: Finance
//CLASS NAME: FinRptXMLBufCopyNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptXMLBufCopyNotes : IFinRptXMLBufCopyNotes
	{
		readonly IApplicationDB appDB;
		
		public FinRptXMLBufCopyNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FinRptXMLBufCopyNotesSp(
			string FromSite,
			string TableName,
			Guid? FromRowPointer,
			Guid? ToRowPointer,
			string Infobar)
		{
			SiteType _FromSite = FromSite;
			StringType _TableName = TableName;
			RowPointerType _FromRowPointer = FromRowPointer;
			RowPointerType _ToRowPointer = ToRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptXMLBufCopyNotesSp";
				
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRowPointer", _FromRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRowPointer", _ToRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
