//PROJECT NAME: Production
//CLASS NAME: PSCmplTransGetVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPSCmplTransGetVars
	{
		(int? ReturnCode, decimal? JobtranTransNum, byte? TCoby, string Infobar, string PromptMsg, string PromptButtons) PSCmplTransGetVarsSp(decimal? JobtranTransNum,
		byte? TCoby,
		string Infobar,
		string PromptMsg = null,
		string PromptButtons = null);
	}
	
	public class PSCmplTransGetVars : IPSCmplTransGetVars
	{
		readonly IApplicationDB appDB;
		
		public PSCmplTransGetVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? JobtranTransNum, byte? TCoby, string Infobar, string PromptMsg, string PromptButtons) PSCmplTransGetVarsSp(decimal? JobtranTransNum,
		byte? TCoby,
		string Infobar,
		string PromptMsg = null,
		string PromptButtons = null)
		{
			HugeTransNumType _JobtranTransNum = JobtranTransNum;
			ListYesNoType _TCoby = TCoby;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSCmplTransGetVarsSp";
				
				appDB.AddCommandParameter(cmd, "JobtranTransNum", _JobtranTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobtranTransNum = _JobtranTransNum;
				TCoby = _TCoby;
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, JobtranTransNum, TCoby, Infobar, PromptMsg, PromptButtons);
			}
		}
	}
}
