//PROJECT NAME: Production
//CLASS NAME: RSQC_CanCloseProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CanCloseProcess : IRSQC_CanCloseProcess
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CanCloseProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string can_close) RSQC_CanCloseProcessSp(string flow_num,
		string can_close)
		{
			QCDocNumType _flow_num = flow_num;
			StringType _can_close = can_close;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CanCloseProcessSp";
				
				appDB.AddCommandParameter(cmd, "flow_num", _flow_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "can_close", _can_close, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				can_close = _can_close;
				
				return (Severity, can_close);
			}
		}
	}
}
