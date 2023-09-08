//PROJECT NAME: Data
//CLASS NAME: JobSplitPreview.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobSplitPreview : IJobSplitPreview
	{
		readonly IApplicationDB appDB;
		
		public JobSplitPreview(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobSplitPreviewSp(
			string Job,
			int? Suffix,
			string NewJob,
			int? NewSuffix,
			decimal? OrigRelease,
			decimal? CurRelease,
			string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobType _NewJob = NewJob;
			SuffixType _NewSuffix = NewSuffix;
			GenericDecimalType _OrigRelease = OrigRelease;
			QtyPerType _CurRelease = CurRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobSplitPreviewSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJob", _NewJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSuffix", _NewSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigRelease", _OrigRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurRelease", _CurRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
