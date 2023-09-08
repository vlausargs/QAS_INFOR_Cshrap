//PROJECT NAME: Employee
//CLASS NAME: SaveTaskforFutureProcesses.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface ISaveTaskforFutureProcesses
	{
		(int? ReturnCode, string Infobar) SaveTaskforFutureProcessesSp(string Type,
		string Name,
		string Descr,
		short? DateOffset,
		string FormName,
		string EventName,
		string Infobar);
	}
	
	public class SaveTaskforFutureProcesses : ISaveTaskforFutureProcesses
	{
		readonly IApplicationDB appDB;
		
		public SaveTaskforFutureProcesses(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SaveTaskforFutureProcessesSp(string Type,
		string Name,
		string Descr,
		short? DateOffset,
		string FormName,
		string EventName,
		string Infobar)
		{
			ProcessManagerTaskTypeType _Type = Type;
			ProcessManagerTaskNameType _Name = Name;
			ProcessManagerTaskDescriptionType _Descr = Descr;
			DateOffsetType _DateOffset = DateOffset;
			FormNameType _FormName = FormName;
			EventNameType _EventName = EventName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SaveTaskforFutureProcessesSp";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Descr", _Descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateOffset", _DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormName", _FormName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EventName", _EventName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
