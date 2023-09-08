//PROJECT NAME: Production
//CLASS NAME: Pojob3P.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Pojob3P : IPojob3P
	{
		readonly IApplicationDB appDB;
		
		
		public Pojob3P(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TToLoc,
		string TToLot,
		int? RestartPoint,
		int? TCoby,
		decimal? XJobtranTransNum,
		string PromptMsg,
		string PromptButtons,
		string Infobar) Pojob3PSp(string TJob,
		int? TSuffix,
		int? TOper,
		DateTime? TTransDate,
		decimal? TComplete,
		string TCompleteUM,
		decimal? TScrapped,
		string TScrappedUM,
		decimal? TMove,
		string TMovedUM,
		int? TNextOper,
		string TRsnCode,
		int? TOperComplete,
		int? TCloseJob,
		int? TIssueParent,
		string TCurWhse,
		Guid? JobMatSessionID,
		string TToLoc,
		string TToLot,
		int? RestartPoint,
		int? TCoby,
		decimal? XJobtranTransNum,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			JobType _TJob = TJob;
			SuffixType _TSuffix = TSuffix;
			OperNumType _TOper = TOper;
			DateType _TTransDate = TTransDate;
			QtyUnitType _TComplete = TComplete;
			UMType _TCompleteUM = TCompleteUM;
			QtyUnitType _TScrapped = TScrapped;
			UMType _TScrappedUM = TScrappedUM;
			QtyUnitType _TMove = TMove;
			UMType _TMovedUM = TMovedUM;
			OperNumType _TNextOper = TNextOper;
			ReasonCodeType _TRsnCode = TRsnCode;
			ListYesNoType _TOperComplete = TOperComplete;
			ListYesNoType _TCloseJob = TCloseJob;
			ListYesNoType _TIssueParent = TIssueParent;
			WhseType _TCurWhse = TCurWhse;
			RowPointerType _JobMatSessionID = JobMatSessionID;
			LocType _TToLoc = TToLoc;
			LotType _TToLot = TToLot;
			IntType _RestartPoint = RestartPoint;
			ListYesNoType _TCoby = TCoby;
			HugeTransNumType _XJobtranTransNum = XJobtranTransNum;
			InfobarType _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Pojob3PSp";
				
				appDB.AddCommandParameter(cmd, "TJob", _TJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSuffix", _TSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOper", _TOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransDate", _TTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TComplete", _TComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCompleteUM", _TCompleteUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TScrapped", _TScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TScrappedUM", _TScrappedUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMove", _TMove, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMovedUM", _TMovedUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TNextOper", _TNextOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRsnCode", _TRsnCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOperComplete", _TOperComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCloseJob", _TCloseJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TIssueParent", _TIssueParent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurWhse", _TCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobMatSessionID", _JobMatSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TToLoc", _TToLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TToLot", _TToLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RestartPoint", _RestartPoint, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "XJobtranTransNum", _XJobtranTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TToLoc = _TToLoc;
				TToLot = _TToLot;
				RestartPoint = _RestartPoint;
				TCoby = _TCoby;
				XJobtranTransNum = _XJobtranTransNum;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, TToLoc, TToLot, RestartPoint, TCoby, XJobtranTransNum, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
