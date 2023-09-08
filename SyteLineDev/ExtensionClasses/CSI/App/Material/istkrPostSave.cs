//PROJECT NAME: Material
//CLASS NAME: istkrPostSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class istkrPostSave : IistkrPostSave
	{
		readonly IApplicationDB appDB;
		
		
		public istkrPostSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		string PromptMsg) istkrPostSaveSp(string PWhseList,
		string PItemList,
		string Infobar,
		string PromptMsg)
		{
			LongListType _PWhseList = PWhseList;
			LongListType _PItemList = PItemList;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "istkrPostSaveSp";
				
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
