//PROJECT NAME: Production
//CLASS NAME: ApsCtpXRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCtpXRef : IApsCtpXRef
	{
		readonly IApplicationDB appDB;
		
		
		public ApsCtpXRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PAllowCtp) ApsCtpXRefSp(string PJob,
		int? PSuffix,
		int? PAllowCtp)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			ListYesNoType _PAllowCtp = PAllowCtp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsCtpXRefSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAllowCtp", _PAllowCtp, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAllowCtp = _PAllowCtp;
				
				return (Severity, PAllowCtp);
			}
		}
	}
}
