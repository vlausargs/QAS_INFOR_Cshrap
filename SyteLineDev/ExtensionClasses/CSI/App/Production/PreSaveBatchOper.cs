//PROJECT NAME: Production
//CLASS NAME: PreSaveBatchOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PreSaveBatchOper : IPreSaveBatchOper
	{
		readonly IApplicationDB appDB;
		
		
		public PreSaveBatchOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? OperNum,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar) PreSaveBatchOperSp(string Batch,
		int? OperNum,
		string Wc,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar)
		{
			ApsBatchType _Batch = Batch;
			OperNumType _OperNum = OperNum;
			WcType _Wc = Wc;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobTypeType _JobType = JobType;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreSaveBatchOperSp";
				
				appDB.AddCommandParameter(cmd, "Batch", _Batch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OperNum = _OperNum;
				Job = _Job;
				Suffix = _Suffix;
				JobType = _JobType;
				Infobar = _Infobar;
				
				return (Severity, OperNum, Job, Suffix, JobType, Infobar);
			}
		}
	}
}
