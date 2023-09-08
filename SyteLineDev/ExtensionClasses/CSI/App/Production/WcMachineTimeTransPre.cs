//PROJECT NAME: Production
//CLASS NAME: WcMachineTimeTransPre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class WcMachineTimeTransPre : IWcMachineTimeTransPre
	{
		readonly IApplicationDB appDB;
		
		
		public WcMachineTimeTransPre(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PWorkCenter,
		int? TRptInHrs,
		string PromptMsg,
		string PromptButtons,
		string Infobar) WcMachineTimeTransPreSp(string PWorkCenter,
		int? TRptInHrs,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			WcType _PWorkCenter = PWorkCenter;
			ListHrsMinType _TRptInHrs = TRptInHrs;
			InfobarType _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WcMachineTimeTransPreSp";
				
				appDB.AddCommandParameter(cmd, "PWorkCenter", _PWorkCenter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TRptInHrs", _TRptInHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PWorkCenter = _PWorkCenter;
				TRptInHrs = _TRptInHrs;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PWorkCenter, TRptInHrs, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
