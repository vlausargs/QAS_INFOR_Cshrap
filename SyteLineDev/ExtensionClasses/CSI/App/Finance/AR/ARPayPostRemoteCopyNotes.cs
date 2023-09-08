//PROJECT NAME: Finance
//CLASS NAME: ARPayPostRemoteCopyNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARPayPostRemoteCopyNotes : IARPayPostRemoteCopyNotes
	{
		readonly IApplicationDB appDB;
		
		public ARPayPostRemoteCopyNotes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ARPayPostRemoteCopyNotesSp(
			Guid? PArpmtRowPointer,
			string PToSite,
			string PToTable,
			Guid? PToRowPointer,
			string Infobar)
		{
			RowPointerType _PArpmtRowPointer = PArpmtRowPointer;
			SiteType _PToSite = PToSite;
			StringType _PToTable = PToTable;
			RowPointerType _PToRowPointer = PToRowPointer;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPayPostRemoteCopyNotesSp";
				
				appDB.AddCommandParameter(cmd, "PArpmtRowPointer", _PArpmtRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToTable", _PToTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRowPointer", _PToRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
