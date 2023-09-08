//PROJECT NAME: Logistics
//CLASS NAME: ValidatePoNumWarning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidatePoNumWarning : IValidatePoNumWarning
	{
		readonly IApplicationDB appDB;
		
		
		public ValidatePoNumWarning(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string Buttons,
		string Infobar) ValidatePoNumWarningSp(string PoNum,
		string PromptMsg,
		string Buttons,
		string Infobar)
		{
			PoNumType _PoNum = PoNum;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _Buttons = Buttons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidatePoNumWarningSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				Buttons = _Buttons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, Buttons, Infobar);
			}
		}
	}
}
