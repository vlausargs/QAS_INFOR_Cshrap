//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBJobOperation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBJobOperation : ILoadESBJobOperation
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBJobOperation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? OperNum,
		string Infobar) LoadESBJobOperationSp(string Job,
		int? Suffix,
		string OperationID,
		string ActionExpression,
		DateTime? StartDate,
		DateTime? EndDate,
		string RunTimeDurationPerUnit,
		string QueueDuration,
		string QueueOverlapDuration,
		string MoveDuration,
		string FixedDuration,
		decimal? RejectPercent,
		string BackFlushInicator,
		string WC,
		string LaborSetupTimeDuration,
		int? OperNum,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			LongListType _OperationID = OperationID;
			StringType _ActionExpression = ActionExpression;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			StringType _RunTimeDurationPerUnit = RunTimeDurationPerUnit;
			StringType _QueueDuration = QueueDuration;
			StringType _QueueOverlapDuration = QueueOverlapDuration;
			StringType _MoveDuration = MoveDuration;
			StringType _FixedDuration = FixedDuration;
			ScrapFactorType _RejectPercent = RejectPercent;
			StringType _BackFlushInicator = BackFlushInicator;
			WcType _WC = WC;
			StringType _LaborSetupTimeDuration = LaborSetupTimeDuration;
			OperNumType _OperNum = OperNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBJobOperationSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperationID", _OperationID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunTimeDurationPerUnit", _RunTimeDurationPerUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QueueDuration", _QueueDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QueueOverlapDuration", _QueueOverlapDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveDuration", _MoveDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FixedDuration", _FixedDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RejectPercent", _RejectPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BackFlushInicator", _BackFlushInicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WC", _WC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LaborSetupTimeDuration", _LaborSetupTimeDuration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OperNum = _OperNum;
				Infobar = _Infobar;
				
				return (Severity, OperNum, Infobar);
			}
		}
	}
}
