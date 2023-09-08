//PROJECT NAME: MOIndPack
//CLASS NAME: MO_UpdateCoJobComnFields.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MOIndPack
{
	public class MO_UpdateCoJobComnFields : IMO_UpdateCoJobComnFields
	{
		readonly IApplicationDB appDB;
		
		public MO_UpdateCoJobComnFields(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MO_UpdateCoJobComnFieldsSp(
			string Job,
			string JobDescription,
			string JobType,
			string Whse,
			string JobStatus,
			string EstJob,
			DateTime? JobDate,
			DateTime? JobStart,
			int? JobPriority,
			int? PriorityFreeze,
			int? ProductCycle)
		{
			JobType _Job = Job;
			DescriptionType _JobDescription = JobDescription;
			JobTypeType _JobType = JobType;
			WhseType _Whse = Whse;
			JobStatusType _JobStatus = JobStatus;
			JobType _EstJob = EstJob;
			DateType _JobDate = JobDate;
			DateType _JobStart = JobStart;
			ApsSmallIntType _JobPriority = JobPriority;
			ListYesNoType _PriorityFreeze = PriorityFreeze;
			MO_ProductCycleType _ProductCycle = ProductCycle;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_UpdateCoJobComnFieldsSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDescription", _JobDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStatus", _JobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstJob", _EstJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDate", _JobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStart", _JobStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobPriority", _JobPriority, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorityFreeze", _PriorityFreeze, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCycle", _ProductCycle, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
