//PROJECT NAME: Production
//CLASS NAME: SaveBomIBJobroute.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class SaveBomIBJobroute : ISaveBomIBJobroute
	{
		readonly IApplicationDB appDB;
		
		
		public SaveBomIBJobroute(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SaveBomIBJobrouteSp(Guid? ProcessId,
		string Job,
		int? Suffix,
		int? OperNum,
		string Wc,
		string WcDescription)
		{
			RowPointerType _ProcessId = ProcessId;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			WcType _Wc = Wc;
			DescriptionType _WcDescription = WcDescription;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SaveBomIBJobrouteSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WcDescription", _WcDescription, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
