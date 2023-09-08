//PROJECT NAME: Production
//CLASS NAME: JobOperations.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobOperations : IJobOperations
	{
		readonly IApplicationDB appDB;
		
		
		public JobOperations(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string job,
		int? Suffix,
		string Type) JobOperationsSp(string OpCategory,
		string job,
		string SchedId,
		string Item,
		DateTime? Release,
		int? Suffix,
		string Type,
		string AlternateID = null)
		{
			StringType _OpCategory = OpCategory;
			JobType _job = job;
			PsNumType _SchedId = SchedId;
			ItemType _Item = Item;
			DateType _Release = Release;
			SuffixType _Suffix = Suffix;
			JobTypeType _Type = Type;
			MO_BOMAlternateType _AlternateID = AlternateID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobOperationsSp";
				
				appDB.AddCommandParameter(cmd, "OpCategory", _OpCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "job", _job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SchedId", _SchedId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Release", _Release, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				job = _job;
				Suffix = _Suffix;
				Type = _Type;
				
				return (Severity, job, Suffix, Type);
			}
		}
	}
}
