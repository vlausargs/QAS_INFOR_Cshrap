//PROJECT NAME: CSICodes
//CLASS NAME: LoadESBCodeDefinition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface ILoadESBCodeDefinition
	{
		int LoadESBCodeDefinitionSp(string ListId,
		                            string CodeValue,
		                            string ActionExpression,
		                            string Name,
		                            string Description,
		                            ref string Infobar);
	}
	
	public class LoadESBCodeDefinition : ILoadESBCodeDefinition
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCodeDefinition(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBCodeDefinitionSp(string ListId,
		                                   string CodeValue,
		                                   string ActionExpression,
		                                   string Name,
		                                   string Description,
		                                   ref string Infobar)
		{
			StringType _ListId = ListId;
			StringType _CodeValue = CodeValue;
			StringType _ActionExpression = ActionExpression;
			StringType _Name = Name;
			StringType _Description = Description;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCodeDefinitionSp";
				
				appDB.AddCommandParameter(cmd, "ListId", _ListId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CodeValue", _CodeValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
