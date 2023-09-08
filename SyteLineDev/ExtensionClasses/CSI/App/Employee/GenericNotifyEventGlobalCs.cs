//PROJECT NAME: CSIEmployee
//CLASS NAME: GenericNotifyEventGlobalCs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IGenericNotifyEventGlobalCs
	{
		(int? ReturnCode, Guid? EventStateRowPointer, string Infobar) GenericNotifyEventGlobalCsSp(string EventGlobalConstant,
		Guid? ProcessTaskRowPointer = null,
		Guid? EventStateRowPointer = null,
		string Infobar = null,
		string ParmName1 = null,
		string ParmValue1 = null,
		string ParmName2 = null,
		string ParmValue2 = null,
		string ParmName3 = null,
		string ParmValue3 = null,
		string ParmName4 = null,
		string ParmValue4 = null,
		string ParmName5 = null,
		string ParmValue5 = null,
		string ParmName6 = null,
		string ParmValue6 = null,
		string ParmName7 = null,
		string ParmValue7 = null,
		string ParmName8 = null,
		string ParmValue8 = null,
		string ParmName9 = null,
		string ParmValue9 = null,
		string ParmName10 = null,
		string ParmValue10 = null,
		string ParmName11 = null,
		string ParmValue11 = null,
		string ParmName12 = null,
		string ParmValue12 = null,
		string ParmName13 = null,
		string ParmValue13 = null,
		string ParmName14 = null,
		string ParmValue14 = null,
		string ParmName15 = null,
		string ParmValue15 = null,
		string ParmName16 = null,
		string ParmValue16 = null,
		string ParmName17 = null,
		string ParmValue17 = null,
		string ParmName18 = null,
		string ParmValue18 = null,
		string ParmName19 = null,
		string ParmValue19 = null,
		string ParmName20 = null,
		string ParmValue20 = null);
	}
	
	public class GenericNotifyEventGlobalCs : IGenericNotifyEventGlobalCs
	{
		readonly IApplicationDB appDB;
		
		public GenericNotifyEventGlobalCs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? EventStateRowPointer, string Infobar) GenericNotifyEventGlobalCsSp(string EventGlobalConstant,
		Guid? ProcessTaskRowPointer = null,
		Guid? EventStateRowPointer = null,
		string Infobar = null,
		string ParmName1 = null,
		string ParmValue1 = null,
		string ParmName2 = null,
		string ParmValue2 = null,
		string ParmName3 = null,
		string ParmValue3 = null,
		string ParmName4 = null,
		string ParmValue4 = null,
		string ParmName5 = null,
		string ParmValue5 = null,
		string ParmName6 = null,
		string ParmValue6 = null,
		string ParmName7 = null,
		string ParmValue7 = null,
		string ParmName8 = null,
		string ParmValue8 = null,
		string ParmName9 = null,
		string ParmValue9 = null,
		string ParmName10 = null,
		string ParmValue10 = null,
		string ParmName11 = null,
		string ParmValue11 = null,
		string ParmName12 = null,
		string ParmValue12 = null,
		string ParmName13 = null,
		string ParmValue13 = null,
		string ParmName14 = null,
		string ParmValue14 = null,
		string ParmName15 = null,
		string ParmValue15 = null,
		string ParmName16 = null,
		string ParmValue16 = null,
		string ParmName17 = null,
		string ParmValue17 = null,
		string ParmName18 = null,
		string ParmValue18 = null,
		string ParmName19 = null,
		string ParmValue19 = null,
		string ParmName20 = null,
		string ParmValue20 = null)
		{
			EventVariableNameType _EventGlobalConstant = EventGlobalConstant;
			RowPointerType _ProcessTaskRowPointer = ProcessTaskRowPointer;
			RowPointerType _EventStateRowPointer = EventStateRowPointer;
			InfobarType _Infobar = Infobar;
			NoteType _ParmName1 = ParmName1;
			NoteType _ParmValue1 = ParmValue1;
			NoteType _ParmName2 = ParmName2;
			NoteType _ParmValue2 = ParmValue2;
			NoteType _ParmName3 = ParmName3;
			NoteType _ParmValue3 = ParmValue3;
			NoteType _ParmName4 = ParmName4;
			NoteType _ParmValue4 = ParmValue4;
			NoteType _ParmName5 = ParmName5;
			NoteType _ParmValue5 = ParmValue5;
			NoteType _ParmName6 = ParmName6;
			NoteType _ParmValue6 = ParmValue6;
			NoteType _ParmName7 = ParmName7;
			NoteType _ParmValue7 = ParmValue7;
			NoteType _ParmName8 = ParmName8;
			NoteType _ParmValue8 = ParmValue8;
			NoteType _ParmName9 = ParmName9;
			NoteType _ParmValue9 = ParmValue9;
			NoteType _ParmName10 = ParmName10;
			NoteType _ParmValue10 = ParmValue10;
			NoteType _ParmName11 = ParmName11;
			NoteType _ParmValue11 = ParmValue11;
			NoteType _ParmName12 = ParmName12;
			NoteType _ParmValue12 = ParmValue12;
			NoteType _ParmName13 = ParmName13;
			NoteType _ParmValue13 = ParmValue13;
			NoteType _ParmName14 = ParmName14;
			NoteType _ParmValue14 = ParmValue14;
			NoteType _ParmName15 = ParmName15;
			NoteType _ParmValue15 = ParmValue15;
			NoteType _ParmName16 = ParmName16;
			NoteType _ParmValue16 = ParmValue16;
			NoteType _ParmName17 = ParmName17;
			NoteType _ParmValue17 = ParmValue17;
			NoteType _ParmName18 = ParmName18;
			NoteType _ParmValue18 = ParmValue18;
			NoteType _ParmName19 = ParmName19;
			NoteType _ParmValue19 = ParmValue19;
			NoteType _ParmName20 = ParmName20;
			NoteType _ParmValue20 = ParmValue20;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenericNotifyEventGlobalCsSp";
				
				appDB.AddCommandParameter(cmd, "EventGlobalConstant", _EventGlobalConstant, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessTaskRowPointer", _ProcessTaskRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EventStateRowPointer", _EventStateRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmName1", _ParmName1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue1", _ParmValue1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName2", _ParmName2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue2", _ParmValue2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName3", _ParmName3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue3", _ParmValue3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName4", _ParmName4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue4", _ParmValue4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName5", _ParmName5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue5", _ParmValue5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName6", _ParmName6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue6", _ParmValue6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName7", _ParmName7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue7", _ParmValue7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName8", _ParmName8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue8", _ParmValue8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName9", _ParmName9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue9", _ParmValue9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName10", _ParmName10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue10", _ParmValue10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName11", _ParmName11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue11", _ParmValue11, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName12", _ParmName12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue12", _ParmValue12, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName13", _ParmName13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue13", _ParmValue13, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName14", _ParmName14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue14", _ParmValue14, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName15", _ParmName15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue15", _ParmValue15, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName16", _ParmName16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue16", _ParmValue16, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName17", _ParmName17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue17", _ParmValue17, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName18", _ParmName18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue18", _ParmValue18, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName19", _ParmName19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue19", _ParmValue19, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmName20", _ParmName20, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmValue20", _ParmValue20, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EventStateRowPointer = _EventStateRowPointer;
				Infobar = _Infobar;
				
				return (Severity, EventStateRowPointer, Infobar);
			}
		}
	}
}
