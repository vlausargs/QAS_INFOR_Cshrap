//PROJECT NAME: Production
//CLASS NAME: Pojob3PValidateJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class Pojob3PValidateJob : IPojob3PValidateJob
	{
		readonly IApplicationDB appDB;
		
		
		public Pojob3PValidateJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TCompleteUM,
		string TScrappedUM,
		string TMovedUM,
		int? TPromptForLoc,
		int? TPromptForLot,
		int? TPromptCloseJob,
		int? TPromptIssueParent,
		int? TSerNumTracked,
		string TSerNumPrefix,
		string Infobar) Pojob3PValidateJobSp(string TJob,
		int? TSuffix,
		int? TOper,
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
		string Infobar)
		{
			JobType _TJob = TJob;
			SuffixType _TSuffix = TSuffix;
			OperNumType _TOper = TOper;
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
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Pojob3PValidateJobSp";
				
				appDB.AddCommandParameter(cmd, "TJob", _TJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSuffix", _TSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOper", _TOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TNextOper", _TNextOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCompleteUM", _TCompleteUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TScrappedUM", _TScrappedUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TMovedUM", _TMovedUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPromptForLoc", _TPromptForLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPromptForLot", _TPromptForLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPromptCloseJob", _TPromptCloseJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPromptIssueParent", _TPromptIssueParent, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSerNumTracked", _TSerNumTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSerNumPrefix", _TSerNumPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TCompleteUM = _TCompleteUM;
				TScrappedUM = _TScrappedUM;
				TMovedUM = _TMovedUM;
				TPromptForLoc = _TPromptForLoc;
				TPromptForLot = _TPromptForLot;
				TPromptCloseJob = _TPromptCloseJob;
				TPromptIssueParent = _TPromptIssueParent;
				TSerNumTracked = _TSerNumTracked;
				TSerNumPrefix = _TSerNumPrefix;
				Infobar = _Infobar;
				
				return (Severity, TCompleteUM, TScrappedUM, TMovedUM, TPromptForLoc, TPromptForLot, TPromptCloseJob, TPromptIssueParent, TSerNumTracked, TSerNumPrefix, Infobar);
			}
		}
	}
}
