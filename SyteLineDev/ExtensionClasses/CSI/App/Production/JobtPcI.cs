//PROJECT NAME: Production
//CLASS NAME: JobtPcI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobtPcI : IJobtPcI
	{
		readonly IApplicationDB appDB;
		
		
		public JobtPcI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JobtPcISp(decimal? JobtClsJtTransNum,
		int? TCoby = null,
		string Infobar = null)
		{
			HugeTransNumType _JobtClsJtTransNum = JobtClsJtTransNum;
			FlagNyType _TCoby = TCoby;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobtPcISp";
				
				appDB.AddCommandParameter(cmd, "JobtClsJtTransNum", _JobtClsJtTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TCoby", _TCoby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
