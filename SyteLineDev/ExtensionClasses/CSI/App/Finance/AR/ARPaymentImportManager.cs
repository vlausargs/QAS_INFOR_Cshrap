//PROJECT NAME: Finance
//CLASS NAME: ARPaymentImportManager.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARPaymentImportManager : IARPaymentImportManager
	{
		readonly IApplicationDB appDB;
		
		public ARPaymentImportManager(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ARPaymentImportManagerSp(
			string MapId,
			string FilePath,
			string Filenames,
			int? TaskId,
			string Infobar)
		{
			CoNumType _MapId = MapId;
			OSLocationType _FilePath = FilePath;
			OSResourceNameType _Filenames = Filenames;
			TaskNumType _TaskId = TaskId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPaymentImportManagerSp";
				
				appDB.AddCommandParameter(cmd, "MapId", _MapId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilePath", _FilePath, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Filenames", _Filenames, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
