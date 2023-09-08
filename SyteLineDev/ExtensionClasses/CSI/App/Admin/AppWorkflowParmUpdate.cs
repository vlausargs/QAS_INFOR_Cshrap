//PROJECT NAME: Admin
//CLASS NAME: AppWorkflowParmUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class AppWorkflowParmUpdate : IAppWorkflowParmUpdate
	{
		IApplicationDB appDB;
		
		
		public AppWorkflowParmUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? AppWorkflowParmUpdateSp(string Name1,
		string Value1,
		string Name2,
		string Value2,
		string Name3,
		string Value3)
		{
			EventVariableNameType _Name1 = Name1;
			EventVariableValueType _Value1 = Value1;
			EventVariableNameType _Name2 = Name2;
			EventVariableValueType _Value2 = Value2;
			EventVariableNameType _Name3 = Name3;
			EventVariableValueType _Value3 = Value3;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppWorkflowParmUpdateSp";
				
				appDB.AddCommandParameter(cmd, "Name1", _Name1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value1", _Value1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name2", _Name2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value2", _Value2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name3", _Name3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Value3", _Value3, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
