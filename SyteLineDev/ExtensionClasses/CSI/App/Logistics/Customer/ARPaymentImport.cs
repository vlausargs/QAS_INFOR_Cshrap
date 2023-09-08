//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentImport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARPaymentImport : IARPaymentImport
	{
		readonly IApplicationDB appDB;
		
		
		public ARPaymentImport(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ARPaymentImportSp(string MapId,
		string Filename,
		string FileContent,
		int? TaskId,
		string Infobar)
		{
			CoNumType _MapId = MapId;
			OSResourceNameType _Filename = Filename;
			VeryLongListType _FileContent = FileContent;
			TaskNumType _TaskId = TaskId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPaymentImportSp";
				
				appDB.AddCommandParameter(cmd, "MapId", _MapId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Filename", _Filename, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FileContent", _FileContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
