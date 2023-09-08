//PROJECT NAME: Employee
//CLASS NAME: HrNextPosDet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class HrNextPosDet : IHrNextPosDet
	{
		readonly IApplicationDB appDB;
		
		
		public HrNextPosDet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? JobDetail,
		string Infobar) HrNextPosDetSp(string Position,
		int? JobDetail,
		string Infobar)
		{
			JobIdType _Position = Position;
			JobDetailType _JobDetail = JobDetail;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "HrNextPosDetSp";
				
				appDB.AddCommandParameter(cmd, "Position", _Position, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDetail", _JobDetail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobDetail = _JobDetail;
				Infobar = _Infobar;
				
				return (Severity, JobDetail, Infobar);
			}
		}
	}
}
