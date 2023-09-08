//PROJECT NAME: Production
//CLASS NAME: BuildListJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class BuildListJob : IBuildListJob
	{
		readonly IApplicationDB appDB;
		
		public BuildListJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PActual,
			decimal? PRemain,
			decimal? PPlanned) BuildListJobSp(
			string PJob = null,
			int? PSuffix = null,
			int? PIndent = null,
			decimal? PActual = null,
			decimal? PRemain = null,
			decimal? PPlanned = null)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			IntType _PIndent = PIndent;
			DecimalType _PActual = PActual;
			DecimalType _PRemain = PRemain;
			DecimalType _PPlanned = PPlanned;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BuildListJobSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIndent", _PIndent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PActual", _PActual, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRemain", _PRemain, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPlanned", _PPlanned, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PActual = _PActual;
				PRemain = _PRemain;
				PPlanned = _PPlanned;
				
				return (Severity, PActual, PRemain, PPlanned);
			}
		}
	}
}
