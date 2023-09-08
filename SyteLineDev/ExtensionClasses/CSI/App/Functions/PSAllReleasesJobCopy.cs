//PROJECT NAME: Data
//CLASS NAME: PSAllReleasesJobCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PSAllReleasesJobCopy : IPSAllReleasesJobCopy
	{
		readonly IApplicationDB appDB;
		
		public PSAllReleasesJobCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PSAllReleasesJobCopySp(
			string FromJob,
			int? FromSuffix,
			string FromType,
			string FromRevision,
			int? FromOperNumStart,
			int? FromOperNumEnd,
			string FromOpt,
			string Pjob,
			DateTime? EffectDate,
			string Infobar,
			int? CopyUetValues = 0)
		{
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			JobTypeType _FromType = FromType;
			RevisionType _FromRevision = FromRevision;
			OperNumType _FromOperNumStart = FromOperNumStart;
			OperNumType _FromOperNumEnd = FromOperNumEnd;
			StringType _FromOpt = FromOpt;
			JobType _Pjob = Pjob;
			DateType _EffectDate = EffectDate;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CopyUetValues = CopyUetValues;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSAllReleasesJobCopySp";
				
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromType", _FromType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRevision", _FromRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOperNumStart", _FromOperNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOperNumEnd", _FromOperNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromOpt", _FromOpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pjob", _Pjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
