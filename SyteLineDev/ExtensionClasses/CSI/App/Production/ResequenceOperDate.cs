//PROJECT NAME: Production
//CLASS NAME: ResequenceOperDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ResequenceOperDate : IResequenceOperDate
	{
		readonly IApplicationDB appDB;
		
		
		public ResequenceOperDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ResequenceOperDateSp(string Job,
		int? Suffix,
		int? OperNum,
		DateTime? NewStartDate)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			DateType _NewStartDate = NewStartDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ResequenceOperDateSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewStartDate", _NewStartDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
