//PROJECT NAME: Production
//CLASS NAME: JobmatlObsChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobmatlObsChk : IJobmatlObsChk
	{
		readonly IApplicationDB appDB;
		
		
		public JobmatlObsChk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JobmatlObsChkSp(string PJob,
		int? PSuffix,
		int? OperStart = null,
		int? OperEnd = null,
		string Infobar = null)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _OperStart = OperStart;
			OperNumType _OperEnd = OperEnd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobmatlObsChkSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperStart", _OperStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperEnd", _OperEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
