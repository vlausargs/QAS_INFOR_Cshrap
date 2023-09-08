//PROJECT NAME: Data
//CLASS NAME: Split.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Split : ISplit
	{
		readonly IApplicationDB appDB;
		
		public Split(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TTotalTime) SplitSp(
			string TEmpNum,
			string TJob,
			int? TSuffix,
			int? TOperNum,
			int? TStartTime,
			int? TEndTime,
			DateTime? TStartDate,
			DateTime? TEndDate,
			int? TTotalTime)
		{
			EmpNumType _TEmpNum = TEmpNum;
			JobType _TJob = TJob;
			SuffixType _TSuffix = TSuffix;
			OperNumType _TOperNum = TOperNum;
			TimeSecondsType _TStartTime = TStartTime;
			TimeSecondsType _TEndTime = TEndTime;
			DateType _TStartDate = TStartDate;
			DateType _TEndDate = TEndDate;
			GenericNoType _TTotalTime = TTotalTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SplitSp";
				
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TJob", _TJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSuffix", _TSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOperNum", _TOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TStartTime", _TStartTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEndTime", _TEndTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TStartDate", _TStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEndDate", _TEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTotalTime", _TTotalTime, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TTotalTime = _TTotalTime;
				
				return (Severity, TTotalTime);
			}
		}
	}
}
