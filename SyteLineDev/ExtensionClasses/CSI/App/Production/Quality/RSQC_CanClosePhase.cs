//PROJECT NAME: Production
//CLASS NAME: RSQC_CanClosePhase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CanClosePhase : IRSQC_CanClosePhase
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CanClosePhase(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string can_close) RSQC_CanClosePhaseSp(string flow_num,
		int? i_seq,
		string can_close)
		{
			QCDocNumType _flow_num = flow_num;
			IntType _i_seq = i_seq;
			StringType _can_close = can_close;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CanClosePhaseSp";
				
				appDB.AddCommandParameter(cmd, "flow_num", _flow_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_seq", _i_seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "can_close", _can_close, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				can_close = _can_close;
				
				return (Severity, can_close);
			}
		}
	}
}
