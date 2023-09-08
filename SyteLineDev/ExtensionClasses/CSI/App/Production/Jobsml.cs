//PROJECT NAME: CSIProduct
//CLASS NAME: Jobsml.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IJobsml
	{
		(int? ReturnCode, string Infobar) JobsmlSp(string Job,
		short? Suffix,
		string NewJob,
		short? NewSuffix,
		decimal? QtyToSplit,
		string Title,
		byte? Process,
		string Infobar,
		byte? CopyUetValues = (byte)0);
	}
	
	public class Jobsml : IJobsml
	{
		readonly IApplicationDB appDB;
		
		public Jobsml(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JobsmlSp(string Job,
		short? Suffix,
		string NewJob,
		short? NewSuffix,
		decimal? QtyToSplit,
		string Title,
		byte? Process,
		string Infobar,
		byte? CopyUetValues = (byte)0)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobType _NewJob = NewJob;
			SuffixType _NewSuffix = NewSuffix;
			QtyUnitType _QtyToSplit = QtyToSplit;
			InfobarType _Title = Title;
			ListYesNoType _Process = Process;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CopyUetValues = CopyUetValues;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobsmlSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJob", _NewJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSuffix", _NewSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToSplit", _QtyToSplit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Title", _Title, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
