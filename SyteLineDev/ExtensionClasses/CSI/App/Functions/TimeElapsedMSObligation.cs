//PROJECT NAME: Data
//CLASS NAME: TimeElapsedMSObligation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TimeElapsedMSObligation : ITimeElapsedMSObligation
	{
		readonly IApplicationDB appDB;
		
		public TimeElapsedMSObligation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TimeElapsedMSObligationSp(
			string ProjNum,
			int? ProjTaskNum,
			decimal? Sequence)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _ProjTaskNum = ProjTaskNum;
			SequenceType _Sequence = Sequence;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TimeElapsedMSObligationSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjTaskNum", _ProjTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
