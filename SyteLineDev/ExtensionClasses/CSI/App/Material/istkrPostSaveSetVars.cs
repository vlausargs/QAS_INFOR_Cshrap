//PROJECT NAME: Material
//CLASS NAME: istkrPostSaveSetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IistkrPostSaveSetVars
	{
		(int? ReturnCode, string Infobar, string PromptMsg) istkrPostSaveSetVarsSp(string SET,
		string PWhseList,
		string PItemList,
		string Infobar,
		string PromptMsg = null);
	}
	
	public class istkrPostSaveSetVars : IistkrPostSaveSetVars
	{
		readonly IApplicationDB appDB;
		
		public istkrPostSaveSetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string PromptMsg) istkrPostSaveSetVarsSp(string SET,
		string PWhseList,
		string PItemList,
		string Infobar,
		string PromptMsg = null)
		{
			ProcessIndType _SET = SET;
			Infobar _PWhseList = PWhseList;
			Infobar _PItemList = PItemList;
			Infobar _Infobar = Infobar;
			Infobar _PromptMsg = PromptMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "istkrPostSaveSetVarsSp";
				
				appDB.AddCommandParameter(cmd, "SET", _SET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhseList", _PWhseList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemList", _PItemList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				
				return (Severity, Infobar, PromptMsg);
			}
		}
	}
}
