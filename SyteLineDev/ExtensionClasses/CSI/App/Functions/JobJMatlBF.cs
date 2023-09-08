//PROJECT NAME: Data
//CLASS NAME: JobJMatlBF.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobJMatlBF : IJobJMatlBF
	{
		readonly IApplicationDB appDB;
		
		public JobJMatlBF(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PJob,
			int? PSuffix) JobJMatlBFSp(
			string PItem,
			string PLoc,
			string PWhse,
			string PJob,
			int? PSuffix)
		{
			ItemType _PItem = PItem;
			LocType _PLoc = PLoc;
			WhseType _PWhse = PWhse;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobJMatlBFSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PJob = _PJob;
				PSuffix = _PSuffix;
				
				return (Severity, PJob, PSuffix);
			}
		}
	}
}
