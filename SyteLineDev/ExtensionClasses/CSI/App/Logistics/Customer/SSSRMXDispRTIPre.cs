//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDispRTIPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXDispRTIPre : ISSSRMXDispRTIPre
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXDispRTIPre(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSRMXDispRTIPreSp(
			Guid? DispRowPointer,
			string PromptMsg,
			string PromptButtons,
			string Infobar)
		{
			RowPointer _DispRowPointer = DispRowPointer;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXDispRTIPreSp";
				
				appDB.AddCommandParameter(cmd, "DispRowPointer", _DispRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
