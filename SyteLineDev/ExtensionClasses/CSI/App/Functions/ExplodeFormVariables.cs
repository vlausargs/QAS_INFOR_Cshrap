//PROJECT NAME: Data
//CLASS NAME: ExplodeFormVariables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ExplodeFormVariables : IExplodeFormVariables
	{
		readonly IApplicationDB appDB;
		
		public ExplodeFormVariables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ExplodeFormVariablesFn(
			int? FormID,
			string Text,
			int? CalledFrom)
		{
			IntType _FormID = FormID;
			StringType _Text = Text;
			IntType _CalledFrom = CalledFrom;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ExplodeFormVariables](@FormID, @Text, @CalledFrom)";
				
				appDB.AddCommandParameter(cmd, "FormID", _FormID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Text", _Text, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
