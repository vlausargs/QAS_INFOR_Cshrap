//PROJECT NAME: Employee
//CLASS NAME: ValidateProcessStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class ValidateProcessStatus : IValidateProcessStatus
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateProcessStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidateProcessStatusSp(decimal? ProcessId = null,
		string CurrentProcessStat = null,
		string OriginalProcessStat = null,
		string Infobar = null)
		{
			ProcessManagerProcessIDType _ProcessId = ProcessId;
			ProcessManagerProcessStatusType _CurrentProcessStat = CurrentProcessStat;
			ProcessManagerProcessStatusType _OriginalProcessStat = OriginalProcessStat;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateProcessStatusSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentProcessStat", _CurrentProcessStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OriginalProcessStat", _OriginalProcessStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
