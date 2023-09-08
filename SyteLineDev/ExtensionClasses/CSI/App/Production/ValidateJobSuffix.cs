//PROJECT NAME: Production
//CLASS NAME: ValidateJobSuffix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ValidateJobSuffix : IValidateJobSuffix
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateJobSuffix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string JobSuffix,
		string JobStat,
		decimal? QtyReleasesd,
		string JobItem,
		int? CoProductMix,
		string ItmDescription,
		string Infobar) ValidateJobSuffixSp(string Job,
		int? Suffix,
		string JobSuffix,
		string JobStat,
		decimal? QtyReleasesd,
		string JobItem,
		int? CoProductMix,
		string ItmDescription,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			StringType _JobSuffix = JobSuffix;
			JobStatusType _JobStat = JobStat;
			QtyUnitType _QtyReleasesd = QtyReleasesd;
			ItemType _JobItem = JobItem;
			CoProductMixType _CoProductMix = CoProductMix;
			DescriptionType _ItmDescription = ItmDescription;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateJobSuffixSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffix", _JobSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobStat", _JobStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyReleasesd", _QtyReleasesd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoProductMix", _CoProductMix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItmDescription", _ItmDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobSuffix = _JobSuffix;
				JobStat = _JobStat;
				QtyReleasesd = _QtyReleasesd;
				JobItem = _JobItem;
				CoProductMix = _CoProductMix;
				ItmDescription = _ItmDescription;
				Infobar = _Infobar;
				
				return (Severity, JobSuffix, JobStat, QtyReleasesd, JobItem, CoProductMix, ItmDescription, Infobar);
			}
		}
	}
}
