//PROJECT NAME: Data
//CLASS NAME: CounterVariable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CounterVariable : ICounterVariable
	{
		readonly IApplicationDB appDB;
		
		public CounterVariable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? VariableValue) CounterVariableSp(
			string VariableName,
			int? VariableValue,
			int? Step = 1)
		{
			StringType _VariableName = VariableName;
			IntType _VariableValue = VariableValue;
			IntType _Step = Step;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CounterVariableSp";
				
				appDB.AddCommandParameter(cmd, "VariableName", _VariableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue", _VariableValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Step", _Step, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				VariableValue = _VariableValue;
				
				return (Severity, VariableValue);
			}
		}
	}
}
