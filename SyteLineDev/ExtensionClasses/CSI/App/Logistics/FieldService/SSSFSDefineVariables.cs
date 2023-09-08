//PROJECT NAME: Logistics
//CLASS NAME: SSSFSDefineVariables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSDefineVariables
	{
		(int? ReturnCode, string Infobar) SSSFSDefineVariablesSp(string VariableName,
		string VariableValue,
		string Infobar,
		string VariableName2 = null,
		string VariableValue2 = null,
		string VariableName3 = null,
		string VariableValue3 = null,
		string VariableName4 = null,
		string VariableValue4 = null,
		string VariableName5 = null,
		string VariableValue5 = null,
		string VariableName6 = null,
		string VariableValue6 = null,
		string VariableName7 = null,
		string VariableValue7 = null,
		string VariableName8 = null,
		string VariableValue8 = null,
		string VariableName9 = null,
		string VariableValue9 = null,
		string VariableName10 = null,
		string VariableValue10 = null);
	}
	
	public class SSSFSDefineVariables : ISSSFSDefineVariables
	{
		readonly IApplicationDB appDB;
		
		public SSSFSDefineVariables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSDefineVariablesSp(string VariableName,
		string VariableValue,
		string Infobar,
		string VariableName2 = null,
		string VariableValue2 = null,
		string VariableName3 = null,
		string VariableValue3 = null,
		string VariableName4 = null,
		string VariableValue4 = null,
		string VariableName5 = null,
		string VariableValue5 = null,
		string VariableName6 = null,
		string VariableValue6 = null,
		string VariableName7 = null,
		string VariableValue7 = null,
		string VariableName8 = null,
		string VariableValue8 = null,
		string VariableName9 = null,
		string VariableValue9 = null,
		string VariableName10 = null,
		string VariableValue10 = null)
		{
			StringType _VariableName = VariableName;
			LongListType _VariableValue = VariableValue;
			InfobarType _Infobar = Infobar;
			StringType _VariableName2 = VariableName2;
			LongListType _VariableValue2 = VariableValue2;
			StringType _VariableName3 = VariableName3;
			LongListType _VariableValue3 = VariableValue3;
			StringType _VariableName4 = VariableName4;
			LongListType _VariableValue4 = VariableValue4;
			StringType _VariableName5 = VariableName5;
			LongListType _VariableValue5 = VariableValue5;
			StringType _VariableName6 = VariableName6;
			LongListType _VariableValue6 = VariableValue6;
			StringType _VariableName7 = VariableName7;
			LongListType _VariableValue7 = VariableValue7;
			StringType _VariableName8 = VariableName8;
			LongListType _VariableValue8 = VariableValue8;
			StringType _VariableName9 = VariableName9;
			LongListType _VariableValue9 = VariableValue9;
			StringType _VariableName10 = VariableName10;
			LongListType _VariableValue10 = VariableValue10;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSDefineVariablesSp";
				
				appDB.AddCommandParameter(cmd, "VariableName", _VariableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue", _VariableValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VariableName2", _VariableName2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue2", _VariableValue2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableName3", _VariableName3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue3", _VariableValue3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableName4", _VariableName4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue4", _VariableValue4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableName5", _VariableName5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue5", _VariableValue5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableName6", _VariableName6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue6", _VariableValue6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableName7", _VariableName7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue7", _VariableValue7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableName8", _VariableName8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue8", _VariableValue8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableName9", _VariableName9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue9", _VariableValue9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableName10", _VariableName10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VariableValue10", _VariableValue10, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
