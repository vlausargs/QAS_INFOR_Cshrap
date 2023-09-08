//PROJECT NAME: Data
//CLASS NAME: Taskchng.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Taskchng : ITaskchng
	{
		readonly IApplicationDB appDB;
		
		public Taskchng(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) TaskchngSp(
			string ProjNum,
			string ProjTaskStatus,
			string NewStatus,
			int? ProjTaskNum,
			string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			ProjStatusType _ProjTaskStatus = ProjTaskStatus;
			ProjStatusType _NewStatus = NewStatus;
			TaskNumType _ProjTaskNum = ProjTaskNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaskchngSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjTaskStatus", _ProjTaskStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewStatus", _NewStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjTaskNum", _ProjTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
