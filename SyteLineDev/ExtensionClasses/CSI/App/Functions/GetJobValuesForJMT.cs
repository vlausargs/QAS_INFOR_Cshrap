//PROJECT NAME: Data
//CLASS NAME: GetJobValuesForJMT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetJobValuesForJMT : IGetJobValuesForJMT
	{
		readonly IApplicationDB appDB;
		
		public GetJobValuesForJMT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? InSuffix,
			int? JobCoProdMix,
			string JobOrdType,
			string JobItem,
			string JobWhse,
			string JobRootJob,
			int? JobRootSuf,
			string JobRefJob,
			string JobStat,
			string JobType,
			string Infobar) GetJobValuesForJMTSp(
			string InJob,
			int? InSuffix,
			int? JobCoProdMix,
			string JobOrdType,
			string JobItem,
			string JobWhse,
			string JobRootJob,
			int? JobRootSuf,
			string JobRefJob,
			string JobStat,
			string JobType,
			string Infobar)
		{
			JobType _InJob = InJob;
			SuffixType _InSuffix = InSuffix;
			ListYesNoType _JobCoProdMix = JobCoProdMix;
			RefTypeIKOTType _JobOrdType = JobOrdType;
			ItemType _JobItem = JobItem;
			WhseType _JobWhse = JobWhse;
			JobType _JobRootJob = JobRootJob;
			SuffixType _JobRootSuf = JobRootSuf;
			JobType _JobRefJob = JobRefJob;
			JobStatusType _JobStat = JobStat;
			JobTypeType _JobType = JobType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetJobValuesForJMTSp";
				
				appDB.AddCommandParameter(cmd, "InJob", _InJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSuffix", _InSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobCoProdMix", _JobCoProdMix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobOrdType", _JobOrdType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobWhse", _JobWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRootJob", _JobRootJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRootSuf", _JobRootSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobRefJob", _JobRefJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobStat", _JobStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InSuffix = _InSuffix;
				JobCoProdMix = _JobCoProdMix;
				JobOrdType = _JobOrdType;
				JobItem = _JobItem;
				JobWhse = _JobWhse;
				JobRootJob = _JobRootJob;
				JobRootSuf = _JobRootSuf;
				JobRefJob = _JobRefJob;
				JobStat = _JobStat;
				JobType = _JobType;
				Infobar = _Infobar;
				
				return (Severity, InSuffix, JobCoProdMix, JobOrdType, JobItem, JobWhse, JobRootJob, JobRootSuf, JobRefJob, JobStat, JobType, Infobar);
			}
		}
	}
}
