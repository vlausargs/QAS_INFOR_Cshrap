//PROJECT NAME: CSIProduct
//CLASS NAME: JobMerge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IJobMerge
	{
		int JobMergeSp(string FromJob,
		               short? FromSuffix,
		               string ToJob,
		               short? ToSuffix,
		               string CurWhse,
		               ref string Infobar);
	}
	
	public class JobMerge : IJobMerge
	{
		readonly IApplicationDB appDB;
		
		public JobMerge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int JobMergeSp(string FromJob,
		                      short? FromSuffix,
		                      string ToJob,
		                      short? ToSuffix,
		                      string CurWhse,
		                      ref string Infobar)
		{
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			WhseType _CurWhse = CurWhse;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobMergeSp";
				
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
