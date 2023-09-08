//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGanttGetJobOrdNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IApsGanttGetJobOrdNum
	{
		(int? ReturnCode, string CoNum) ApsGanttGetJobOrdNumSp(string Job,
		short? Suffix = null,
		string CoNum = null);
	}
	
	public class ApsGanttGetJobOrdNum : IApsGanttGetJobOrdNum
	{
		readonly IApplicationDB appDB;
		
		public ApsGanttGetJobOrdNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CoNum) ApsGanttGetJobOrdNumSp(string Job,
		short? Suffix = null,
		string CoNum = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGanttGetJobOrdNumSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoNum = _CoNum;
				
				return (Severity, CoNum);
			}
		}
	}
}
