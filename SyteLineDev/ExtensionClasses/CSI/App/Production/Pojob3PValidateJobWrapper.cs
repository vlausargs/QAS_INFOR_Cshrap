//PROJECT NAME: Production
//CLASS NAME: Pojob3PValidateJobWrapper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Pojob3PValidateJobWrapper : IPojob3PValidateJobWrapper
	{
		readonly IApplicationDB appDB;
		
		
		public Pojob3PValidateJobWrapper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? TNextOper,
		string TCompleteUM,
		string TScrappedUM,
		string TMovedUM,
		int? TPromptForLoc,
		int? TPromptForLot,
		int? TPromptCloseJob,
		int? TPromptIssueParent,
		int? TSerNumTracked,
		string TSerNumPrefix,
		int? TIsLastOper,
		string TToLoc,
		string TToLocDescription,
		string TToLot,
		string JobItem,
		int? TPreassignLots,
		string Infobar,
		string JobRevision,
		int? TItemTrackECN) Pojob3PValidateJobWrapperSp(string TJob,
		int? TSuffix,
		int? TOper,
		decimal? TMove,
		string TCurWhse,
		int? TNextOper,
		string TCompleteUM,
		string TScrappedUM,
		string TMovedUM,
		int? TPromptForLoc,
		int? TPromptForLot,
		int? TPromptCloseJob,
		int? TPromptIssueParent,
		int? TSerNumTracked,
		string TSerNumPrefix,
		int? TIsLastOper,
		string TToLoc,
		string TToLocDescription,
		string TToLot,
		string JobItem,
		int? TPreassignLots,
		string Infobar,
		string JobRevision = null,
		int? TItemTrackECN = null)
		{
			JobType _TJob = TJob;
			SuffixType _TSuffix = TSuffix;
			OperNumType _TOper = TOper;
			QtyUnitType _TMove = TMove;
			WhseType _TCurWhse = TCurWhse;
			OperNumType _TNextOper = TNextOper;
			UMType _TCompleteUM = TCompleteUM;
			UMType _TScrappedUM = TScrappedUM;
			UMType _TMovedUM = TMovedUM;
			ListYesNoType _TPromptForLoc = TPromptForLoc;
			ListYesNoType _TPromptForLot = TPromptForLot;
			ListYesNoType _TPromptCloseJob = TPromptCloseJob;
			ListYesNoType _TPromptIssueParent = TPromptIssueParent;
			ListYesNoType _TSerNumTracked = TSerNumTracked;
			SerialPrefixType _TSerNumPrefix = TSerNumPrefix;
			ListYesNoType _TIsLastOper = TIsLastOper;
			LocType _TToLoc = TToLoc;
			DescriptionType _TToLocDescription = TToLocDescription;
			LotType _TToLot = TToLot;
			ItemType _JobItem = JobItem;
			ListYesNoType _TPreassignLots = TPreassignLots;
			InfobarType _Infobar = Infobar;
			RevisionType _JobRevision = JobRevision;
			ListYesNoType _TItemTrackECN = TItemTrackECN;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Pojob3PValidateJobWrapperSp";
				
				appDB.AddCommandParameter(cmd, "TJob", _TJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSuffix", _TSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOper", _TOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMove", _TMove, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCurWhse", _TCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TNextOper", _TNextOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TCompleteUM", _TCompleteUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TScrappedUM", _TScrappedUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TMovedUM", _TMovedUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPromptForLoc", _TPromptForLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPromptForLot", _TPromptForLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPromptCloseJob", _TPromptCloseJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPromptIssueParent", _TPromptIssueParent, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSerNumTracked", _TSerNumTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSerNumPrefix", _TSerNumPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TIsLastOper", _TIsLastOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TToLoc", _TToLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TToLocDescription", _TToLocDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TToLot", _TToLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPreassignLots", _TPreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRevision", _JobRevision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TItemTrackECN", _TItemTrackECN, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TNextOper = _TNextOper;
				TCompleteUM = _TCompleteUM;
				TScrappedUM = _TScrappedUM;
				TMovedUM = _TMovedUM;
				TPromptForLoc = _TPromptForLoc;
				TPromptForLot = _TPromptForLot;
				TPromptCloseJob = _TPromptCloseJob;
				TPromptIssueParent = _TPromptIssueParent;
				TSerNumTracked = _TSerNumTracked;
				TSerNumPrefix = _TSerNumPrefix;
				TIsLastOper = _TIsLastOper;
				TToLoc = _TToLoc;
				TToLocDescription = _TToLocDescription;
				TToLot = _TToLot;
				JobItem = _JobItem;
				TPreassignLots = _TPreassignLots;
				Infobar = _Infobar;
				JobRevision = _JobRevision;
				TItemTrackECN = _TItemTrackECN;
				
				return (Severity, TNextOper, TCompleteUM, TScrappedUM, TMovedUM, TPromptForLoc, TPromptForLot, TPromptCloseJob, TPromptIssueParent, TSerNumTracked, TSerNumPrefix, TIsLastOper, TToLoc, TToLocDescription, TToLot, JobItem, TPreassignLots, Infobar, JobRevision, TItemTrackECN);
			}
		}
	}
}
