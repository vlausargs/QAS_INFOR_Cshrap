//PROJECT NAME: CSIProduct
//CLASS NAME: CreateJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICreateJob
	{
		int CreateJobSp(string JobType,
		                ref string Job,
		                ref short? Suffix,
		                string Item,
		                string Description,
		                string Revision,
		                decimal? QtyReleased,
		                string Status,
		                DateTime? JobDate,
		                DateTime? StartDate,
		                ref string Infobar);
	}
	
	public class CreateJob : ICreateJob
	{
		readonly IApplicationDB appDB;
		
		public CreateJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CreateJobSp(string JobType,
		                       ref string Job,
		                       ref short? Suffix,
		                       string Item,
		                       string Description,
		                       string Revision,
		                       decimal? QtyReleased,
		                       string Status,
		                       DateTime? JobDate,
		                       DateTime? StartDate,
		                       ref string Infobar)
		{
			JobTypeType _JobType = JobType;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			RevisionType _Revision = Revision;
			QtyUnitType _QtyReleased = QtyReleased;
			JobStatusType _Status = Status;
			DateType _JobDate = JobDate;
			DateType _StartDate = StartDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateJobSp";
				
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReleased", _QtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDate", _JobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Job = _Job;
				Suffix = _Suffix;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
