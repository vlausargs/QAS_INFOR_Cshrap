//PROJECT NAME: Production
//CLASS NAME: Pojob3PValidateCloseJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Pojob3PValidateCloseJob : IPojob3PValidateCloseJob
	{
		readonly IApplicationDB appDB;
		
		
		public Pojob3PValidateCloseJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ResponseNum,
		int? ResponseSeq,
		string PromptMsg,
		string PromptButtons,
		string Infobar) Pojob3PValidateCloseJobSp(string TJob,
		int? TSuffix,
		int? TOper,
		decimal? TMove,
		int? TNextOper,
		int? TCloseJob,
		int? ResponseNum,
		int? ResponseSeq,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			JobType _TJob = TJob;
			SuffixType _TSuffix = TSuffix;
			OperNumType _TOper = TOper;
			QtyUnitType _TMove = TMove;
			OperNumType _TNextOper = TNextOper;
			ListYesNoType _TCloseJob = TCloseJob;
			IntType _ResponseNum = ResponseNum;
			JobmatlSequenceType _ResponseSeq = ResponseSeq;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Pojob3PValidateCloseJobSp";
				
				appDB.AddCommandParameter(cmd, "TJob", _TJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSuffix", _TSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOper", _TOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMove", _TMove, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TNextOper", _TNextOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCloseJob", _TCloseJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResponseNum", _ResponseNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ResponseSeq", _ResponseSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ResponseNum = _ResponseNum;
				ResponseSeq = _ResponseSeq;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, ResponseNum, ResponseSeq, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
