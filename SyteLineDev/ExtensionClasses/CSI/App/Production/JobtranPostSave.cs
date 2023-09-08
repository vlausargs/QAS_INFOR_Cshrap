//PROJECT NAME: Production
//CLASS NAME: JobtranPostSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobtranPostSave : IJobtranPostSave
	{
		readonly IApplicationDB appDB;
		
		
		public JobtranPostSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JobtranPostSaveSp(string Job,
		int? Suffix,
		int? OperNum,
		string Wc)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			WcType _Wc = Wc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtranPostSaveSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
